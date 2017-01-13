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
using Customer = Portable.Licensing.Customer;

namespace Kundbolaget.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly CustomerRepository customerRepository;
        private readonly OrderRepository orderRepository;
        private readonly InvoiceRepository invoiceRepository;

        public InvoiceController()
        {
            customerRepository = new CustomerRepository();
            orderRepository = new OrderRepository();
            invoiceRepository = new InvoiceRepository();
        }

        // GET: Invoice
        public ActionResult Index()
        {
            IList<Invoice> invoices = invoiceRepository.GetAll();
            return View(invoices);
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
        public ActionResult Save(FormCollection form)
        {
            int customerId = int.Parse(form["Customer.Id"]);
            var customer = customerRepository.Find(customerId);
            var date = form["DueDate"];

            DateTime dueDate = DateTime.Parse(date);

            var invoice = new Invoice
            {
                Customer = customer,
                CustomerId = customer.Id,
                DueDate = dueDate,
                InvoiceAddress = customer.VisitingAddress
            };

            // Chosen orders is a CSV of order id:s
            string[] orderIdStrings = form["SelectedOrders"].Split(',');

            foreach (var s in orderIdStrings)
            {
                var orderId = int.Parse(s);
                var order = orderRepository.Find(orderId);
                invoice.Orders.Add(order);
            }

            invoiceRepository.Create(invoice);

            return View(invoice);
        }
    }
}