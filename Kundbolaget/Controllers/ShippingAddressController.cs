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
        private readonly IRepository<Country> _countryRepository;

        public ShippingAddressController()
        {
            _customerRepository = new CustomerRepository();
            _addressRepository = new DataRepository<Address>();
            _countryRepository = new DataRepository<Country>();

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

        [HttpPost]
        public ActionResult Index(string command, int? selectedAddressId)
        {
            if (command.Equals("Visa adress"))
            {
                return RedirectToAction("Details", "ShippingAddress", new { id = selectedAddressId });
            }

            if (command.Equals("Ändra adress"))
            {
                return RedirectToAction("Edit", "ShippingAddress", new {id = selectedAddressId});
            }

            return RedirectToAction("Index");
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
       
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }

            var address = _addressRepository.Find((int)id);
            address.Country = _countryRepository.Find(address.CountryId);

            return View(address);
        }

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }
            var address = _addressRepository.Find((int)id);

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