using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationNorthWind.Northwind;

namespace WebApplicationNorthWind.Services
{
    public interface IOrderRepository
    {
        Task<List<Orders>> GetOrdersAsync();
        Task<Orders> GetOrdersAsync(int id);
        Task<Orders> InsertOrdersAsync(Orders order);
        Task<bool> UpdateOrdersAsync(Orders order);
        Task<bool> DeleteOrdersAsync(int id);
        Task<bool> EmployeeExists(int Id);
        Task<bool> SaveAllAsync();
    }
}
