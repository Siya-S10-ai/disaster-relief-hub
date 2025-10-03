namespace GiftOfGivers.Shared.Models
{
    public class Donation
    {
        public long DonationId { get; set; }
        public string Category { get; set; } = "";
        public double? Amount { get; set; }
        public long? UserId { get; set; }
    }
}