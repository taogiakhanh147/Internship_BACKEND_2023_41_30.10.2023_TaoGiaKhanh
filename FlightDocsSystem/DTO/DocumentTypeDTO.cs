using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocsSystem.DTO
{
    public class DocumentTypeDTO
    {
        public string? DocumentTypeName { get; set; }

        public string? Note { get; set; }
    }
}
