using FlightDocsSystem.Models;

namespace HistoryDocumentDocsSystem.IServices
{
    public interface IHistoryDocumentService
    {
        public Task<List<HistoryDocument>> getAllHistoryDocumentAsync();

        public Task<List<HistoryDocument>> getHistoryDocumentByIDAsync(int documentId);
    }
}
