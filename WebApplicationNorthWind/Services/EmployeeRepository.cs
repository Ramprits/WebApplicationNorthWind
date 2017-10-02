using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationNorthWind.Northwind;

namespace WebApplicationNorthWind.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private NorthwindDbContext _context;
        private ILogger _Logger;

        public EmployeeRepository(NorthwindDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _Logger = loggerFactory.CreateLogger("EmployeeRepository");
        }
        public async Task<bool> DeleteEmployeesAsync(int id)
        {
            var deleteEmployee = _context.Employees.Include(x => x.EmployeeTerritories).FirstOrDefaultAsync(x => x.EmployeeId == id);
            _context.Remove(deleteEmployee);
            try
            {
                return (await _context.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception exp)
            {
                _Logger.LogError($"Error in {nameof(DeleteEmployeesAsync)}: " + exp.Message);
            }
            return false;
        }

        public async Task<bool> EmployeeExists(int Id)
        {
            return await _context.Employees.AnyAsync(x => x.EmployeeId == Id);
        }

        public async Task<Employees> GetEmployeesAsync(int id)
        {
            return await _context.Employees.Include(x => x.EmployeeTerritories).FirstOrDefaultAsync(x => x.EmployeeId == id);
        }

        public async Task<List<Employees>> GetEmployeessAsync()
        {
            return await _context.Employees.Include(x => x.EmployeeTerritories).ToListAsync();
        }

        public async Task<Employees> InsertEmployeesAsync(Employees employee)
        {
            await _context.AddAsync(employee);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception exp)
            {

                _Logger.LogError($"Error in {nameof(InsertEmployeesAsync)}: " + exp.Message);
            }
            return employee;
        }

        public async Task<bool> SaveAllAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<bool> UpdateEmployeesAsync(Employees employee)
        {
            _context.Employees.Attach(employee);
            _context.Entry(employee).State = EntityState.Modified;
            try
            {
                return (await _context.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception exp)
            {
                _Logger.LogError($"Error in {nameof(UpdateEmployeesAsync)}: " + exp.Message);
            }
            return false;
        }
    }
}
