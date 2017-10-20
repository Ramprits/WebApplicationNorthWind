using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplicationNorthWind.Northwind;
using WebApplicationNorthWind.NorthwindModel.CustomerModel;
using AutoMapper;
using WebApplicationNorthWind.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;

namespace WebApplicationNorthWind.NorthwindApi
{
    [Produces("application/json")]
    [Route("api/Customers"), EnableCors("AnyGET")]
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerRepository repo, IMapper mapper)
        {
            _repository = repo;
            _mapper = mapper;

        }
        [HttpGet]
        public IActionResult Get()
        {
            var getCustomer = _repository.GetCustomerss();
            return Ok(_mapper.Map<IEnumerable<CustomerDto>>(getCustomer));
        }

        [HttpGet("{id}", Name = "GetCustomers")]
        public IActionResult Get(int id)
        {

            var getCustomer = _repository.GetCustomers(id);
            if (getCustomer == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<Customers>(getCustomer));
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody]CreationForCustomerDto customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }
            if (customer.CompanyName == customer.ContactName)
            {
                return BadRequest($"{customer.CompanyName} couldn't be same {customer.ContactName}");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var AddCustomer = _mapper.Map<Customers>(customer);
            _repository.AddCustomers(AddCustomer);
            if (!_repository.Save())
            {
                return BadRequest();
            }
            return Created("GetCustomers", new { id = customer.CustomerId });
        }
        [HttpPost("{id}")]
        public IActionResult BlockCustomerCreation(int id)
        {
            if (_repository.CustomersExists(id))
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var getCustomer = _repository.GetCustomers(id);
            if (getCustomer == null)
            {
                return NotFound();
            }
            _repository.DeleteCustomers(getCustomer);
            if (!_repository.Save())
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
