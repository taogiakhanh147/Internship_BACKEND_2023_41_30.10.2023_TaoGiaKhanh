namespace FlightDocsSystem.DTO
{
    public class FlightConditionDTO
    {
        public string DocumentName { get; set; }
        public string Type { get; set; }
        public DateTime CreateDate { get; set; }
        public string Creator { get; set; }
        public decimal LastVersion { get; set; }
    }
}
