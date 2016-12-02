using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kundbolaget.EntityFramework.Repositories;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.Controllers
{
    public class AlcoholLicenseController : Controller
    {
        private IRepository<AlcoholLicense> repository;

        public AlcoholLicenseController()
        {
            repository = new DataRepository<AlcoholLicense>();
        } 

        // GET: AlcoholLicense
        public ActionResult Index()
        {
            var model = repository.GetAll();
            return View();
        }

        //GET: AlcoholLicense/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: AlcoholLicense/Create/
        public ActionResult Create(AlcoholLicense model)
        {
            if (!ModelState.IsValid)
                return View(model);

            repository.Create(model);
            return RedirectToAction("Index");
        }

        //GET: AlcoholLicense/Edit{id}
        public ActionResult Edit(int id)
        {
            var model = repository.Find(id);
            return View(model);
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