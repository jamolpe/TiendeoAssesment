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
    public class StoreController : Controller
    {
        private readonly IStoreCore _storeCore;
        public StoreController(IStoreCore storeCore)
        {
            this._storeCore = storeCore;
        }
        
        [HttpGet("GetStoresOrderByRank")]
        public IActionResult GetStoresOrderByRank()
        {
            try
            {
                var result = this._storeCore.GetStoresOrderByRank();
                if (result != null && result.Any())
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
                return BadRequest(new {message = "error: check the api log"});
            }
            
        }

        [HttpPost("GetNearestStoreFromCoords")]
        public IActionResult GetNearestStoreFromCoords([FromBody]Coord userCoords)
        {
            try
            {
                if (userCoords != null)
                {
                    var result = this._storeCore.GetNearestStoreFromCoords(userCoords);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return BadRequest(new {message = "no results found"});
                    }

                }
                else
                {
                   return BadRequest(new {message = "user coords invalid format"});
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: "+ e.Message + " StackTrace: " + e.StackTrace);
                return BadRequest(new {message = "error: check the api log"});
            }
        }

        [HttpPost("GetXNearestStoresFromCoords/{count}")]
        public IActionResult GetXNearestStoresFromCoords(int count,[FromBody] Coord userCoords)
        {
            try
            {
                if (userCoords != null)
                {
                    var result = this._storeCore.GetXNearestStoresFromCoords(userCoords,count);
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
                    return BadRequest(new { message = "user coords invalid format" });
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