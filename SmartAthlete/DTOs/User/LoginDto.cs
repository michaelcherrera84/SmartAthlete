namespace SmartAthlete.DTOs.User;

/// <summary>
/// DTO representing a user's login credentials.'
/// </summary>
public class LoginDto
{
    /// <summary>The username of the user.</summary>
    public string Username { get; set; } = string.Empty;
    
    /// <summary>The hashed password of the user.</summary>
    public string PasswordHash { get; set; } = string.Empty;
}