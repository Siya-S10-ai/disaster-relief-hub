namespace GiftOfGivers.Client.Services;

public interface IAuthService
{
    Task<AuthResult> LoginAsync(LoginDto loginForm);
    Task<AuthResult> RegisterAsync(RegisterDto registerForm);
    Task LogoutAsync();
    Task<bool> IsAuthenticatedAsync();
    Task<UserProfileDto?> GetCurrentUserAsync();
}

public class LoginDto
{
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
    public bool RememberMe { get; set; }
}

public class RegisterDto
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string UserName { get; set; } = "";
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
    public string ConfirmPassword { get; set; } = "";
    public string Role { get; set; } = "";
}

public class AuthResult
{
    public bool Success { get; set; }
    public string Message { get; set; } = "";
    public UserProfileDto? User { get; set; }
}