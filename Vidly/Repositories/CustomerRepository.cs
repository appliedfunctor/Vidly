using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Repositories
{
    public class CustomerRepository : IDisposable
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        

        public List<Customer> GetCustomers()
        {
            return _context.Customers.Include(c => c.MembershipType).OrderBy(c => c.SurName).ToList();
        }

        public Customer GetCustomer(int id)
        {
            return _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void UpdateCustomer(Customer customer, string[] allowedProps = null)
        {
            var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

            var props = typeof(Customer).GetProperties();

            foreach (var prop in props)
            {
                if ((allowedProps == null || allowedProps.Contains(prop.Name))
                    && prop.CanWrite)
                {
                    prop.SetValue(customerInDb, prop.GetValue(customer));
                }
            }
            
            _context.SaveChanges();
        }

        public void RemoveCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public List<MembershipType> GetMembershipTypes()
        {
            return _context.MembershipTypes.ToList();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
                _context?.Dispose();
        }
    }
}