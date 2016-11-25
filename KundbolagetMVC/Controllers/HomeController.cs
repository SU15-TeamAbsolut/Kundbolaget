using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCMS.EntityFramework.Repositories;

namespace MVCCMS.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository repository;

        public HomeController()
        {
            repository = new DbStoreRepository();
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}