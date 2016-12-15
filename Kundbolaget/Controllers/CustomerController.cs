using System;
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

        public CustomerController()
        {
            _customerRepository = new CustomerRepository();
            _addressRepository = new DataRepository<Address>();
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
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            var customer = new Customer()
            {
                VisitingAddress = new Address()
            };

            return View(customer);
        }

      
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Name,Password,CreditLine,PaymentTerm,AccountingCode,OrganizationNumber")] Customer customer, Address address)
        {
            if (ModelState.IsValid)
            {
                customer.VisitingAddress = address;
                _customerRepository.Create(customer);

                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
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

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer, Address adress)
        {
            if (ModelState.IsValid)
            {
                adress.Id = customer.VisitingAddressId;
               
                customer.VisitingAddress = adress;
                _addressRepository.Update(adress);
                _customerRepository.Update(customer);
               
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
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
