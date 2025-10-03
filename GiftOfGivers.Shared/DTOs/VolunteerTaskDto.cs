namespace GiftOfGivers.Shared.DTOs;

public class VolunteerTaskDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public string Category { get; set; } = "";
    public string Status { get; set; } = "Active";
    public string Urgency { get; set; } = "";
    public int Volunteers { get; set; }
    public int MaxVolunteers { get; set; }
    public string Description { get; set; } = "";
}
