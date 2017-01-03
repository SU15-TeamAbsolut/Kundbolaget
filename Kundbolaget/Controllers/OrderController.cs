using System;
using System.Collections;
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
    public class OrderController : Controller
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly OrderRowRepository _orderRowRepository;
        private readonly CustomerRepository _customerRepository;
        private readonly SupplyRepository _supplyRepository;
        

        public OrderController()
        {
            _orderRepository = new OrderRepository();
            _orderRowRepository = new OrderRowRepository();
            _customerRepository = new CustomerRepository();
            _supplyRepository = new SupplyRepository();
        }

        // GET: Order
        public ActionResult Index()
        {
            var model = _orderRepository.GetAll();

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var orderRows = _orderRowRepository.GetAll(id);

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
            if (model.ShippingAddressId == 0)
            {
                var o = _orderRepository.Find(model.Id);
                model.ShippingAddressId = o.ShippingAddressId;
            }


            _orderRepository.Update(model);

            return  RedirectToAction("Index");
        }

        public ActionResult PickingList(int id)
        {
            IList<OrderRow> orderRows = _orderRowRepository.GetAll(id);
            var pickRows = new List<PickListRow>();
            
            foreach (var orderRow in orderRows)
            {
                var shelf = _supplyRepository.FindByProduct(orderRow.ProductId);
                pickRows.Add(new PickListRow
                {
                    ProductId = orderRow.ProductId,
                    ProductName = orderRow.Product.Name,
                    AmountOrdered = orderRow.AmountOrdered,
                    ShelfName = shelf.Shelf.Name,
                    ShelfSpace = shelf.Id,
                    Balance = shelf.CurrentAmount
                });
            }

            var viewModel = new PickListViewModel
            {
                OrderId = id,
                OrderRows = pickRows
            };

            return View(viewModel);
        }

        // POST: Order/ConfirmPick
        [HttpPost]
        public ActionResult ConfirmPick(FormCollection form)
        {
            int orderId = int.Parse(form["OrderId"]);
            var order = _orderRepository.Find(orderId);

            order.OrderStatus = OrderStatus.ReadyToShip;
            _orderRepository.Update(order);

            // Remove from stock
            foreach (var row in order.OrderRows)
            {
                var shelf = _supplyRepository.FindByProduct(row.ProductId);
                shelf.CurrentAmount -= row.AmountOrdered;
                _supplyRepository.Update(shelf);
            }

            return View(order);
        }
    }
}