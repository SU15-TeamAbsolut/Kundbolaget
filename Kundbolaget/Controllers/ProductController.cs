using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Kundbolaget.EntityFramework.Repositories;
using Kundbolaget.Models.EntityModels;
using Kundbolaget.Models.ViewModels;

namespace Kundbolaget.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepository<ProductCategory> _productCategoryRepository;
        private readonly ProductRepository _productRepository;
        private readonly IRepository<ProductPrice> priceRepository;
        private readonly ProductShelfRepository shelfRepository;

        public ProductController()
        {
            _productRepository = new ProductRepository();
            _productCategoryRepository = new DataRepository<ProductCategory>();
            priceRepository = new DataRepository<ProductPrice>();
            shelfRepository = new ProductShelfRepository();
        }

        // GET: Product/Index
        public ActionResult Index()
        {
            IList<Product> products = _productRepository.GetAll();
            var productVmList = new List<ProductListItemViewModel>();

            // Turn products into view model items
            foreach (var product in products)
            {
                productVmList.Add(ProductListItemViewModel.FromProduct(product));
            }

            var viewModel = new ProductCategoryViewModel
            {
                ProductCategories = _productCategoryRepository.GetAll(),
                Products = productVmList
            };

            // Fetch product stock
            foreach (var product in viewModel.Products)
            {
                product.CurrentStock = shelfRepository.GetProductStock(product.Id);
            }
            
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(ProductCategoryViewModel categoryModel)
        {
            int id = categoryModel.ProductCategory.Id;
            List<ProductListItemViewModel> productList;

            if (id == 0)
            {
                productList = (List<ProductListItemViewModel>) _productRepository.GetAll();
            }
            else
            {
                productList = (List<ProductListItemViewModel>) _productRepository.GetAll()
                   .Where(x => x.ProductCategoryId == id);
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
                viewModel.ProductCategories = _productCategoryRepository.GetAll();
                return View(viewModel);
            }
            var model =_productRepository.CreateModel(viewModel);
            _productRepository.Create(model);

            return RedirectToAction("Index");
        }

        // GET: Product/Edit/{id}
        public ActionResult Edit(int id)
        {
           

            var viewModel = new ProductCategoryViewModel()
            {
                Product = _productRepository.Find(id),
                ProductCategories = _productCategoryRepository.GetAll()
            };


            return View(viewModel);
        }

        // POST: Product/Index/{model}
        [HttpPost]
        public ActionResult Edit(ProductCategoryViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.ProductCategories = _productCategoryRepository.GetAll();
                return View(viewModel);
            }

            var model = _productRepository.CreateModel(viewModel);

            model.Id = viewModel.Product.Id;
            _productRepository.Update(model);

            return RedirectToAction("Index");
        }

        // GET: Product/Details/{id}
        public ActionResult Details(int id)
        {
            var model = _productRepository.Find(id);
            int categoryId = model.ProductCategoryId;
            model.ProductCategory = _productCategoryRepository.Find(categoryId);
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

        // GET: Product/AddPrice/{id}
        public ActionResult AddPrice(int id)
        {
            Product product = _productRepository.Find(id);

            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            var model = new ProductPrice
            {
                Product = product,
                ProductId = product.Id,
                StartDate = DateTime.Now
            };

            return View(model);
        }

        // POST: Product/AddPrice/
        [HttpPost]
        public ActionResult AddPrice(ProductPrice item)
        {
            Product product = _productRepository.Find(item.ProductId);

            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // TODO: Workaround, new price gets the product's id from the form for some reason
            item.Id = 0;

            priceRepository.Create(item);

            return new RedirectResult($"/Product/{item.ProductId}");
        }
    }
}