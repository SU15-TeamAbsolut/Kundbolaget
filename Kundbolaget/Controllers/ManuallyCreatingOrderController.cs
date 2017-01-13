using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kundbolaget.EntityFramework.Repositories;
using Kundbolaget.Enums;
using Kundbolaget.Models.EntityModels;
using Kundbolaget.Models.ViewModels;

namespace Kundbolaget.Controllers
{
    public class ManuallyCreatingOrderController : Controller
    {
        private readonly OrderRepository _orderRepository;
        private readonly OrderRowRepository _orderRowRepository;
        private readonly CustomerRepository _customerRepository;
        private readonly ProductRepository _productRepository;

        public ManuallyCreatingOrderController()
        {
            _orderRepository = new OrderRepository();
            _orderRowRepository = new OrderRowRepository();
            _customerRepository = new CustomerRepository();
            _productRepository = new ProductRepository();
        }

        public ActionResult CustomerIndex()
        {
            var customers = _customerRepository.GetAll();
                

            return View(customers);
        }
        public ActionResult CreateOrder(int id)
        {
            var customer = _customerRepository.Find(id);

            var order = new Order()
            {
                CustomerOrderRef = null,
                Customer = customer,
                OrderPlaced = DateTime.Now,
                DesiredDeliveryDate = DateTime.Now,
            };

            return View("CreateOrder", order);

        }
        [HttpPost]
        public ActionResult CreateOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                order.Customer = _customerRepository.Find(order.Customer.Id);
                return View(order);
            }

            order.Id = 0;
            order.CustomerId = order.Customer.Id;
            
            

            return RedirectToAction("CreateOrderRowManually", order);
        }
        public ActionResult CreateOrderRowManually(Order order)
        {
            order.OrderStatus = OrderStatus.Registered;
            _orderRepository.Create(order);

            var viewModel = new ManualOrderViewModel()
            {
                Order = order,
                Products = _productRepository.GetAll(),
            };

            foreach (var product in viewModel.Products)
            {
                product.QuantiyInWarehouse = _productRepository.GetQuantityInWarehouse(product.Id);
                product.QuantiyOrdered = null;
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateOrderRowManually(ManualOrderViewModel viewModel, int orderId)
        {

            var newOrder = _orderRepository.Find(orderId);

            for (int i = 0; i < viewModel.Products.Count; i++)
            {
                if (viewModel.Products[i].QuantiyOrdered != 0 && viewModel.Products[i].QuantiyOrdered != null)
                {
                    newOrder.OrderRows.Add(new OrderRow()
                    {
                        AmountOrdered = (int)viewModel.Products[i].QuantiyOrdered,
                        OrderId = newOrder.Id,
                        ProductId = viewModel.Products[i].Id,
                        Price = _productRepository.Find(viewModel.Products[i].Id).Price * (int)viewModel.Products[i].QuantiyOrdered
                    });
                    
                }

            }
            foreach (var row in newOrder.OrderRows)
            {
                _orderRowRepository.Create(row);
            }
            foreach(var row in newOrder.OrderRows)
            {
                row.Price = _productRepository.Find(row.ProductId).Price;
            }
            

            
            

                return RedirectToAction("ReceivedOrders","Order");
        }

    }
}