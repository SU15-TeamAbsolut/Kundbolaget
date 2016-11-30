﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kundbolaget.EntityFramework.Repositories;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.Controllers
{
    public class SupplierController : Controller
    {
        private IRepository<Supplier> repository;

        public SupplierController()
        {
            repository = new DataRepository<Supplier>();
        } 

        // GET: Supplier
        public ActionResult Index()
        {
            var model = repository.GetAll();
            return View(model);
        }

        // GET: Supplier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Supplier/Create/
        [HttpPost]
        public ActionResult Create(Supplier model)
        {
            if (!ModelState.IsValid)
                return View(model);

            repository.Create(model);

            return RedirectToAction("Index");
        }

        // GET: Supplier/Edit/{id}
        public ActionResult Edit(int id)
        {
            var model = repository.Find(id);
            return View(model);
        }

        // POST: Supplier/Edit/{id}
        [HttpPost]
        public ActionResult Edit(Supplier model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            repository.Update(model);
            return RedirectToAction("Index");
        }

        // GET: Supplier/Details/{id}
        public ActionResult Details(int id)
        {
            var model = repository.Find(id);
            return View(model);
        }
    }
}