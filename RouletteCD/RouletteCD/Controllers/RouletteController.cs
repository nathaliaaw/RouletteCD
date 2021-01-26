using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouletteCD.DataStructure;
using RouletteCD.Models;
using RouletteCD.Services;

namespace RouletteCD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RouletteController : Controller
    {
        private IRouletteService rouletteService;

        public RouletteController(IRouletteService rouletteService)
        {
            this.rouletteService = rouletteService;
        }

        [HttpPost]
        public IActionResult NewRulette()
        {
            Roulette roulette = rouletteService.create();
            return Ok(roulette);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(rouletteService.GetAll());
        }



        [HttpPut("{idRoulette}/openRoulette")]
        public IActionResult openRoulette([FromRoute(Name = "idRoulette")] string idRoulette)
        {
            try
            {
                rouletteService.openRoulette(idRoulette);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(405);
            }
        }

        [HttpPut("{id}/close")]
        public IActionResult Close([FromRoute(Name = "id")] string id)
        {
            try
            {
                Roulette roulette = rouletteService.Close(id);
                return Ok(roulette);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(405);
            }
        }
        [HttpPost("{id}/betValues")]
        public IActionResult betValues([FromRoute(Name = "id")] string id,
            [FromBody] BDataStructure request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    error = true,
                    msg = "Bad Request"
                });
            }

            try
            {
                Roulette roulette = rouletteService.betValues(id, request);
                return Ok(roulette);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(405);
            }

        }
    }
}
