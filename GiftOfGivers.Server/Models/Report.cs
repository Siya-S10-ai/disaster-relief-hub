using System.ComponentModel.DataAnnotations;

namespace GiftOfGivers.Server.Models;

public class Report
{
    [Key]
    public Guid Id { get; set; }
    [Required] public string ReporterName { get; set; } = "";
    [Required] public string ReporterEmail { get; set; } = "";
    public string ReporterPhone { get; set; } = "";
    [Required] public string ReportType { get; set; } = "";
    public string Location { get; set; } = "";
    public string Description { get; set; } = "";
    public string Urgency { get; set; } = "";
    public string? ImageUrl { get; set; }
    public string Status { get; set; } = "Under Review";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
