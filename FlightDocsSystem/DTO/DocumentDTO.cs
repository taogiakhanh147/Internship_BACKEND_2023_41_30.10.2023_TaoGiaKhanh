using FlightDocsSystem.Models;
using System.Text.Json.Serialization;

namespace FlightDocsSystem.DTO
{
    public class DocumentDTO
    {
        public string? Note { get; set; }

        public int GroupID { get; set; }

        [JsonIgnore]
        public decimal Version { get; set; } = 1.0m;

        public int DocumentTypeID { get; set; }

        public int FlightID { get; set; }
    }
}
