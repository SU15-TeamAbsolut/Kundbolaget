using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kundbolaget.EntityFramework.Repositories;
using Kundbolaget.Models.EntityModels;
using Portable.Licensing.Validation;

namespace Kundbolaget.Controllers
{
    public class AlcoholLicenseController : Controller
    {
        private IRepository<AlcoholLicense> repository;
        private readonly CustomerRepository _customerRepository;

        public AlcoholLicenseController()
        {
            repository = new DataRepository<AlcoholLicense>();
            _customerRepository = new CustomerRepository();
        } 

        // GET: AlcoholLicense
        public ActionResult Index()
        {
            var model = _customerRepository.GetCustomersAlcoLicenses();
            return View(model);
        }

        //GET: AlcoholLicense/Create
        public ActionResult Create(int id)
        {
            var customer = _customerRepository.Find(id);
            return View(customer.AlcoholLicense);
        }


        //POST: AlcoholLicense/Create/
        [HttpPost]
        public ActionResult Create(AlcoholLicense model)
        {
            var alcoModel = new AlcoholLicense
            {
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                IsActive = true
            };

            if (!alcoModel.IsValid)
                return View(model);

            repository.Create(alcoModel);
            var customer = _customerRepository.Find(model.Id);
            customer.AlcoholLicenseId = alcoModel.Id;
            _customerRepository.Update(customer);
            return RedirectToAction("Index");
        }

        //GET: AlcoholLicense/Edit{id}
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
               return RedirectToAction("Index");
            }

            var license = repository.Find((int) id);

            return View(license);
        }

        // POST: AlcoholLicense/Edit/{id}
        [HttpPost]
        public ActionResult Edit(AlcoholLicense model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            repository.Update(model);
            return RedirectToAction("Index");
        }

        // GET: AlcoholLicense/Details/{id}
        public ActionResult Details(int id)
        {
            var model = repository.Find(id);
            return View(model);
        }
    }
}