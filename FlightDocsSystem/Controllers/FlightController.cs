using FlightDocsSystem.DTO;
using FlightDocsSystem.IServices;
using FlightDocsSystem.Models;
using FlightDocsSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;

namespace FlightDocsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    /*[Authorize(Roles = "Admin System")]*/
    public class FlightController : Controller
    {
        private readonly IFlightService _iFlightService;
        private readonly FlightDocsSystemContext _context;

        public FlightController(IFlightService iFlight, FlightDocsSystemContext context)
        {
            _iFlightService = iFlight;
            _context = context;
        }

        // Function GetAllFlight (GET)
        [HttpGet("GetAllFlight")]
        public async Task<IActionResult> GetAllFlight()
        {
            var allFlight = await _iFlightService.getAllFlightAsync();
            return Ok(allFlight);
        }

        // Function GetFlightById (GET)
        [HttpGet("GetFlightById/{id}")]
        public async Task<IActionResult> GetFlightById(int id)
        {
            var flight = await _iFlightService.getFlightAsync(id);
            return Ok(flight);
        }

        // Function GetFlightByCondition (GET)
        [HttpGet("GetFlightByCondition/{id}")]
        public async Task<IActionResult> GetFlightByCondition(int id)
        {
            var flightByCondition = await _iFlightService.GetFlightByConditionAsync(id);
            return Ok(flightByCondition);
        }

        // Function CountFileUpload (GET)
        [HttpGet("CountFileUpload/{id}")]
        public async Task<IActionResult> CountFileUpload(int id)
        {
            var countFileUpload = await _iFlightService.CountFileUploadAsync(id);
            return Ok(countFileUpload);
        }


        // Function AddNewFlight (POST)
        [HttpPost("AddNewFlight")]
        public async Task<IActionResult> AddNewFlight(FlightDTO model)
        {
            var newFlight = await _iFlightService.AddFlightAsync(model);
            return Ok(newFlight);
        }

        // Function UpdateFlight (PUT)
        [HttpPut("UpdateFlight/{id}")]
        public async Task<IActionResult> UpdateFlight(int id, FlightDTO model)
        {
            var updateFlight = await _iFlightService.UpdateFlightAsync(id, model);
            return Ok(updateFlight);

        }

        // Function Delete Flight (DELETE)
        [HttpDelete("DeleteFlight/{id}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            await _iFlightService.DeleteFlightAsync(id);
            return Ok();
        }
    }
}
