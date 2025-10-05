namespace GiftOfGivers.Shared.DTOs
{
    public class DonationFormDto
    {
        public decimal Amount { get; set; }
        public string Type { get; set; } = "";
        public string Frequency { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Message { get; set; } = "";
    }
}
