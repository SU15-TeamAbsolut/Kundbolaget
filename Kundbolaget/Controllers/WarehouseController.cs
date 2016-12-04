using Kundbolaget.EntityFramework.Repositories;
using Kundbolaget.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kundbolaget.Controllers
{
    public class WarehouseController : Controller
    {
        private IRepository<Warehouse> repository;

        public WarehouseController()
        {
            repository = new DataRepository<Warehouse>();
        }

        public ActionResult Index()
        {
            var model = repository.GetAll();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Warehouse model)
        {
            if (!ModelState.IsValid)
                return View(model);

            repository.Create(model);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var model = repository.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Warehouse model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            repository.Update(model);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var model = repository.Find(id);
            return View(model);
        }
    }
}