using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kundbolaget.EntityFramework.Repositories;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.Controllers
{
    public class CategoryController : Controller
    {
     
        private readonly IRepository<Category> _categoryRepository;
        // GET: Product
        public CategoryController()
        {
            _categoryRepository = new DataRepository<Category>();
        }

        public ActionResult Index()
        {
            var model = _categoryRepository.GetAll();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _categoryRepository.Create(model);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var model = _categoryRepository.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Category model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _categoryRepository.Update(model);

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var model = _categoryRepository.Find(id);
            return View(model);
        }
    }
}