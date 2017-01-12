using Kundbolaget.EntityFramework.Repositories;
using Kundbolaget.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kundbolaget.EntityFramework.Contexts;
using Kundbolaget.Models.ViewModels;

namespace Kundbolaget.Controllers
{
    public class WarehouseController : Controller
    {
        private readonly IRepository<Warehouse> _warehouseRepository;
        private readonly AddressRepository _warehouseAddressRepository;
        private readonly IRepository<Shelf> shelfRepository;
        private readonly ProductShelfRepository productShelfRepository;
        private readonly ProductShelfChangeLogRepository logRepository;
        public static int currentWarehouseId = 0;
        public static int currentShelfId = 0;

        public WarehouseController()
        {
            _warehouseRepository = new DataRepository<Warehouse>();
            _warehouseAddressRepository = new AddressRepository();
            shelfRepository = new DataRepository<Shelf>();
            productShelfRepository = new ProductShelfRepository();
            logRepository = new ProductShelfChangeLogRepository();
        }

        public ActionResult Index()
        {
            var warehouses = _warehouseAddressRepository.GetWarehousesWithAddress();

            return View(warehouses);
        }

        public ActionResult Create()
        {
            var warehouse = new Warehouse()
            {
                Address = new Address()
            };

            return View(warehouse);
        }

        [HttpPost]
        public ActionResult Create(Warehouse warehouse, Address address)
        {

            if (!ModelState.IsValid)
            {
                warehouse.Address = address;
                return View(warehouse);

            }
                

            var newWarehouse = new Warehouse()
            {
                Address = address,
                Name = warehouse.Name,
                ContactId = warehouse.ContactId

            };


            _warehouseRepository.Create(newWarehouse);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {

            var model = _warehouseAddressRepository.GetWarehouseWithAddress(id);

            currentWarehouseId = id;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Warehouse warehouseModel, Address adressModel)
        {
            if (!ModelState.IsValid)
            {
                return View(warehouseModel);
            }
            adressModel.Id = warehouseModel.AddressId;
            warehouseModel.Address = adressModel;
            _warehouseRepository.Update(warehouseModel);
            _warehouseAddressRepository.Update(adressModel);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var model = _warehouseAddressRepository.GetWarehouseWithAddress(id);
           
            return View(model);
        }








        //--------------SHELFS----------------------







        public ActionResult CreateShelf()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateShelf(Shelf model)
        {
            if (!ModelState.IsValid) return View(model);
            model.WarehouseId = currentWarehouseId;
            shelfRepository.Create(model);
            return RedirectToAction("Edit/" + currentWarehouseId);
        }

        public ActionResult EditShelf(int id)
        {
            currentShelfId = id;
            var shelf = shelfRepository.Find(id);
            var model = new ShelfWithProducts
            {
                Id = shelf.Id,
                Name = shelf.Name,
                Products = productShelfRepository.GetProductsShelvesByShelfId(id)
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult EditShelf(ShelfWithProducts shelf)
        {
            if (!ModelState.IsValid) return View(shelf);
            var model = shelfRepository.Find(shelf.Id);
            model.Name = shelf.Name;
            shelfRepository.Update(model);
            return RedirectToAction("Edit/" + currentWarehouseId);
        }

        public ActionResult ShelfDetails(int id)
        {
            //var model = shelfRepository.Find(id);
            //return View(model);
            var shelf = shelfRepository.Find(id);
            var model = new ShelfWithProducts
            {
                Id = shelf.Id,
                Name = shelf.Name,
                Products = productShelfRepository.GetProductsShelvesByShelfId(id)
            };
            return View(model);
        }





        //----------------------PRODUCTSHELF---------------------------







        public ActionResult CreateProductShelf()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProductShelf(ProductShelf model)
        {
            if (!ModelState.IsValid) return View(model);
            model.ShelfId = currentShelfId;
            productShelfRepository.Create(model);
            return RedirectToAction("EditShelf/" + currentShelfId);
        }

        public ActionResult EditProductShelf(int id)
        {
            var model = productShelfRepository.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditProductShelf(ProductShelf model)
        {
            if (!ModelState.IsValid) return View(model);
            model.ShelfId = currentShelfId;
            productShelfRepository.Update(model);
            return RedirectToAction("EditShelf/" + currentShelfId);
        }







        //------------------ProductShelfChangeLog--------------



        public ActionResult LogIndex()
        {
            var logs = logRepository.GetLogsByWarehouseId(currentWarehouseId);
            return View(logs);
        }

        public ActionResult CreateLog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateLog(ProductShelfChangeLog model)
        {
            if (!ModelState.IsValid) return View(model);
            model.Date = DateTime.Now;
            var productShelf = productShelfRepository.FindByProductIdAndShelfId(model.ProductId, model.ShelfId);
            if (productShelf != null)
            {
                productShelf.CurrentAmount -= model.Amount;
                productShelfRepository.Update(productShelf);
                logRepository.Create(model);
                return RedirectToAction("LogIndex");
            }
            else return View(model);
        }

        public ActionResult LogDetails(int id)
        {
            var model = logRepository.FindAndInclude(id);
            return View(model);
        }
    }
}