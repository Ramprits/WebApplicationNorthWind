using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicationNorthWind.Northwind;
using WebApplicationNorthWind.Services;
using AutoMapper;
using WebApplicationNorthWind.NorthwindModel.Employee;
using Microsoft.AspNetCore.Cors;

namespace WebApplicationNorthWind.NorthwindApi
{
    [Produces("application/json")]
    [Route("api/Employees"), EnableCors("AnyGET")]
    public class EmployeesController : Controller
    {
        private IEmployeeRepository _repository;
        private IMapper _mapper;

        public EmployeesController(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getEmployees = await _repository.GetEmployeessAsync();
            return Ok(_mapper.Map<IEnumerable<EmployeeViewModel>>(getEmployees));
        }

        [HttpGet("{id}", Name = "GetEmployees")]
        public async Task<IActionResult> Get(int id)
        {
            if (!await _repository.EmployeeExists(id))
            {
                return NotFound($"employee with Id : {id} not founds");
            }
            var getEmployee = await _repository.GetEmployeesAsync(id);
            return Ok(_mapper.Map<EmployeeViewModel>(getEmployee));
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
