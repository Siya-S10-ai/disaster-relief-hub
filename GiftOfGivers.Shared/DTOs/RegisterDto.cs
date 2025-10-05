using System.ComponentModel.DataAnnotations;

namespace GiftOfGivers.Shared.DTOs
{
    public class RegisterDto
    {
        [Required] public string FirstName { get; set; } = "";
        [Required] public string LastName { get; set; } = "";
        [Required] public string UserName { get; set; } = "";
        [Required][EmailAddress] public string Email { get; set; } = "";
        public string? Phone { get; set; }
        [Required] public string Role { get; set; } = "Volunteer"; // "Volunteer" | "Reporter"
        [Required][MinLength(8)] public string Password { get; set; } = "";
        [Required][Compare(nameof(Password))] public string ConfirmPassword { get; set; } = "";
    }
}
