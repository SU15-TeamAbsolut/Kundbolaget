using System.Collections.Generic;
using System.Web.Mvc;
using Kundbolaget.EntityFramework.Repositories;
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
        private readonly CustomerRepository _customerRepository;
        private readonly IRepository<Address> _addressRepository;
        private readonly ProductRepository _productRepository;
        private readonly IRepository<Order> _orderRepository;

        public OrderValidationController()
        {
            _customerRepository = new CustomerRepository();
            _addressRepository = new DataRepository<Address>();
            _productRepository = new ProductRepository();
        }

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
                Order = new Order
                {
                    Customer = _customerRepository.Find(orderData.CustomerId),
                    ShippingAddress = _addressRepository.Find(orderData.DeliveryAddressId),
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
                var product = _productRepository.Find(fileOrderRow.ArticleId);
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
        public ActionResult PlaceOrder(Order order)
        {
            _orderRepository.Create(order);

            return View(order);
        }
    }
}