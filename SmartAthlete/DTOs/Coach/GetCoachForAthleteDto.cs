namespace SmartAthlete.DTOs.Coach;

/// <summary>
/// DTO representing a coach for an athlete.
/// </summary>
public class GetCoachForAthleteDto
{
    /// <summary>The unique identifier of the coach.</summary>
    public Guid Id { get; set; }
    
    /// <summary>The coach's first name.</summary>
    public string FirstName { get; set; } = string.Empty;
    
    /// <summary>The coach's last name.</summary>
    public string LastName { get; set; } = string.Empty;
    
    /// <summary>The coach's email address.</summary>
    public string Email { get; set; } = string.Empty;
}