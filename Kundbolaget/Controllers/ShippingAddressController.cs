using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kundbolaget.EntityFramework.Contexts;
using Kundbolaget.EntityFramework.Repositories;
using Kundbolaget.Models.EntityModels;

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

        // GET: ShippingAddress
        public ActionResult Index()
        {
            var customers = _customerRepository.GetAll();

            return View(customers);
        }

        public ActionResult Create(int id)
        {
            
            

            return View();
        }
        [HttpPost]
        public ActionResult Create(Address address, int id)
        {
            address.Id = 0;
            var customer = _customerRepository.Find(id);

            


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
            var customer = _customerRepository.Find(id);
            return View(customer);
        }

    }
}