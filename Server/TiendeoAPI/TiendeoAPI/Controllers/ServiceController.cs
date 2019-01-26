using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using TiendeoAPI.Core.Interfaces;
using TiendeoAPI.Core.StoreCore;
using TiendeoAPI.Models;

namespace TiendeoAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ServiceController : Controller
    {
        private readonly IServiceCore _serviceCore;

        public ServiceController(IServiceCore serviceCore)
        {
            this._serviceCore = serviceCore;
        }

        [HttpGet("GetAllServicesFromACity/{cityName}")]
        public IActionResult GetAllServicesFromACity(string cityName)
        {
            try
            {
                if (cityName != "")
                {
                    var result = this._serviceCore.GetAllServicesFromACity(cityName);
                    if (result != null && result.Any())
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return BadRequest(new { message = "no results found" });
                    }
                }
                else
                {
                    return BadRequest(new { message = "city name invalid format" });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message + " StackTrace: " + e.StackTrace);
                return BadRequest(new { message = "error: check the api log" });
            }
        }
    }
}