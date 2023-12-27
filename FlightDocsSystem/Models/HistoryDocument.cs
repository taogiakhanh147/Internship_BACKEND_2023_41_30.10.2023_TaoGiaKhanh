using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FlightDocsSystem.Models
{
    [Table("HistoryDocument")]
    public class HistoryDocument
    {
        [Key]
        [JsonIgnore]
        public int HistoryDocumentID { get; set; }

        public string? DocumentName { get; set; }

        public decimal? Version { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string? UserUpdateName { get; set; }

        [ForeignKey("Document")]
        public int DocumentID { get; set; }

        [JsonIgnore]
        public Document Document { get; set; }
    }
}
