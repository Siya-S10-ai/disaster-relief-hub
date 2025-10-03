namespace GiftOfGivers.Shared.Models
{
    public class IncidentReport
    {
        public long ReportId { get; set; }
        public long ReporterId { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string? ReportType { get; set; }
    }
}