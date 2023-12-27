using FlightDocsSystem.DTO;
using FlightDocsSystem.Models;

namespace FlightDocsSystem.IServices
{
    public interface IDocumentTypeService
    {
        public Task<List<DocumentType>> GetAllDocumentTypeAsync();

        public Task<DocumentType> getDocumentTypeAsync(int id);

        public Task<DocumentType> AddDocumentTypeAsync(DocumentTypeDTO model);

        public Task<DocumentType> UpdateDocumentTypeAsync(int id, DocumentTypeDTO model);

        public Task DeleteDocumentTypeAsync(int id);
    }
}
