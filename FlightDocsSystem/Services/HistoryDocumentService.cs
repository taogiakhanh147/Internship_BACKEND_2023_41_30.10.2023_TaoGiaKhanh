using FlightDocsSystem.Models;
using HistoryDocumentDocsSystem.IServices;
using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;

namespace FlightDocsSystem.Services
{
    public class HistoryDocumentService : IHistoryDocumentService  
    {
        private readonly FlightDocsSystemContext _context;

        public HistoryDocumentService(FlightDocsSystemContext context)
        {
            _context = context;
        }

        public async Task<List<HistoryDocument>> getAllHistoryDocumentAsync()
        {
            var HistoryDocuments = await _context.historyDocuments.ToListAsync();
            return HistoryDocuments;
        }



        public async Task<List<HistoryDocument>> getHistoryDocumentByIDAsync(int documentId)
        {
            var historyDocuments = await _context.historyDocuments.Where(h => h.DocumentID == documentId) .ToListAsync();
            if(historyDocuments == null || historyDocuments.Count == 0)
            {
                throw new NotFoundException("DocumentID does not exist or HistoryDocument is null");
            }
            return historyDocuments;
        }
    }
}
