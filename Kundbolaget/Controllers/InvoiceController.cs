using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kundbolaget.EntityFramework.Repositories;
using Kundbolaget.Enums;
using Kundbolaget.Models.EntityModels;
using Kundbolaget.Models.ViewModels.Invoice;

namespace Kundbolaget.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly CustomerRepository customerRepository;

        public InvoiceController()
        {
            customerRepository = new CustomerRepository();
        }

        // GET: Invoice
        public ActionResult Index()
        {
            return View();
        }

        // GET: Invoice/Create/{id}
        public ActionResult Create(int? id)
        {
            // No id, select a customer to invoice
            if (id == null)
            {
                IList<InvoicableCustomerViewModel> customers = customerRepository.GetAll()
                    .Select(InvoicableCustomerViewModel.FromCustomer)
                    .ToList();
                return View("Create_SelectCustomer", customers);
            }

            // id given, select orders to invoice
            var customer = customerRepository.Find(id.Value);
            if (customer == null)
            {
                return new HttpNotFoundResult();
            }

            var model = new CreateInvoiceViewModel
            {
                Customer = customer,
                InvoicableOrders = customer.Orders
                    .Where(o => o.OrderStatus == OrderStatus.Delivered)
                    .ToList()                
            };

            return View(model);
        }

        /// <summary>
        /// Accepts a form to create a new invoice with selected orders
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(CreateInvoiceViewModel model)
        {
            var invoice = new Invoice
            {
                
            };

            return View();
        }
    }
}