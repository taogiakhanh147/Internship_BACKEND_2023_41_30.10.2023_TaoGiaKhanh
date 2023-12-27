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
    public class RoleController : Controller
    {
        private readonly IRoleService _iRoleService;

        public RoleController(IRoleService iRole, FlightDocsSystemContext context)
        {
            _iRoleService = iRole;
        }

        // Function GetAllRole (GET)
        [HttpGet("GetAllRole")]
        public async Task<IActionResult> GetAllRole()
        {
            var allRole = await _iRoleService.getAllRoleAsync();
            return Ok(allRole);
        }

        // Function GetRoleById (GET)
        [HttpGet("GetRoleById/{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var role = await _iRoleService.getRoleAsync(id);
            return Ok(role);
        }

        // Function AddNewRole (POST)
        [HttpPost("AddNewRole")]
        public async Task<IActionResult> AddNewRole(RoleDTO model)
        {
            var newRole = await _iRoleService.AddRoleAsync(model);
            return Ok(newRole);
        }

        // Function UpdateRole (PUT)
        [HttpPut("UpdateRole/{id}")]
        public async Task<IActionResult> UpdateRole(int id, RoleDTO model)
        {
            var updateRole = await _iRoleService.UpdateRoleAsync(id, model);
            return Ok(updateRole);
        }

        // Function DeleteRole (DELETE)
        [HttpDelete("DeleteRole/{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await _iRoleService.DeleteRoleAsync(id);
            return Ok();
        }
    }
}
