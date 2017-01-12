using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kundbolaget.EntityFramework.Repositories;
using Kundbolaget.Models.EntityModels;
using Kundbolaget.Models.ViewModels;

namespace Kundbolaget.Controllers
{
    public class ManuallyCreatingOrderController : Controller
    {
        private readonly OrderRepository _orderRepository;
        private readonly OrderRowRepository _orderRowRepository;
        private readonly CustomerRepository _customerRepository;
        private readonly SupplyRepository _supplyRepository;
        private readonly IRepository<Address> _addressRepository;
        private readonly ProductRepository _productRepository;

        public ManuallyCreatingOrderController()
        {
            _orderRepository = new OrderRepository();
            _orderRowRepository = new OrderRowRepository();
            _customerRepository = new CustomerRepository();
            _supplyRepository = new SupplyRepository();
            _addressRepository = new AddressRepository();
            _productRepository = new ProductRepository();
        }

        public ActionResult CustomerIndex()
        {
            var customers = _customerRepository.GetAll()
                .Where(x => x.AlcoholLicense.IsValid);

            return View(customers);
        }
        public ActionResult CreateOrder(int id)
        {
            var customer = _customerRepository.Find(id);

            var order = new Order()
            {
                Customer = customer,
                OrderPlaced = DateTime.Now,
                DesiredDeliveryDate = DateTime.Now

            };

            return View(order);

        }
        [HttpPost]
        public ActionResult CreateOrderManually(Order order)
        {
            order.Id = 0;
            order.CustomerId = order.Customer.Id;
            _orderRepository.Create(order);

            var viewModel = new ManualOrderViewModel()
            {
                Order = order,
                Products = new List<Product>()
            };

            return View(viewModel);
        }

        public ActionResult CreateOrderRowManually(int customerId, int orderId)
        {
            var viewModel = new ManualOrderViewModel()
            {
                Customer = _customerRepository.Find(customerId),
                Products = _productRepository.GetAll(),
                Order = _orderRepository.Find(orderId)
            };

            foreach (var product in viewModel.Products)
            {
                product.QuantiyInWarehouse = _productRepository.GetQuantityInWarehouse(product.Id);
                product.QuantiyOrdered = 0;
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateOrderRowManually(ManualOrderViewModel viewModel, int customerId, int orderId)
        {
            viewModel.Order = _orderRepository.Find(orderId);

            for (int i = 0; i < viewModel.Products.Count; i++)
            {
                if (viewModel.Products[i].QuantiyOrdered != 0)
                {
                    viewModel.Order.OrderRows.Add(new OrderRow()
                    {
                        AmountOrdered = (int)viewModel.Products[i].QuantiyOrdered,
                        OrderId = viewModel.Order.Id,
                        ProductId = viewModel.Products[i].Id,

                    });
                }

            }

            return View("CreateOrderManually", viewModel);
        }

    }
}