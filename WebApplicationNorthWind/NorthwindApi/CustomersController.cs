using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplicationNorthWind.Northwind;

namespace WebApplicationNorthWind.NorthwindApi
{
    [Produces("application/json")]
    [Route("api/Customers")]
    public class CustomersController : Controller
    {
        private NorthwindDbContext _context;
        public CustomersController(NorthwindDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Customers.ToList());
        }

        [HttpGet("{id}", Name = "GetCustomers")]
        public IActionResult Get(int id)
        {
            var getCustomer = _context.Customers.FirstOrDefault(x => x.Id == id);
            return Ok(getCustomer);
        }

        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
