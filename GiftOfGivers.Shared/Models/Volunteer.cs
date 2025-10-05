namespace GiftOfGivers.Shared.Models
{
    public class Volunteer
    {
        public long VolunteerId { get; set; }
        public long UserId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}