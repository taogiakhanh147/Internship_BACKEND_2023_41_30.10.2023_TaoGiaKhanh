namespace FlightDocsSystem.DTO
{
    public class DocumentByConditionDTO
    {
        public string DocumentName { get; set; }
        public string Type { get; set; }
        public DateTime CreateDate { get; set; }
        public string Creator { get; set; }
        public string FlightNo { get; set; }
    }
}
