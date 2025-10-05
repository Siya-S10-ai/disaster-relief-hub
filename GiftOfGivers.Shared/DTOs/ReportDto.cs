namespace GiftOfGivers.Shared.DTOs;

public class ReportDto
{
    public Guid Id { get; set; }
    public string ReporterName { get; set; } = "";
    public string ReporterEmail { get; set; } = "";
    public string ReporterPhone { get; set; } = "";
    public string ReportType { get; set; } = "";
    public string Location { get; set; } = "";
    public string Description { get; set; } = "";
    public string Urgency { get; set; } = "";
    public string? ImageUrl { get; set; }
    public string Status { get; set; } = "Under Review";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}