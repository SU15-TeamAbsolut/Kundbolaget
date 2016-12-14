using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kundbolaget.EntityFramework.Repositories;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.Controllers
{
    public class OrderController : Controller
    {
        private IRepository<Order> _orderRepository;
        private OrderRowRepository _orderRowRepository;
        private CustomerRepository _customerRepository;

        public OrderController()
        {
            _orderRepository = new OrderRepository();
            _orderRowRepository = new OrderRowRepository();
            _customerRepository = new CustomerRepository();
        }

        // GET: Order
        public ActionResult Index()
        {
            var model = _orderRepository.GetAll();

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var orderRows = _orderRowRepository.FindAll(id);

            return View(orderRows);
        }

        public ActionResult Edit(int id)
        {
            var order = _orderRepository.Find(id);
            order.Customer = _customerRepository.Find(order.CustomerId);
            return View(order);
        }

        [HttpPost]
        public ActionResult Edit(Order model)
        {
            _orderRepository.Update(model);

            return  RedirectToAction("Index");
        }

    }
}