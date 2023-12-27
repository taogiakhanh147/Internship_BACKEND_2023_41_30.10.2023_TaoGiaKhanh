using FlightDocsSystem.DTO;
using FlightDocsSystem.IServices;
using FlightDocsSystem.Models;
using FlightDocsSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin System,GO")]
    public class DocumentTypeController : ControllerBase
    {
        private readonly IDocumentTypeService _iDocumentTypeService;

        public DocumentTypeController(IDocumentTypeService iDocumentType, FlightDocsSystemContext context)
        {
            _iDocumentTypeService = iDocumentType;
        }

        // Function GetAllDocumentType (GET)
        [HttpGet("GetAllDocumentType")]
        public async Task<IActionResult> GetAllDocumentType()
        {
            var allDocumentType = await _iDocumentTypeService.GetAllDocumentTypeAsync();
            return Ok(allDocumentType);
        }

        // Function GetDocumentTypeById (GET)
        [HttpGet("GetDocumentTypeById/{id}")]
        public async Task<IActionResult> GetDocumentTypeById(int id)
        {
            var documentType = await _iDocumentTypeService.getDocumentTypeAsync(id);
            return Ok(documentType);
        }

        // Function AddNewDocumentType (POST)
        [HttpPost("AddNewDocumentType")]

        public async Task<IActionResult> AddNewDocumentType(DocumentTypeDTO model)
        {
            var newDocumentType = await _iDocumentTypeService.AddDocumentTypeAsync(model);
            return Ok(newDocumentType);
        }

        // Function UpdateDocumentType (PUT)
        [HttpPut("UpdateDocumentType/{id}")]
        public async Task<IActionResult> UpdateDocumentType(int id, DocumentTypeDTO model)
        {
            var updateDocumentType = await _iDocumentTypeService.UpdateDocumentTypeAsync(id, model);
            return Ok(updateDocumentType);
        }

        // Function DeleteDocumentType (DELETE)
        [HttpDelete("DeleteDocumentType/{id}")]
        public async Task<IActionResult> DeleteDocumentType(int id)
        {
            await _iDocumentTypeService.DeleteDocumentTypeAsync(id);
            return Ok();
        }
    }
}
