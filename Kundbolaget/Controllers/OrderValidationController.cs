using System;
using System.Collections.Generic;
using System.IO;
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

        // GET: OrderValidation
        public ActionResult Index()
        {
            // Read order JSON file
            string fileName = @"C:\order.json";
            string orderJson = System.IO.File.ReadAllText(fileName);

            // Validate order file data
            JsonOrder orderData;
            JsonOrderViewModel viewModel;
            ICollection<ValidationError> errors;
            ValidateJsonOrder(orderJson, out errors, out orderData, out viewModel);

            if (viewModel.OrderIsValid)
            {
                return View(viewModel);
            }
            else
            {
                return View("InvalidOrderFile", viewModel);
            }
        }

        private void ValidateJsonOrder(string orderJson, out ICollection<ValidationError> errors, out JsonOrder orderData, out JsonOrderViewModel viewModel)
        {
            var schema = JsonSchema4.FromType<JsonOrder>();
            errors = schema.Validate(orderJson);

            orderData = JsonConvert.DeserializeObject<JsonOrder>(orderJson);
            viewModel = new JsonOrderViewModel
            {
                Json = orderJson,
                ValidationErrors = errors,
                OrderIsValid = true,
                Order = new Order
                {
                    Customer = customerRepository.Find(orderData.CustomerId),
                    CustomerId = orderData.CustomerId,
                    ShippingAddress = addressRepository.Find(orderData.DeliveryAddressId),
                    ShippingAddressId = orderData.DeliveryAddressId,
                    DesiredDeliveryDate = orderData.DeliveryDate,
                    OrderRows = new List<OrderRow>()
                },
            };

            // Check if customer exists
            if (viewModel.Order.Customer == null)
            {
                viewModel.OrderIsValid = false;
                viewModel.ErrorMessage += $"Kund-id {orderData.CustomerId} existerar inte";
            }

            // Check if products exist
            foreach (var fileOrderRow in orderData.OrderRows)
            {
                var product = productRepository.Find(fileOrderRow.ArticleId);
                if (product != null)
                {
                    var orderRow = new OrderRow
                    {
                        Product = product,
                        ProductId = product.Id,
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

        private void CreateNewOrder(Order order)
        {
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
        public ActionResult ConfirmOrder(Order order)
        {
            CreateNewOrder(order);
            return View("OrderPlaced", order);
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
            JsonOrder orderData;
            JsonOrderViewModel viewModel;
            ICollection<ValidationError> errors;
            ValidateJsonOrder(json, out errors, out orderData, out viewModel);

            //CreateNewOrder(viewModel.Order);
            //return View("ConfirmOrder", viewModel.Order);

            if (viewModel.OrderIsValid)
            {
                // Order file passed validation
                return View("ConfirmOrder", viewModel.Order);
            }
            else
            {
                // Order file failed validation
                return View("InvalidOrderFile", viewModel);
            }
        }
    }
}