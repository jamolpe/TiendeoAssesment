using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServicesLibrary.Interfaces;
using ServicesLibrary.Models;

namespace TiendeoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private ICityService _cityService;
        public ValuesController(ICityService cityService)
        {
            this._cityService = cityService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<CityDto>> Get()
        {
            return this._cityService.GetCities();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
