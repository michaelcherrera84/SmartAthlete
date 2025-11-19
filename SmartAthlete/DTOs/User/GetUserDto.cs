namespace SmartAthlete.DTOs.User;

/// <summary>
/// DTO representing a user.
/// </summary>
public class GetUserDto : BaseUserDto
{
    /// <summary>The unique identifier of the user.</summary>
    public Guid Id { get; set; }
    
    /// <summary>The role of the user.</summary>
    public string Role { get; set; } = string.Empty;
}