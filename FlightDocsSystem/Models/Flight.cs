using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FlightDocsSystem.Models
{
    [Table("Flight")]
    public class Flight
    {
        [Key]
        public int FlightID { get; set; }

        public string? FlightNo { get; set; }

        public DateTime? DepartureDate { get; set; }

        public DateTime? ArrivalDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string DepartureTime { get; set; }

        public string ArrivalTime { get; set; }

        public string? Route { get; set; }

        public string? Departure { get; set; }

        public string? Arrival { get; set; }

        [ForeignKey("User")]
        public int UserCreateID { get; set; }

        [JsonIgnore]
        public User User { get; set; }

        [JsonIgnore]
        public ICollection<Document> documents { get; set; }
    }
}
