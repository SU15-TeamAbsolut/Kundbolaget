using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kundbolaget.EntityFramework.Repositories;
using Kundbolaget.Models.EntityModels;
using Kundbolaget.ViewModels;

namespace Kundbolaget.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepository<ProductCategory> _productCategoryRepository;
        private readonly IRepository<Product> _productRepository;
        // GET: Product
        public ProductController()
        {
            _productRepository = new DataRepository<Product>();
            _productCategoryRepository = new DataRepository<ProductCategory>();
        }

        public ActionResult Index()
        {

            var viewModel = new ProductCategoryViewModel()
            {
                Products = _productRepository.GetAll(),
                ProductCategories = _productCategoryRepository.GetAll(),
                ProductCategory = new ProductCategory()
            };
            
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            int id = 0;
            int.TryParse(Request["ProductCategory"], out id);
            List<Product> productList;

            if (id == 0)
            {
                productList = _productRepository.GetAll().ToList();
            }
            else
            {
                productList = _productRepository.GetAll()
                   .Where(x => x.ProductCategoryId == id).ToList();
            }
                
            var viewModel = new ProductCategoryViewModel()
            {
                Products = productList,
                ProductCategories = _productCategoryRepository.GetAll(),
                ProductCategory = new ProductCategory()
            };

            return View(viewModel);
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