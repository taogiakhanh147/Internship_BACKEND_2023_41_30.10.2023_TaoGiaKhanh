using FlightDocsSystem.DTO;
using FlightDocsSystem.IServices;
using FlightDocsSystem.Models;
using FlightDocsSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace FlightDocsSystem.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin System")]
    public class PermissionController : Controller
    {
        private readonly IPermissionService _iPermissionService;

        public PermissionController(IPermissionService iPermission, FlightDocsSystemContext context)
        {
            _iPermissionService = iPermission;
        }

        // Function GetAllPermission (GET)
        [HttpGet("GetAllPermission")]
        public async Task<IActionResult> GetAllPermission()
        {
            var AllPermission = await _iPermissionService.getAllPermissionAsync();
            return Ok(AllPermission);
        }

        // Function GetPermissionById (GET)
        [HttpGet("GetPermissionById/{id}")]
        public async Task<IActionResult> GetPermissionById(int id)
        {
            var Permission = await _iPermissionService.getPermissionAsync(id);
            return Ok(Permission);
        }

        // Function AddNewPermission (POST)
        [HttpPost("AddNewPermission")]
        public async Task<IActionResult> AddNewPermission(PermissionDTO model)
        {
            var newPermission = await _iPermissionService.AddPermissionAsync(model);
            return Ok(newPermission);
        }

        // Function UpdatePermission (PUT)
        [HttpPut("UpdatePermission/{id}")]
        public async Task<IActionResult> UpdatePermission(int id, PermissionDTO model)
        {
            var UpdatePermission = await _iPermissionService.UpdatePermissionAsync(id, model);
            return Ok(UpdatePermission);
        }

        // Function DeletePermission (DELETE)
        [HttpDelete("DeletePermission/{id}")]
        public async Task<IActionResult> DeletePermission(int id)
        {
            await _iPermissionService.DeletePermissionAsync(id);
            return Ok();
        }
    }
}
