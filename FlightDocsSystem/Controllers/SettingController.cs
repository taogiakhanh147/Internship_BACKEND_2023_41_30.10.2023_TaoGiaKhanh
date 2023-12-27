using FlightDocsSystem.DTO;
using FlightDocsSystem.IServices;
using FlightDocsSystem.Models;
using FlightDocsSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;

namespace FlightDocsSystem.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin System")]
    public class SettingController : Controller
    {
        private readonly ISettingService _iSettingService;

        public SettingController(ISettingService iSetting, FlightDocsSystemContext context)
        {
            _iSettingService = iSetting;
        }

        // Function GetSetting (GET)
        [HttpGet("GetAllSetting")]
        public async Task<IActionResult> GetAllSetting()
        {
            var allSetting = await _iSettingService.getAllSettingAsync();
            return Ok(allSetting);
        }

        // Function GetSettingById (GET)
        [HttpGet("GetSettingById/{id}")]
        public async Task<IActionResult> GetSettingById(int id)
        {
            var setting = await _iSettingService.getSettingAsync(id);
            return Ok(setting);
        }

        // Function DownloadLogo (GET)
        [HttpGet("DownloadLogo")]
        public async Task<IActionResult> DownloadLogo([FromQuery] string LogoName)
        {
            try
            {
                var stream = await _iSettingService.DownloadLogoSetting(LogoName);

                // Set the content type and file name
                Response.Headers.Add("Content-Disposition", $"attachment; filename={LogoName}");
                return File(stream, "application/octet-stream"); // Sử dụng "application/octet-stream" để tải mọi loại tệp tin
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Function AddNewSetting (POST)
        [HttpPost("AddNewSetting")]
        public async Task<IActionResult> AddNewSetting(SettingDTO model)
        {
            var newSetting = await _iSettingService.AddSettingAsync(model);
            return Ok(newSetting);
        }

        // Function UploadLogoToSetting (POST)
        [HttpPost]
        [Route("UploadLogoToSetting/{id}")]
        public async Task<IActionResult> UploadLogoToSetting(int id, IFormFile file)
        {
            var uploadLogo = await _iSettingService.UploadLogoAsync(id, file);
            return Ok(uploadLogo);
        }

        // Function UpdateLogo (PUT)
        [HttpPut("UpdateLogo/{SettingId}")]
        public async Task<IActionResult> UpdateLogo(int SettingId, IFormFile file)
        {
            var updateSetting = await _iSettingService.UploadLogoAsync(SettingId, file);
            return Ok(updateSetting);
        }


        // Function DeleteSetting (DELETE)
        [HttpDelete("DeleteSetting/{id}")]
        public async Task<IActionResult> DeleteSetting(int id)
        {
            await _iSettingService.DeleteSettingAsync(id);
            return Ok();
        }
    }
}
