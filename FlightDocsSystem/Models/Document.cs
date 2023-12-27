using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FlightDocsSystem.Models
{
    [Table("Document")]
    public class Document
    {
        [Key]
        public int DocumentID { get; set; }

        public string? DocumentName { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public decimal? Version { get; set; }

        public string? Note { get; set; }

        public string? File { get; set; }

        public int? GroupID { get; set; }

        [ForeignKey("Flight")]
        public int FlightID { get; set; }

        [ForeignKey("DocumentType")]
        public int DocumentTypeID { get; set; }

        [ForeignKey("User")]
        public int? UserUpdateID { get; set; }

        public string? UserUpdateName { get; set; }

        [JsonIgnore]
        public Flight Flight { get; set; }

        [JsonIgnore]
        public DocumentType documentTypes { get; set; }

        [JsonIgnore]
        public User User { get; set; }

        [JsonIgnore]
        public ICollection<HistoryDocument> historyDocuments { get; set; }
    }
}
