using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TiendeoAPI.Core.Interfaces;
using TiendeoAPI.Models;

namespace TiendeoAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CityController : Controller
    {

        private readonly ICityCore _cityCore;
        public CityController(ICityCore cityCore)
        {
            this._cityCore = cityCore;
        }

        [HttpGet]
        public IActionResult GetAllCities()
        {
            try
            {
                var result = this._cityCore.GetCities();
                if(result != null && result.Any())
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(new { message = "no results found" });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message + " StackTrace: " + e.StackTrace);
                return BadRequest(new { message = "error: check the api log" });
            }
        }
        [HttpGet("/{name}")]
        public IActionResult GetCityByName(string name)
        {
            try
            {
                var result = this._cityCore.GetCityByName(name);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(new { message = "no results found" });
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
