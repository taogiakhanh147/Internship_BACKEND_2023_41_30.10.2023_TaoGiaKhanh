using FlightDocsSystem.DTO;
using FlightDocsSystem.IServices;
using FlightDocsSystem.Models;
using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;

namespace FlightDocsSystem.Services
{
    public class DocumentTypeService : IDocumentTypeService
    {
        private readonly FlightDocsSystemContext _context;

        public DocumentTypeService(FlightDocsSystemContext context)
        {
            _context = context;
        }

        public async Task<List<DocumentType>> GetAllDocumentTypeAsync()
        {
            var DocumentTypes = await _context.documentTypes.ToListAsync();
            return DocumentTypes;
        }

        public async Task<DocumentType> getDocumentTypeAsync(int id)
        {
            var documentType = await _context.documentTypes.FindAsync(id);
            if (_context.documentTypes == null || documentType == null)
            {
                throw new NotFoundException("DocumentTypeID does not exist");
            }
            return documentType;
        }

        public async Task<DocumentType> AddDocumentTypeAsync(DocumentTypeDTO DocumentTypeDTO)
        {
            if (DocumentTypeDTO == null)
            {
                throw new NotFoundException("Please enter complete information");
            }

            var DocumentType = new DocumentType
            {
                DocumentTypeName = DocumentTypeDTO.DocumentTypeName,
                Note = DocumentTypeDTO.Note
            };
            _context.documentTypes.Add(DocumentType);
            await _context.SaveChangesAsync();
            return DocumentType;
        }

        public async Task<DocumentType> UpdateDocumentTypeAsync(int id, DocumentTypeDTO model)
        {
            var existingDocumentType = await _context.documentTypes.FindAsync(id);
            if (existingDocumentType == null)
            {
                throw new NotFoundException("ID does not exist");
            }
            else
            {
                existingDocumentType.DocumentTypeName = model.DocumentTypeName;
                existingDocumentType.Note = model.Note;
                _context.documentTypes.Update(existingDocumentType);
                await _context.SaveChangesAsync();
            }
            return existingDocumentType;
        }

        public async Task DeleteDocumentTypeAsync(int id)
        {
            var existingDocumentType = _context.documentTypes!.SingleOrDefault(b => b.DocumentTypeID == id);
            if (existingDocumentType != null)
            {
                _context.documentTypes.Remove(existingDocumentType);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException("ID does not exist");
            }
        }
    }
}
