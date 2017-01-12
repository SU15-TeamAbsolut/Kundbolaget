﻿using System;
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
                .Where(x => x.AlcoholLicense != null && x.AlcoholLicense.IsValid);

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

            //if (!ModelState.IsValid)
            //{   
            //    return View(order);
            //}

            order.Id = 0;
            order.CustomerId = order.Customer.Id;
            
            

            return RedirectToAction("CreateOrderRowManually", order);
        }
        public ActionResult CreateOrderRowManually(Order order)
        {
            var viewModel = new ManualOrderViewModel()
            {
                Order = order,
                Products = _productRepository.GetAll(),
            };
            
            foreach (var product in viewModel.Products)
            {
                product.QuantiyInWarehouse = _productRepository.GetQuantityInWarehouse(product.Id);
                product.QuantiyOrdered = 0;
            }

            return View("CreateOrderRowManually", viewModel);
        }

        [HttpPost]
        public ActionResult CreateOrderRowManually(ManualOrderViewModel viewModel, Order order)
        {

            viewModel.Order = new Order()
            {
                
                CustomerOrderRef = viewModel.Order.CustomerOrderRef,
                OrderPlaced = DateTime.Now,
                DesiredDeliveryDate = viewModel.Order.DesiredDeliveryDate,
                OrderRows = new List<OrderRow>(),
                OrderStatus = OrderStatus.Registered
            };

            for (int i = 0; i < viewModel.Products.Count; i++)
            {
                if (viewModel.Products[i].QuantiyOrdered != 0)
                {
                    viewModel.Order.OrderRows.Add(new OrderRow()
                    {
                        AmountOrdered = (int)viewModel.Products[i].QuantiyOrdered,
                        OrderId = viewModel.Order.Id,
                        ProductId = viewModel.Products[i].Id,
                        Price = (decimal)(viewModel.Products[i].Price * viewModel.Products[i].QuantiyOrdered)
                    });
                }

            }

            return View("CreateOrderManually", viewModel);
        }

    }
}