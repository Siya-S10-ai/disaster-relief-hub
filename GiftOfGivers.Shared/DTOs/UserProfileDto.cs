using System.ComponentModel.DataAnnotations;

namespace GiftOfGivers.Shared.DTOs
{
    public class UserProfileDto
    {
        public string Id { get; set; } = "";
        
        [Required]
        public string FirstName { get; set; } = "";
        
        [Required]
        public string LastName { get; set; } = "";
        
        [Required]
        public string UserName { get; set; } = "";
        
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";
        
        public string Phone { get; set; } = "";
        
        public string Role { get; set; } = "";
        
        public string? ProfilePicture { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }
    }
}