using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaT_MasterGroup.Models;

namespace PruebaT_MasterGroup.Controllers
{
    [ApiController]
    [Route("api/")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("index")]
        public IActionResult Index()
        {
            return Ok(new { message = "Hola desde la API" });
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { message = "Hola desde la API" });
        }

        [HttpGet("privacy")]
        public IActionResult Privacy()
        {
            return null;
        }

        [HttpGet("error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var errorInfo = new
            {
                requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                message = "Ha ocurrido un error"
            };

            return Ok(errorInfo);
        }
    }
}
