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
        private readonly OrderRepository _orderRepository;
        private readonly OrderRowRepository _orderRowRepository;
        private readonly CustomerRepository _customerRepository;
        private readonly SupplyRepository _supplyRepository;
        private readonly IRepository<Address> _addressRepository;
        private readonly ProductRepository _productRepository;

        public OrderController()
        {
            _orderRepository = new OrderRepository();
            _orderRowRepository = new OrderRowRepository();
            _customerRepository = new CustomerRepository();
            _supplyRepository = new SupplyRepository();
            _addressRepository = new AddressRepository();
            _productRepository = new ProductRepository();
        }

        // GET: Order
        public ActionResult Index()
        {
            //var model = _orderRepository.GetAll();

            return View();
        }

        public ActionResult ReceivedOrders()
        {
            var orders = _orderRepository.GetAll();
            List<Order> model = new List<Order>();

            foreach (var order in orders)
            {
                if(order.OrderStatus == OrderStatus.Registered)
                    model.Add(order);
            }   
            return View(model);
        }

        public ActionResult ReadyForPicking(int id)
        {
            var order = _orderRepository.Find(id);
            order.OrderStatus = OrderStatus.Processing;
            _orderRepository.Update(order);

            return RedirectToAction("ReceivedOrders");

        }
        public ActionResult UnpickedOrders()
        {
            var orders = _orderRepository.GetAll();
            List<Order> model = new List<Order>();

            foreach (var order in orders)
            {
                if (order.OrderStatus == OrderStatus.Processing)
                    model.Add(order);
            }
            return View(model);
        }

        public ActionResult PickedOrders()
        {
            var orders = _orderRepository.GetAll();
            List<Order> model = new List<Order>();

            foreach (var order in orders)
            {
                if (order.OrderStatus == OrderStatus.ReadyToShip)
                    model.Add(order);
            }
            return View(model);
        }

        public ActionResult CanceledOrders()
        {
            var orders = _orderRepository.GetAll();
            List<Order> model = new List<Order>();

            foreach (var order in orders)
            {
                if (order.OrderStatus == OrderStatus.Cancelled)
                    model.Add(order);
            }
            return View(model);
        }
        
        public ActionResult Details(int id)
        {
            var orderRows = _orderRowRepository.GetAll(id);

            return View(orderRows);
        }
        public ActionResult ViewOrderRows(int id)
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
            if (!ModelState.IsValid )
            {
                model.Customer = _customerRepository.Find(model.CustomerId);
                model.ShippingAddress = _addressRepository.Find(model.ShippingAddressId);
                return View(model);
            }
            
            _orderRepository.Update(model);

            return  RedirectToAction("ReceivedOrders");
        }
        public ActionResult EditOrderRow(int id)
        {
            var orderRow = _orderRowRepository.GetOrderRow(id);
            //orderRow.Customer = _customerRepository.Find(order.CustomerId);
            return View(orderRow);
        }

        [HttpPost]
        public ActionResult EditOrderRow(OrderRow model)
        {
            _orderRowRepository.Update(model);
            return RedirectToAction("UnpickedOrders");
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
                    ShelfSpace = shelf.Position,
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
        public ActionResult ConfirmSend(int id)
        {
            var order = _orderRepository.Find(id);

            order.OrderStatus = OrderStatus.Shipping;
            _orderRepository.Update(order);

            return View(order);
        }
        public ActionResult ShippingDoc(int id)
        {
            var order = _orderRepository.Find(id);
            return View(order);
        }

        public ActionResult Delete(int id)
        {
            var order = _orderRepository.Find(id);
            order.OrderStatus = OrderStatus.Cancelled;
            _orderRepository.Update(order);
           
            return RedirectToAction("ReceivedOrders");
        }
    }
}