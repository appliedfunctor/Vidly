using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Repositories;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly CustomerRepository _customersRepository = new CustomerRepository();

        // GET: Customers
        [Route("customers")]
        public ViewResult Index()
        {
            var viewModel = new CustomersViewModel();
            viewModel.Customers = _customersRepository.GetCustomers();
            
            return View(viewModel);
        }

        [Route("customers/details/{Id:regex(\\d+)}")]
        public ActionResult Details(int id)
        {
            var customer = _customersRepository.GetCustomer(id);

            if (customer != null)
            {
                return View(customer);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id > 0)
            {
                _customersRepository.UpdateCustomer(customer,
                    allowedProps: new[] {"FirstName", "SurName", "Dob", "IsSubscribedToNewsletter", "MembershipTypeId"});
            }
            else
            {
                _customersRepository.AddCustomer(customer);
            }
            
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Delete(int id)
        {
            var customer = _customersRepository.GetCustomer(id);
            _customersRepository.RemoveCustomer(customer);
            return RedirectToAction("Index", "Customers");
        }
        

        public ActionResult New()
        {
            var viewModel = new CustomersViewModel();
            viewModel.MembershipTypes = _customersRepository.GetMembershipTypes();
            return View("CustomerForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var viewModel = new CustomersViewModel();
            viewModel.MembershipTypes = _customersRepository.GetMembershipTypes();
            viewModel.Customer = _customersRepository.GetCustomer(id);
            return View("CustomerForm", viewModel);
        }
    }
}