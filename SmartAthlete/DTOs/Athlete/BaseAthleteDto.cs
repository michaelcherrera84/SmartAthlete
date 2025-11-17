namespace SmartAthlete.DTOs.Athlete;

/// <summary>
/// Base class for DTOs representing athletes.
/// </summary>
public class BaseAthleteDto
{
    /// <summary>The athlete's first name.</summary>
    public string FirstName { get; set; } = "";

    /// <summary>The athlete's middle name.</summary>
    public string MiddleName { get; set; } = "";
    
    /// <summary>The athlete's last name.</summary>
    public string LastName { get; set; } = "";
    
    /// <summary>The athlete's date of birth.</summary>
    public DateTime DateOfBirth { get; set; }
    
    /// <summary>The athlete's email address.</summary>
    public string Email { get; set; } = "";
}