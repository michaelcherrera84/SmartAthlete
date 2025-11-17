namespace SmartAthlete.DTOs.AthleteInjury;

/// <summary>
/// Base class for DTOs representing an athlete injury incident.
/// </summary>
public class BaseAthleteInjuriesDto
{
    /// <summary>The date of the injury incident.</summary>
    public DateTime Date { get; set; }
    
    /// <summary>A description of the injury incident.</summary>
    public string Description { get; set; } = "";
}