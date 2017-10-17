using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationNorthWind.Northwind;

namespace WebApplicationNorthWind.Services
{
    public interface ICustomerRepository
    {
        IEnumerable<Customers> GetCustomerss();
        Customers GetCustomers(int customerId);
        IEnumerable<Customers> GetCustomerss(IEnumerable<int> customerIds);
        void AddCustomers(Customers customer);
        void DeleteCustomers(Customers customer);
        void UpdateCustomers(Customers customer);
        bool CustomersExists(int customerId);
        //IEnumerable<Book> GetBooksForCustomers(int customerId);
        //Book GetBookForCustomers(int customerId, int bookId);
        //void AddBookForCustomers(int customerId, Book book);
        //void UpdateBookForCustomers(Book book);
        //void DeleteBook(Book book);
        bool Save();
    }
}
