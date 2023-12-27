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
    public class GroupController : Controller
    {
        private readonly IGroupService _iGroupService;

        public GroupController(IGroupService iGroup, FlightDocsSystemContext context)
        {
            _iGroupService = iGroup;
        }

        // Function GetAllGroup (GET)
        [HttpGet("GetAllGroup")]
        public async Task<IActionResult> GetAllGroup()
        {
            var AllGroup = await _iGroupService.getAllGroupAsync();
            return Ok(AllGroup);
        }

        // Function GetGroupById (GET)
        [HttpGet("GetGroupById/{id}")]
        public async Task<IActionResult> GetGroupById(int id)
        {
            var Group = await _iGroupService.getGroupAsync(id);
            return Ok(Group);
        }

        // Function GetGroupByCondition (GET)
        [HttpGet("GetGroupByCondition/{groupID}")]
        public async Task<IActionResult> GetGroupByCondition(int groupID)
        {
            var getGroupByCondition = await _iGroupService.GetGroupByConditionAsync(groupID);
            return Ok(getGroupByCondition);
        }

        // Function AddNewGroup (POST)
        [HttpPost("AddNewGroup")]
        public async Task<IActionResult> AddNewGroup(GroupDTO model)
        {
            var newGroup = await _iGroupService.AddGroupAsync(model);
            return Ok(newGroup);
        }

        // Function UpdateGroup (PUT)
        [HttpPut("UpdateGroup/{id}")]
        public async Task<IActionResult> UpdateGroup(int id, GroupDTO model)
        {
            var UpdateGroup = await _iGroupService.UpdateGroupAsync(id, model);
            return Ok(UpdateGroup);
        }

        // Function DeleteGroup (DELETE)
        [HttpDelete("DeleteGroup/{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            await _iGroupService.DeleteGroupAsync(id);
            return Ok();
        }
    }
}
