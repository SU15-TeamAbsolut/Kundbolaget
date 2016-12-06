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
        private readonly ProductRepository _productRepository;

        // GET: Product
        public ProductController()
        {
            _productRepository = new ProductRepository();
        }

        // GET: Product/Index
        public ActionResult Index()
        {
            var model = _productRepository.GetAll();

            return View(model);
        }

        // GET: Product/Create    
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create/{model}
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

        // GET: Product/Edit/{id}
        public ActionResult Edit(int id)
        {
            var model =_productRepository.Find(id);
            return View(model);
        }

        // POST: Product/Index/{model}
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

        // GET: Product/Details/{id}
        public ActionResult Details(int id)
        {
            var model = _productRepository.Find(id);
            return View(model);
        }

        // GET: Product/Search
        public ActionResult Search()
        {
            IEnumerable<Product> model = new List<Product>();
            return View(model);
        }

        // POST: Product/Search/{searchTerm}
        [HttpPost]
        public ActionResult Search(FormCollection searchForm)
        {
            string searchString = searchForm["value"];
            IList<Product> model = _productRepository.SearchByName(searchString);

            return View(model);
        }
    }
}