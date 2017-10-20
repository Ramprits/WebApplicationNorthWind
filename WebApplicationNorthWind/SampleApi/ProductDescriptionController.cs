using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationNorthWind.SampleApi
{
    [Produces("application/json")]
    [Route("api/ProductDescription")]
    public class ProductDescriptionController : Controller
    {
        public ProductDescriptionController()
        {

        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}