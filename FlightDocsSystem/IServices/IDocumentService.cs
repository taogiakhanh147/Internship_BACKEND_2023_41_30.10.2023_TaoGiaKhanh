using FlightDocsSystem.DTO;
using FlightDocsSystem.Models;

namespace FlightDocsSystem.IServices
{
    public interface IDocumentService
    {
        public Task<List<Document>> GetAllDocumentAsync();

        public Task<Document> GetDocumentByIdAsync(int userId, int documentId);

        public Task<List<DocumentByConditionDTO>> GetDocumentByConditionAsync(int documentId);

        public Task<Stream> DownloadFileDocument(int userId, int documentId);

        public Task<Document> AddDocumentAsync(DocumentDTO model);

        public Task<Document> UploadFileAsync( int documentId, IFormFile file);

        public Task<Document> UpdateFileAsync(int id, int userUpdateId, IFormFile file);

        public Task DeleteDocumentAsync(int id);
    }
}
