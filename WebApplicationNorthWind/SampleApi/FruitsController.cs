using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using WebApplicationNorthWind.Services;

namespace WebApplicationNorthWind.SampleApi
{
    [Produces("application/json")]
    [Route("api/Fruits"), EnableCors("AnyGET")]
    public class FruitsController : Controller
    {
        private readonly IFruitRepository _repo;

        public FruitsController(IFruitRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetFruits());
        }
    }
}