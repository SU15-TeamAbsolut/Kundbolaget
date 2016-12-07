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
        private IRepository<Supplier> repository;
        private IRepository<Address> addressRepository;

        public SupplierController()
        {
            repository = new DataRepository<Supplier>();
            addressRepository = new DataRepository<Address>();
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
            IEnumerable<SelectListItem> addressList = addressRepository.GetAll()
                .Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Street

                });

            var viewModel = new CreateSupplierViewModel
            {
                AddressList = addressList
            };

            return View(viewModel);
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