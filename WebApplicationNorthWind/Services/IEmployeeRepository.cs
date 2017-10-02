using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationNorthWind.Northwind;

namespace WebApplicationNorthWind.Services
{
    public interface IEmployeeRepository
    {
        Task<List<Employees>> GetEmployeessAsync();
        Task<Employees> GetEmployeesAsync(int id);
        Task<Employees> InsertEmployeesAsync(Employees employee);
        Task<bool> UpdateEmployeesAsync(Employees employee);
        Task<bool> DeleteEmployeesAsync(int id);
        Task<bool> SaveAllAsync();
    }
}
