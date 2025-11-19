namespace SmartAthlete.DTOs.User;

/// <summary>
/// Base DTO representing a user.
/// </summary>
public class BaseUserDto
{
    /// <summary>The user's first name.</summary>
    public string FirstName { get; set; } = string.Empty;
    
    /// <summary>The user's last name.</summary>
    public string LastName { get; set; } = string.Empty;
    
    /// <summary>The user's email address.</summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>The username of the user.</summary>
    public string Username { get; set; } = string.Empty;
}