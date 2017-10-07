using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicationNorthWind.Services;

namespace WebApplicationNorthWind.NorthwindApi
{
    [Route("api/Orders")]
    public class OrdersController : Controller
    {
        private IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _orderRepository.GetOrdersAsync());
        }

        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
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
