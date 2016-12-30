using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kundbolaget.EntityFramework.Repositories;
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
            if(model.ShippingAddress == null)


            _orderRepository.Update(model);

            return  RedirectToAction("Index");
        }

        public ActionResult PickingList(int id)
        {
            var orderRow = _orderRowRepository.GetAll(id);
            IList<PickingListViewModel> viewModels = new List<PickingListViewModel>();
            

            foreach (var row in orderRow)
            {
                var productShelves = _supplyRepository.FindByProduct(row.ProductId);
                var pickingListViewModel = new PickingListViewModel
                {
                    ProductId = row.ProductId,
                    ProductName = row.Product.Name,
                    AmountOrdered = row.AmountOrdered,
                    ShelfName = productShelves.Shelf.Name,
                    ShelfSpace = productShelves.Id,
                    Balance = productShelves.CurrentAmount
                    
                };
                viewModels.Add(pickingListViewModel);
            }
            
            return View(viewModels);
        }

    }
}