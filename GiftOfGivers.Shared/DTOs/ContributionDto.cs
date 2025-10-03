namespace GiftOfGivers.Shared.DTOs;

public class ContributionDto
{
    public Guid Id { get; set; }
    public string TaskName { get; set; } = "";
    public string Status { get; set; } = "";
    public string Owner { get; set; } = "";
    public int HoursContributed { get; set; }
    public DateTime? CompletedDate { get; set; }
}
