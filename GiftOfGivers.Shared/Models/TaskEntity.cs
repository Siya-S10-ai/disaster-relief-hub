namespace GiftOfGivers.Shared.Models
{
    public class TaskEntity
    {
        public long TaskId { get; set; }
        public string Description { get; set; } = "";
        public string? Status { get; set; }
        public long? VolunteerId { get; set; }
    }
}