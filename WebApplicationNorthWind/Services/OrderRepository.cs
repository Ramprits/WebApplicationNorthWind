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
    public class OrderRepository : IOrderRepository
    {
        private NorthwindDbContext _context;
        private ILogger _Logger;
        public OrderRepository(NorthwindDbContext context, LoggerFactory logger)
        {
            _context = context;
            _Logger = logger.CreateLogger("OrderRepository");
        }
        public Task<bool> DeleteOrdersAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EmployeeExists(int Id)
        {
            return await _context.Orders.AnyAsync(x => x.OrderId == Id);
        }

        public async Task<List<Orders>> GetOrdersAsync()
        {
            return await _context.Orders.Include(x => x.OrderDetails).ToListAsync();
        }

        public async Task<Orders> GetOrdersAsync(int id)
        {
            return await _context.Orders.Include(x => x.OrderDetails).FirstOrDefaultAsync(x => x.OrderId == id);
        }

        public async Task<Orders> InsertOrdersAsync(Orders order)
        {
            await _context.AddAsync(order);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception exp)
            {

                _Logger.LogError($"Error in {nameof(InsertOrdersAsync)}: " + exp.Message);
            }
            return order;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateOrdersAsync(Orders order)
        {
            _context.Orders.Attach(order);
            _context.Entry(order).State = EntityState.Modified;
            try
            {
                return (await _context.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception exp)
            {
                _Logger.LogError($"Error in {nameof(UpdateOrdersAsync)}: " + exp.Message);
            }
            return false;
        }
    }
}
