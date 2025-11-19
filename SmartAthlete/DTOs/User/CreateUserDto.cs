namespace SmartAthlete.DTOs.User;

/// <summary>
/// DTO representing a new user.
/// </summary>
public class CreateUserDto : BaseUserDto
{
    /// <summary>The hashed password of the user.</summary>
    public string PasswordHash { get; set; } = string.Empty;
    
    /// <summary>The role of the user.</summary>
    public string? Role { get; set; }
}