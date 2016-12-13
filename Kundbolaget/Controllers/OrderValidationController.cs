using System;
using System.Collections.Generic;
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
        private readonly IRepository<Order> orderRepository = new DataRepository<Order>();

        // GET: OrderValidation
        public ActionResult Index()
        {
            // Read order JSON file
            string fileName = @"C:\order.json";
            string orderJson = System.IO.File.ReadAllText(fileName);

            var schema = JsonSchema4.FromType<JsonOrder>();
            ICollection<ValidationError> errors = schema.Validate(orderJson);

            // Validate order file data
            var orderData = JsonConvert.DeserializeObject<JsonOrder>(orderJson);
            var viewModel = new JsonOrderViewModel
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
                return View("InvalidOrder", viewModel);
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

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult PlaceOrder(JsonOrderViewModel orderModel)
        {
            var order = orderModel.Order;

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

            return View(order);
        }
    }
}