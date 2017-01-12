using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Kundbolaget.EntityFramework.Repositories;
using Kundbolaget.Enums;
using Kundbolaget.Models.EntityModels;
using Kundbolaget.Models.JsonModels;
using Kundbolaget.Models.ViewModels;
using Newtonsoft.Json;
using NJsonSchema;
using NJsonSchema.Validation;

namespace Kundbolaget.Controllers
{
    public class OrderValidationController : Controller
    {
        private readonly IRepository<Customer> customerRepository = new CustomerRepository();
        private readonly IRepository<Address> addressRepository = new DataRepository<Address>();
        private readonly IRepository<Product> productRepository = new ProductRepository();
        private readonly IRepository<Order> orderRepository = new OrderRepository();
        private readonly SupplyRepository supplyRepository = new SupplyRepository();

        // GET: OrderValidation
        public ActionResult Index()
        {
            // Read order JSON file
            string fileName = @"C:\order.json";
            string orderJson = System.IO.File.ReadAllText(fileName);

            // Validate order file data
            JsonCustomerOrder customerOrderData;
            JsonOrderViewModel viewModel;
            ICollection<ValidationError> errors;
            ValidateJsonOrder(orderJson, out errors, out customerOrderData, out viewModel);

            if (viewModel.OrderIsValid)
            {
                return View(viewModel);
            }
            else
            {
                return View("InvalidOrderFile", viewModel);
            }
        }

        private void ValidateJsonOrder(string orderJson, out ICollection<ValidationError> errors, out JsonCustomerOrder customerOrderData, out JsonOrderViewModel viewModel)
        {
            var schema = JsonSchema4.FromType<JsonCustomerOrder>();
            errors = schema.Validate(orderJson);

            customerOrderData = JsonConvert.DeserializeObject<JsonCustomerOrder>(orderJson);
            viewModel = new JsonOrderViewModel
            {
                Json = orderJson,
                ValidationErrors = errors,
                OrderIsValid = true,
                Order = new Order
                {
                    Customer = customerRepository.Find(customerOrderData.CustomerId),
                    CustomerId = customerOrderData.CustomerId,
                    CustomerOrderRef = customerOrderData.CustomerOrderRef,
                    ShippingAddress = addressRepository.Find(customerOrderData.DeliveryAddressId),
                    ShippingAddressId = customerOrderData.DeliveryAddressId,
                    DesiredDeliveryDate = customerOrderData.DeliveryDate
                },
            };

            // Check if customer exists
            if (viewModel.Order.Customer == null)
            {
                viewModel.OrderIsValid = false;
                viewModel.ErrorMessage += $"Kund-id {customerOrderData.CustomerId} existerar inte";
                return;
            }

            // Check that alcohol license is valid
            if (!viewModel.Order.Customer.AlcoholLicense.IsValid)
            {
                viewModel.OrderIsValid = false;
                viewModel.ErrorMessage += $"Kund #{customerOrderData.CustomerId} har ingen giltig alkohollicens";
                return;
            }

            // Check date - change date if it's in the past
            if (viewModel.Order.DesiredDeliveryDate < DateTime.Today)
            {
                viewModel.Order.DesiredDeliveryDate = DateTime.Today;
            }

            //Check if customer order reference exist
            if (viewModel.Order.CustomerOrderRef != null)
            {
                var orders = orderRepository.GetAll();
                foreach (var order in orders)
                {
                    var orderRef = order.CustomerOrderRef;
                    if (viewModel.Order.CustomerOrderRef == orderRef)
                    {
                        viewModel.OrderIsValid = false;
                        viewModel.ErrorMessage += $"Orderreferensen: {orderRef}, är redan registrerad.";
                    }
                }
            }
            
            // Check if products exist
            foreach (var fileOrderRow in customerOrderData.OrderRows)
            {
                var product = productRepository.Find(fileOrderRow.ArticleId);
                if (product != null)
                {
                    var orderRow = new OrderRow
                    {
                        Product = product,
                        ProductId = product.Id,
                        Price = product.Price,
                        AmountOrdered = fileOrderRow.Amount
                    };

                    viewModel.Order.OrderRows.Add(orderRow);
                }
                else
                {
                    viewModel.OrderIsValid = false;
                    viewModel.ErrorMessage += $"Artikel {fileOrderRow.ArticleId} existerar inte";
                }
            }

        }

