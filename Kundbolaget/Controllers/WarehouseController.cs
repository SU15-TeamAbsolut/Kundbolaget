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
        private readonly WarehouseRepository _warehouseRepository;
        private readonly IRepository<Address> _addressRepository;
        private readonly IRepository<Country> _countryRepository;

        public WarehouseController()
        {
            _warehouseRepository = new WarehouseRepository();
            _addressRepository = new DataRepository<Address>();
            _countryRepository = new DataRepository<Country>();
        }

        public ActionResult Index()
        {
            var warehouses = _warehouseRepository.GetAll();

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
                warehouse.Address = address;
                return View(warehouse);

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

            var model = _warehouseRepository.Find(id);

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
            _addressRepository.Update(adressModel);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var model = _warehouseRepository.Find(id);
            model.Address.Country = _countryRepository.Find(model.Address.CountryId);
            return View(model);
        }
    }
}