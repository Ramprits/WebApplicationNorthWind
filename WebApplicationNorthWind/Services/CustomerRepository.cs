using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationNorthWind.Northwind;

namespace WebApplicationNorthWind.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly NorthwindDbContext _context;
        private readonly ILogger _logger;
        public CustomerRepository(NorthwindDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger(typeof(CustomerRepository));

        }

        public void AddCustomers(Customers customer)
        {
            _context.Add(customer);
        }

        public bool CustomersExists(int customerId)
        {
            return _context.Customers.Any(x => x.Id == customerId);
        }

        public void DeleteCustomers(Customers customer)
        {
            _context.Remove(customer);
        }

        public Customers GetCustomers(int customerId)
        {
            return _context.Customers.OrderByDescending(x => x.CompanyName).FirstOrDefault(x => x.Id == customerId);
        }

        public IEnumerable<Customers> GetCustomerss()
        {
            return _context.Customers.ToList();
        }

        public IEnumerable<Customers> GetCustomerss(IEnumerable<int> customerIds)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public void UpdateCustomers(Customers customer)
        {
            throw new NotImplementedException();
        }
    }
}
