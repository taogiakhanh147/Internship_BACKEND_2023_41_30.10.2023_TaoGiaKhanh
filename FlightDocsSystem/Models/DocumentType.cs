using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FlightDocsSystem.Models
{
    [Table("DocumentType")]
    public class DocumentType
    {
        [Key]
        public int DocumentTypeID { get; set; }

        public string? DocumentTypeName { get; set; }

        public string? Note { get; set; }

        [JsonIgnore]
        public ICollection<Document> document { get; set; }
    }
}
