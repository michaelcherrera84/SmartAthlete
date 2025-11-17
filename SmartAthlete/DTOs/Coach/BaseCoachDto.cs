namespace SmartAthlete.DTOs.Coach;

/// <summary>
/// Base class for DTOs representing coaches.
/// </summary>
public class BaseCoachDto
{
    /// <summary>The coach's first name.</summary>
    public string FirstName { get; set; } = string.Empty;
    
    /// <summary>The coach's middle name.</summary>
    public string MiddleName { get; set; } = string.Empty;
    
    /// <summary>The coach's last name.</summary>
    public string LastName { get; set; } = string.Empty;
    
    /// <summary>The coach's date of birth.</summary>
    public DateTime DateOfBirth { get; set; }
    
    /// <summary>The coach's email address.</summary>
    public string Email { get; set; } = string.Empty;
}