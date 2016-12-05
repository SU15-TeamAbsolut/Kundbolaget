using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kundbolaget.EntityFramework.Repositories;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepository<Product> _productRepository;
        // GET: Product
        public ProductController()
        {
            _productRepository = new DataRepository<Product>();
        }

        public ActionResult Index()
        {
            var model = _productRepository.GetAll();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _productRepository.Create(model);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var model =_productRepository.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Product model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _productRepository.Update(model);

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var model = _productRepository.Find(id);
            return View(model);
        }
    }
}