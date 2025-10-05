using Microsoft.AspNetCore.Identity;

namespace GiftOfGivers.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string UserName { get; set; } = "";
        public string Role { get; set; } = "User"; // Default role
        public string? ProfilePicture { get; set; }
        public string? DisplayRole { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }

}