using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using WebApplicationNorthWind.SampleDb.SampleEntities;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using WebApplicationNorthWind.Services;

namespace WebApplicationNorthWind.SampleApi
{
    [Produces("application/json")]
    [Route("api/Products"), EnableCors("AnyGET")]
    public class ProductsController : Controller
    {
        private readonly IProductRepositry _repository;
        private readonly ILogger<ProductsController> _logger;
        public ProductsController(IProductRepositry repository, ILogger<ProductsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_repository.GetProducts());
        }
        [HttpGet("{Id}")]
        public IActionResult GetProducts(int Id)
        {
            return Ok(_repository.GetProduct(Id));
        }


    }
}
