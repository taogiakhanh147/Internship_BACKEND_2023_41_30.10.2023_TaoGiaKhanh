using FlightDocsSystem.DTO;
using FlightDocsSystem.IServices;
using FlightDocsSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using FlightDocsSystem.Services;
using OpenQA.Selenium;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace FlightDocsSystem.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly FlightDocsSystemContext _context;

        public DocumentService(FlightDocsSystemContext context)
        {
            _context = context;
        }

        // Function GetAllDocumentAsync (GET)
        public async Task<List<Document>> GetAllDocumentAsync()
        {
            var Documents = await _context.Documents.ToListAsync();
            return Documents;
        }

        // Function GetDocumentByID (GET)
        [HttpGet("{id}")]
        public async Task<Document> GetDocumentByIdAsync(int userId, int documentId)
        {
            var document = await _context.Documents
                .Include(d => d.Flight)
                .FirstOrDefaultAsync(d => d.DocumentID == documentId);

            if (document == null)
            {
                throw new NotFoundException("Document not found.");
            }

            // Kiểm tra xem người dùng có trong nhóm có quyền xem tài liệu không
            var isUserInGroup = await _context.Users
                .AnyAsync(u => u.UserID == userId && u.GroupID == document.GroupID);

            if (!isUserInGroup)
            {
                throw new NotFoundException("You are not in the group that can view this document.");
            }

            return document;
        }

        // Function GetDocumentByConditionAsync (GET)
        public async Task<List<DocumentByConditionDTO>> GetDocumentByConditionAsync(int documentId)
        {
            var documents = await _context.Documents
                .Include(d => d.documentTypes)
                .Include(d => d.Flight)
                    .ThenInclude(f => f.User)
                .Where(d => d.DocumentID == documentId)
                .Select(d => new DocumentByConditionDTO
                {
                    DocumentName = d.DocumentName,
                    Type = d.documentTypes.DocumentTypeName,
                    CreateDate = d.CreateDate ?? DateTime.MinValue,
                    Creator = d.Flight.User.UserName,
                    FlightNo = d.Flight.FlightNo
                })
                .ToListAsync();
            if(documents.Count == 0)
            {
                throw new NotFoundException("DocumentID doesn't exist");
            }
            return documents;
        }

        // Function DownloadFileDocument (GET)
        public async Task<Stream> DownloadFileDocument(int userId, int documentId)
        {
            // Kiểm tra document có tồn tại hay không thông qua tham số truyền vào là documentId
            var document = await _context.Documents.FirstOrDefaultAsync(d => d.DocumentID == documentId);

            if (document == null || string.IsNullOrEmpty(document.File))
            {
                throw new NotFoundException("File not found.");
            }

            var filePath = Path.Combine("D:\\Alta SoftWare\\FlightDocsSytem_code\\FlightDocsSystem\\Uploads", document.File);

            if (!File.Exists(filePath))
            {
                throw new NotFoundException("File not found on the server.");
            }

            // Kiểm tra xem người dùng có trong nhóm có quyền xem tài liệu không
            var isUserInGroup = await _context.Users
                .AnyAsync(u => u.UserID == userId && u.GroupID == document.GroupID);

            if (!isUserInGroup)
            {
                throw new NotFoundException("You are not in the group that can update this document.");
            }

            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            return stream;
        }


        // Function AddDocumentAsync (POST)
        public async Task<Document> AddDocumentAsync(DocumentDTO documentDTO)
        {
            if (documentDTO == null)
            {
                throw new NotFoundException("Please enter information");
            }
            var document = new Document
            {
                CreateDate = DateTime.Now,
                Version = documentDTO.Version,
                Note = documentDTO.Note,
                GroupID = documentDTO.GroupID,
                DocumentTypeID = documentDTO.DocumentTypeID,
                FlightID = documentDTO.FlightID
            };
            _context.Documents.Add(document);
            await _context.SaveChangesAsync();

            return document;
        }

        // Function UploadFileAsync (POST)
        public async Task<Document> UploadFileAsync(int documentId, IFormFile file)
        {
            var existingDocument = await _context.Documents
                .Include(d => d.Flight)
                .FirstOrDefaultAsync(d => d.DocumentID == documentId);
            if (existingDocument == null)
            {
                throw new NotFoundException("documentID doesn't exist");
            }
            if (file != null)
            {
                existingDocument.File = await SaveFile(file);
                existingDocument.DocumentName = Path.GetFileName(file.FileName);
                await _context.SaveChangesAsync();
            }
            return existingDocument;
        }

        
        // Function UpdateFileAsync (PUT)
        public async Task<Document> UpdateFileAsync(int id, int userUpdateId, IFormFile file)
        {
            var existingDocument = await _context.Documents
                .Include(d => d.Flight)
                .Include(d => d.User)
                .FirstOrDefaultAsync(d => d.DocumentID == id);
            if(existingDocument == null)
            {
                throw new NotFoundException("DocumentID is invalid");
            }
            else
            {
                // Kiểm tra userUpdateId có tồn tại trong bảng User và thuộc Group có PermissionID = 1 hay không
                var user = await _context.Users
                    .Include(u => u.Group)
                    .FirstOrDefaultAsync(u => u.UserID == userUpdateId && u.Group.PermissionID == 1);
                if (user == null)
                {
                    throw new NotFoundException("You do not have permission to update");
                }
                // Tăng version trước khi lưu lịch sử document
                existingDocument.Version += 0.1m;
                existingDocument.File = await SaveFile(file);
                existingDocument.UpdateDate = DateTime.Now;
                existingDocument.DocumentName = Path.GetFileName(file.FileName);

                // Cập nhật UserUpdateID và UserUpdateName
                existingDocument.UserUpdateID = userUpdateId;
                existingDocument.UserUpdateName = user.UserName;

                // Lưu lịch sử document
                await SaveDocumentHistory(existingDocument);
                await _context.SaveChangesAsync();
            }
            return existingDocument;
        }

        // Function DeleteDocumentAsync (DELETE)
        public async Task DeleteDocumentAsync(int id)
        {
            var existingDocument = _context.Documents!.SingleOrDefault(b => b.DocumentID == id);
            if (existingDocument != null)
            {
                _context.Documents.Remove(existingDocument);
                await _context.SaveChangesAsync();
            }
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var filePath = Path.Combine("D:\\Alta SoftWare\\FlightDocsSytem_code\\FlightDocsSystem\\Uploads", file.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return filePath;
        }

        // Function SaveDocumentHistory
        private async Task SaveDocumentHistory(Document document)
        {
            try
            {
                var historyDocument = new HistoryDocument
                {
                    DocumentName = document.DocumentName,
                    UpdateDate = DateTime.Now,
                    Version = document.Version,
                    DocumentID = document.DocumentID,
                    UserUpdateName = document.UserUpdateName
                };

                _context.historyDocuments.Add(historyDocument);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Xem chi tiết lỗi
                Console.WriteLine($"Error saving document history: {ex.ToString()}");


            }
        }
    }
}
