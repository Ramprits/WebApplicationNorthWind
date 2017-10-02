using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationNorthWind.Northwind;
using Microsoft.EntityFrameworkCore;
using WebApplicationNorthWind.Services;

namespace WebApplicationNorthWind.NorthwindApi
{
    [Produces("application/json")]
    [Route("api/Employees")]
    public class EmployeesController : Controller
    {
        private IEmployeeRepository _repository;
        public EmployeesController(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.GetEmployeessAsync());
        }

        [HttpGet("{id}", Name = "GetEmployees")]
        public async Task<IActionResult> Get(int id)
        {

            var getEmployee = await _repository.GetEmployeesAsync(id);
            return Ok(getEmployee);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Employees employee)
        {
            return Created("", null);
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
