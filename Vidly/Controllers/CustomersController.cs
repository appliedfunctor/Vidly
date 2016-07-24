using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        [Route("customers")]
        public ViewResult Index()
        {
            var viewModel = new CustomersViewModel();
            //viewModel.Customers = new List<Customer>();
            return View(viewModel);
        }

        [Route("customers/details/{Id:regex(\\d+)}")]
        public ActionResult Details(int id)
        {
            var viewModel = new CustomersViewModel();
            var customer = viewModel.GetCustomer(id);

            if (customer != null)
            {
                return View(customer);
            }
            return HttpNotFound();
        }
    }
}