using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MontyHall.Core.Models;
using MontyHall.Core.Services;

namespace MontyHall.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimulationController : ControllerBase
    {
        private readonly ISimulationService _simulationService;

        public SimulationController(ISimulationService simulationService)
        {
            _simulationService = simulationService;
        }

        [HttpPost]
        public async Task<ActionResult<Simulation>> CreateSimulation(int numberOfRounds, bool changeDoor)
        {
            try
            {
                var simulation = await _simulationService.CreateSimulation(numberOfRounds, changeDoor);
                return Created("Created", simulation);
            }
            catch (ArgumentException ae)
            {
                return BadRequest(ae.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
                Console.WriteLine(e);
                throw;
            }
            
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Simulation>>> GetAllSimulations()
        {
            var simulations = await _simulationService.GetAllSimulations();
            return Ok(simulations);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Simulation>> GetSimulationById(int id)
        {
            var simulation = await _simulationService.GetSimulationById(id);
            return Ok(simulation);
        }
    }
}