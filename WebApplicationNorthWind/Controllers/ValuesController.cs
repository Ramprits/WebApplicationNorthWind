using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplicationNorthWind.Northwind;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationNorthWind.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private NorthwindDbContext _context;

        public ValuesController(NorthwindDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Orders.Include(x => x.OrderDetails).ToList());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
