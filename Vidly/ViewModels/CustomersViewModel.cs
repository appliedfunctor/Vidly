using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class CustomersViewModel
    {
        public List<Customer> Customers { get; set; } = new List<Customer>();

        public CustomersViewModel()
        {
            Customers.Add(new Customer{ Id = 0, FirstName = "John", SurName = "Smith" });
            Customers.Add(new Customer{ Id = 1, FirstName = "Jenny", SurName = "Balder" });
        }

        public Customer GetCustomer(int id)
        {
            return id < Customers.Count ? Customers.FirstOrDefault(c => c.Id == id) : null;
        }
    }
}