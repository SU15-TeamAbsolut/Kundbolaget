using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kundbolaget.EntityFramework.Contexts;
using Kundbolaget.EntityFramework.Repositories;
using Kundbolaget.Enums;
using Kundbolaget.Models.EntityModels;
using Kundbolaget.Models.ViewModels;

namespace Kundbolaget.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderRepository _orderRepository;
        private readonly ProductRepository _productRepository;
        private readonly IRepository<ProductCategory> _productCategoryRepository;
        private readonly OrderRowRepository _orderRowRepository;
        private readonly CustomerRepository _customerRepository;
        private readonly SupplyRepository _supplyRepository;
        private readonly IRepository<Address> _addressRepository;
        private readonly ProductShelfRepository shelfRepository;

        public OrderController()
        {
            _orderRepository = new OrderRepository();
            _productRepository = new ProductRepository();
            _productCategoryRepository = new DataRepository<ProductCategory>();
            _orderRowRepository = new OrderRowRepository();
            _customerRepository = new CustomerRepository();
            _supplyRepository = new SupplyRepository();
            _addressRepository = new AddressRepository();
            _productRepository = new ProductRepository();
            shelfRepository = new ProductShelfRepository();
        }

        // GET: Order
        public ActionResult Index()
        {
            var orders = _orderRepository.GetAll();

            return View(orders);
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
            foreach (var order in model)
            {
                foreach (var row in order.OrderRows)
                {
                    row.AmountShipped = row.AmountOrdered;
                    if (row.AmountOrdered >= 20)
                        row.Discount = 0.08m;
                    _orderRowRepository.Update(row);
                }

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
            foreach (var row in orderRows)
            {
                if (row.AmountOrdered >= 20)
                {
                    row.Discount = 0.08m;
                }
                else
                {
                    row.Discount = 0;
                }
            }
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
            
            return View(orderRow);
        }

        [HttpPost]
        public ActionResult EditOrderRow(OrderRow model)
        {
            if (model.AmountOrdered >= 20)
            {
                model.Discount = (decimal)0.08;
            }
            else
            {
                model.Discount = 0;
            }
            var orders = _orderRepository.GetAll();
            var order = orders.SingleOrDefault(o => o.Id == model.OrderId);
            _orderRowRepository.Update(model);
            return RedirectToAction("Details", new {id = order.Id});
        }

        //For deviation edit
        public ActionResult EditDeviationOrderRow(int id)
        {
            var orderRow = _orderRowRepository.GetOrderRow(id);

            return View(orderRow);
        }

        [HttpPost]
        public ActionResult EditDeviationOrderRow(OrderRow model)
        {
            var orders = _orderRepository.GetAll();
            var order = orders.SingleOrDefault(o => o.Id == model.OrderId);
            _orderRowRepository.Update(model);
            return RedirectToAction("Deviations", new { id = order.Id });
        }

        public ActionResult AddOrderRow(int? id)
        {
            IList<Product> products = _productRepository.GetAll();
            var productVmList = new List<ProductListItemViewModel>();

            // Turn products into view model items
            foreach (var product in products)
            {
                productVmList.Add(ProductListItemViewModel.FromProduct(product));
            }

            var viewModel = new ProductCategoryViewModel
            {
                ProductCategories = _productCategoryRepository.GetAll(),
                Products = productVmList,
                OrderId = id
            };

            // Fetch product stock
            foreach (var product in viewModel.Products)
            {
                product.CurrentStock = shelfRepository.GetProductStock(product.Id);
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddOrderRow(ProductCategoryViewModel categoryModel, int? orderId)
        {
            int id = categoryModel.ProductCategory.Id;
            List<ProductListItemViewModel> productList;

            if (id == 0)
            {
                productList = _productRepository.GetAll()
                   .Select(ProductListItemViewModel.FromProduct)
                   .ToList();
            }
            else
            {
                productList = _productRepository.GetAll()
                   .Where(x => x.ProductCategoryId == id)
                   .Select(ProductListItemViewModel.FromProduct)
                   .ToList();
            }

            var viewModel = new ProductCategoryViewModel()
            {
                Products = productList,
                ProductCategories = _productCategoryRepository.GetAll(),
                ProductCategory = new ProductCategory(),
                OrderId = orderId
                
            };
            foreach (var product in viewModel.Products)
            {
                product.CurrentStock = shelfRepository.GetProductStock(product.Id);
            }

            return View(viewModel);
        }

        public ActionResult PickAmount(int productId, int orderId)
        {
            var product = _productRepository.Find(productId);

            var viewModel = new AddOrderRowViewModel()
            {
                OrderId = orderId,
                ProductId = productId,
                ProductName = product.Name,
                Price = product.Price,
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult PickAmount(AddOrderRowViewModel model)
        {
            decimal discount = 0;
            if (model.Amount >= 20)
                discount = (decimal)0.08;
            var order = _orderRepository.Find(model.OrderId);
            OrderRow orderRow = new OrderRow()
            {
                OrderId = model.OrderId,
                ProductId = model.ProductId,
                AmountOrdered = model.Amount,
                Price = model.Price,
                Discount = discount
                
            };
            using (var db = new DataContext())
            {
                db.Orders.Attach(order);
                order.OrderRows.Add(orderRow);
                db.SaveChanges();
            }
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
            if (order.OrderStatus == OrderStatus.Processing)
            {
                order.OrderStatus = OrderStatus.Cancelled;
                _orderRepository.Update(order);

                return RedirectToAction("UnpickedOrders");
            }

            order.OrderStatus = OrderStatus.Cancelled;
            _orderRepository.Update(order);
           
            return RedirectToAction("ReceivedOrders");
        }

        public ActionResult ConfirmDelete(int id)
        {
            var order = _orderRepository.Find(id);
            return View(order);
        }

        public ActionResult ShippedOrders()
        {
            var orders = _orderRepository.GetAll();
            var model = orders.Where(x => x.OrderStatus == OrderStatus.Shipping).ToList();
            return View(model);
        }

        public ActionResult Delivered(int id)
        {
            var order = _orderRepository.Find(id);
            order.OrderStatus = OrderStatus.Delivered;
            order.OrderPlaced = DateTime.Now;
            _orderRepository.Update(order);
            return RedirectToAction("ShippedOrders");
        }

        public ActionResult DeliveredOrders()
        {
            var orders = _orderRepository.GetAll();
            var model = orders.Where(x => x.OrderStatus == OrderStatus.Delivered).ToList();
            return View(model);
        }

        public ActionResult Deviations(int id)
        {
            var orderRows = _orderRowRepository.GetAll(id);

            return View(orderRows);
        }
    }
}