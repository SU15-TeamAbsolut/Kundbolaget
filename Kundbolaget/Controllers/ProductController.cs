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
        private readonly ProductRepository _productRepository;
        // GET: Product
        public ProductController()
        {
            _productRepository = new ProductRepository();
            _productCategoryRepository = new DataRepository<ProductCategory>();
        }

        // GET: Product/Index
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
        public ActionResult Index(ProductCategoryViewModel categoryModel)
        {
            int id = categoryModel.ProductCategory.Id;
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
            var viewModel = new ProductCategoryViewModel()
            {
                ProductCategories = _productCategoryRepository.GetAll(),
                ProductCategory = new ProductCategory()
            };

            return View(viewModel);
        }

        // POST: Product/Create/{model}
        [HttpPost]
        public ActionResult Create(ProductCategoryViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            _productRepository.CreateProduct(viewModel);

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