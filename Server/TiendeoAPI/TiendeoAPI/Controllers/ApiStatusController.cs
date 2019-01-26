using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TiendeoAPI.Models;

namespace TiendeoAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ApiStatusController : Controller
    {
        private readonly IOptions<Settings> _settings;

        public ApiStatusController(IOptions<Settings> settings)
        {
            this._settings = settings;
        }

        [HttpGet]
        public IActionResult Status()
        {
            return Ok(new {status = "Running", fakeDataMode= this._settings.Value.UseMockData});
        }
    }
}
