﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kundbolaget.EntityFramework.Contexts;
using Kundbolaget.EntityFramework.Repositories;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerRepository _customerRepository;
        private readonly DataRepository<Address> _addressRepository;
        private readonly DataRepository<Country> _countryRepository;
        private readonly DataRepository<Contact> _contactRepository;

        public CustomerController()
        {
            _customerRepository = new CustomerRepository();
            _addressRepository = new DataRepository<Address>();
            _countryRepository = new DataRepository<Country>();
            _contactRepository = new DataRepository<Contact>();
        }

        // GET: Customers
        public ActionResult Index()
        {
            return View(_customerRepository.GetAll());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _customerRepository.Find((int) id);
            customer.VisitingAddress.Country = _countryRepository.Find(customer.VisitingAddress.CountryId);
            customer.InvoiceAddress.Country = _countryRepository.Find(customer.InvoiceAddress.CountryId);

            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            
            var customer = new Customer()
            {
                InvoiceAddress = new Address(),
                VisitingAddress = new Address(),
                Contact = new Contact()

            };

            return View(customer);
        }

      
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }

            customer.Contact.Address = customer.VisitingAddress;
            _customerRepository.Create(customer);

            return RedirectToAction("Index");
         
        }

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _customerRepository.Find((int)id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

       
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            

            if (ModelState.IsValid)
            {
                _addressRepository.Update(customer.InvoiceAddress);
                _addressRepository.Update(customer.VisitingAddress);
                customer.Contact.AdressId = customer.VisitingAddressId;
                _contactRepository.Update(customer.Contact);
                _customerRepository.Update(customer);

                return RedirectToAction("Index");
            }
            return View(customer);
        }

        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _customerRepository.Find((int)id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _customerRepository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