        public void CreateNewOrder(Order order)
        {
            // Don't create orders with zero rows
            if (order.OrderRows.Count == 0)
            {
                return;
            }

            // fetch customer data for the view
            if (order.Customer == null)
            {
                order.Customer = customerRepository.Find(order.CustomerId);
            }

            // Loop through order rows, copy price from products
            foreach (var row in order.OrderRows)
            {
                row.Order = order;
                row.Price = productRepository.Find(row.ProductId).Price;
            }

            // Set order registration date, status
            order.OrderStatus = OrderStatus.Registered;
            order.OrderPlaced = DateTime.Now;

            // shipit.jpg
            orderRepository.Create(order);
        }

        [HttpPost]
        public ActionResult ConfirmOrder(OrderConfirmationViewModel orderVM)
        {
            CreateNewOrder(orderVM.Order);
            orderVM.Order = orderRepository.Find(orderVM.Order.Id);

            if (orderVM.BackOrder != null)
            {
                CreateNewOrder(orderVM.BackOrder);
                orderVM.BackOrder = orderRepository.Find(orderVM.BackOrder.Id);
            }

            // Write return file
            CreateReturnFile(orderVM.Order, orderVM.BackOrder);

            return View("OrderPlaced", orderVM);
        }

        [HttpPost]
        public ActionResult OrderNotPlaced(JsonOrderViewModel orderModel)
        {
            return View(orderModel.Order);
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(JsonFileUploadViewModel model)
        {
            byte[] data;

            using (var ms = new MemoryStream())
            {
                model.File.InputStream.CopyTo(ms);
                data = ms.ToArray();
            }
            var json = Encoding.Default.GetString(data);

            // Validate order file data
            JsonCustomerOrder customerOrderData;
            JsonOrderViewModel jsonOrderViewModel;
            ICollection<ValidationError> errors;
            ValidateJsonOrder(json, out errors, out customerOrderData, out jsonOrderViewModel);

            if (!jsonOrderViewModel.OrderIsValid)
            {
                // Order file failed validation
                return View("InvalidOrderFile", jsonOrderViewModel);
            }

            var order = jsonOrderViewModel.Order;
            Order backOrder = null;

            // Fetch stock from inventory, calculate discount
            foreach (var row in order.OrderRows)
            {
                row.AmountInStock = supplyRepository.GetAmountInStock(row.ProductId);

                if (row.AmountOrdered >= 20)
                {
                    // TODO: Edit global discount somewhere
                    row.Discount = (decimal) 0.08;
                }
            }


            // Products out of stock?
            bool outOfStock = order.OrderRows.Count(r => !r.IsInStock) > 0;
            if (outOfStock)
            {
                backOrder = new Order
                {
                    Customer = order.Customer,
                    CustomerId = order.CustomerId,
                    CustomerOrderRef = order.CustomerOrderRef,
                    OrderStatus = order.OrderStatus,
                    ShippingAddress = order.ShippingAddress,
                    ShippingAddressId = order.ShippingAddressId,
                    OrderRows = order.OrderRows.Where(r => !r.IsInStock).ToList(),
                    DesiredDeliveryDate = order.DesiredDeliveryDate.AddDays(7)
                };

                // Remove out of stock rows from main order
                order.OrderRows = order.OrderRows.Where(r => r.IsInStock).ToList();
            }

            var confirmationViewModel = new OrderConfirmationViewModel
            {
                Order = order,
                BackOrder = backOrder
            };

            return View("ConfirmOrder", confirmationViewModel);
        }

        private void CreateReturnFile(Order order, Order backOrder)
        {
            string dir = @"C:\OrderFiles";
            Directory.CreateDirectory(dir);

            var json = new JsonReturnFile
            {
                CustomerId = order?.CustomerId ?? backOrder?.CustomerId,
                Orders = new List<JsonCustomerOrder>()
            };

            string fileName = "";
            if (order != null)
            {
                json.Orders.Add(new JsonCustomerOrder(order));
                fileName += $"o{order.Id}";
            }

            if (backOrder != null)
            {
                json.Orders.Add(new JsonCustomerOrder(backOrder));
                fileName += $"o{backOrder.Id}";
            }

            // Add customer id to filename
            fileName += 'c' + (order?.CustomerId.ToString() ?? backOrder?.CustomerId.ToString());

            string file = JsonConvert.SerializeObject(json);
            System.IO.File.WriteAllText($@"C:\OrderFiles\{fileName}.json", file);

        }
    }
}