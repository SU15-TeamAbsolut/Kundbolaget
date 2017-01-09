using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kundbolaget.EntityFramework.Contexts;
using Kundbolaget.EntityFramework.Repositories;
using Kundbolaget.Models.EntityModels;
using Kundbolaget.Models.ViewModels;

namespace Kundbolaget.Controllers
{
   

    public class ShippingAddressController : Controller
    {
        private readonly DataRepository<Customer> _customerRepository;
        private readonly IRepository<Address> _addressRepository;

        public ShippingAddressController()
        {
            _customerRepository = new CustomerRepository();
            _addressRepository = new DataRepository<Address>();

        }

        public ActionResult Index()
        {
            var viewModel = new ShippingAdressViewModel()
            {
                Customer = new Customer(),
                Customers = _customerRepository.GetAll(),
                Address = new Address(),
            };
            return View(viewModel);
        }

        public ActionResult Create(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Address address, int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }

            address.Id = 0;
            var customer = _customerRepository.Find((int)id);

            using (var db = new DataContext())
            {
                db.Customers.Attach(customer);
                customer.ShippingAddresses.Add(address);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var viewModel = new ShippingAdressViewModel()
            {
                Customer = _customerRepository.Find(id),
                Address = new Address()
            };
        
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Details(ShippingAdressViewModel model,int customerId)
        {
            var adress = _addressRepository.Find(model.Address.Id);
            model.Customer = _customerRepository.Find(customerId);
            model.Address = adress;

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? selectedAddressId)
        {
            if (!selectedAddressId.HasValue)
            {
                return RedirectToAction("Index");
            }
            var address = _addressRepository.Find((int)selectedAddressId);

            return View(address);
        }
        [HttpPost]
        public ActionResult Edit(Address adress)
        {
            if (!ModelState.IsValid)
            {
                return View(adress);
            }
            _addressRepository.Update(adress);
            return RedirectToAction("Index");
        }
    }
}