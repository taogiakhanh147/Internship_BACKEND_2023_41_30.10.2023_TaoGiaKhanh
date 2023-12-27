using FlightDocsSystem.IServices;
using FlightDocsSystem.Models;
using HistoryDocumentDocsSystem.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FlightDocsSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin System, GO")]
    public class HistoryDocumentController : ControllerBase
    {
        private readonly IHistoryDocumentService _iHistoryDocumentService;

        public HistoryDocumentController(IHistoryDocumentService iHistoryDocument, FlightDocsSystemContext context)
        {
            _iHistoryDocumentService = iHistoryDocument;
        }

        // Function Get All HistoryDocument (GET)
        [HttpGet]
        public async Task<IActionResult> GetAllHistoryDocument()
        {
            var getAllHistoryDocument = await _iHistoryDocumentService.getAllHistoryDocumentAsync();
            return Ok(getAllHistoryDocument);
        }

        // Function GetHistoryDocumentById (GET_ID)
        [HttpGet("GetHistoryDocumentById/{documentId}")]
        public async Task<IActionResult> GetHistoryDocumentById(int documentId)
        {
            var historyDocumentDetailsList = await _iHistoryDocumentService.getHistoryDocumentByIDAsync(documentId);
            return Ok(historyDocumentDetailsList);
        }
    }
}
