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
    public class SupplierController : Controller
    {
        private readonly IRepository<Supplier> _repository;
        private readonly IRepository<Address> _addressRepository;
        private readonly AddressRepository _supplierAddressRepository;

        public SupplierController()
        {
            _repository = new DataRepository<Supplier>();
            _addressRepository = new DataRepository<Address>();
            _supplierAddressRepository = new AddressRepository();
        }

        // GET: Supplier
        public ActionResult Index()
        {
            var model = _supplierAddressRepository.GetSuppliersWithAddresses();
            
            return View(model);
        }

        // GET: Supplier/Create
        public ActionResult Create()
        {
            var model = new Supplier()
            {
                Address = new Address()
            };

            return View(model);
        }

        // POST: Supplier/Create/
        [HttpPost]
        public ActionResult Create(Supplier model, Address address)
        {
            model.Address = address;

            if (!ModelState.IsValid)
                return View(model);

            _repository.Create(model);

            return RedirectToAction("Index");
        }

        // GET: Supplier/Edit/{id}
        public ActionResult Edit(int id)
        {
            var model = _supplierAddressRepository.GetSupplierWithAddresses(id);
            return View(model);
        }

        // POST: Supplier/Edit/{id}
        [HttpPost]
        public ActionResult Edit(Supplier model, Address address)
        {
            address.Id = model.AddressId;
            model.Address = address;

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _repository.Update(model);
            _addressRepository.Update(address);
            
            return RedirectToAction("Index");
        }

        // GET: Supplier/Details/{id}
        public ActionResult Details(int id)
        {
            var model = _supplierAddressRepository.GetSupplierWithAddresses(id);
            return View(model);
        }
    }
}