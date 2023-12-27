using FlightDocsSystem.DTO;
using FlightDocsSystem.IServices;
using FlightDocsSystem.Models;
using FlightDocsSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using OpenQA.Selenium;

namespace FlightDocsSystem.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DocumentController : Controller
    {
        private readonly IDocumentService _iDocumentService;
        private readonly FlightDocsSystemContext _context;

        public DocumentController(IDocumentService iDocument, FlightDocsSystemContext context)
        {
            _iDocumentService = iDocument;
            _context = context;
        }

        [Authorize(Roles = "Admin System, GO")]
        // Function Get All Document (GET)
        [HttpGet("GetAllDocument")]
        public async Task<IActionResult> GetAllDocument()
        {
            var allDocument = await _iDocumentService.GetAllDocumentAsync();
            return Ok(allDocument);
        }

        // Function GetDocumentByID (GET)
        [HttpGet("GetDocumentByID{userId}/{documentId}")]
        public async Task<IActionResult> GetDocumentById(int userId, int documentId)
        {
            var document = await _iDocumentService.GetDocumentByIdAsync(userId, documentId);
            return Ok(document);
        }

        [Authorize(Roles = "Admin System, GO")]
        // Function GetDocumentByCondition (GET)
        [HttpGet("GetDocumentByCondition/{documentId}")]
        public async Task<IActionResult> GetDocumentByCondition(int documentId)
        {
            var getDocumentByCondition = await _iDocumentService.GetDocumentByConditionAsync(documentId);
            return Ok(getDocumentByCondition);
        }

        // Function DownloadFile (GET)
        [HttpGet("DownloadFile/{userId}/{documentId}")]
        public async Task<IActionResult> DownloadFile(int userId, int documentId)
        {
            try
            {
                var document = await _iDocumentService.GetDocumentByIdAsync(userId, documentId);
                var stream = await _iDocumentService.DownloadFileDocument(userId, documentId);

                // Set the content type and file name
                Response.Headers.Add("Content-Disposition", $"attachment; filename={document.DocumentName}");
                return File(stream, "application/pdf");
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

        [Authorize(Roles = "Admin System, GO")]
        // Function AddDocument (POST)
        [HttpPost("AddNewDocument")]
        public async Task<IActionResult> AddNewDocument(DocumentDTO model)
        {
            var addNewDocument = await _iDocumentService.AddDocumentAsync(model);
            return Ok(addNewDocument);
        }

        [Authorize(Roles = "Admin System, GO")]
        // Function UploadFileToDocument (POST)
        [HttpPost]
        [Route("UploadFileToDocument/{documentId}")]
        public async Task<IActionResult> UploadFileToDocument(int documentId, IFormFile file)
        {
            var uploadFileToDocument = await _iDocumentService.UploadFileAsync(documentId, file);
            return Ok(uploadFileToDocument);
        }

        // Function UpdateFile (PUT)
        [HttpPut("UpdateFile/{documentId}/{userUpdateId}")]
        public async Task<IActionResult> UpdateFile(int documentId, int userUpdateId, IFormFile file)
        {
            var updateFile = await _iDocumentService.UpdateFileAsync(documentId, userUpdateId, file);
            return Ok(updateFile);
        }

        [Authorize(Roles = "Admin System")]
        // Function Delete Document (DELETE)
        [HttpDelete("DeleteDocument/{documentId}")]
        public async Task<IActionResult> DeleteDocument(int documentId)
        {
            await _iDocumentService.DeleteDocumentAsync(documentId);
            return Ok();
        }
    }
}
