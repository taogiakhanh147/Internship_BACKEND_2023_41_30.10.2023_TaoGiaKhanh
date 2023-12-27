using System;
using System.ComponentModel.DataAnnotations;

namespace FlightDocsSystem.DTO
{
    public class FlightDTO
    {
        public string? FlightNo { get; set; }

        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ArrivalDate { get; set; }

        public string DepartureTime { get; set; }

        public string ArrivalTime { get; set; }

        public string? Route { get; set; }

        public string? Departure { get; set; }

        public string? Arrival { get; set; }

        [Required]
        public int UserCreateID { get; set; }
    }
}
