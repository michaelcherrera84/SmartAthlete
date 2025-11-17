namespace SmartAthlete.DTOs.AthleteInjury;

/// <summary>
/// DTO representing a new athlete injury incident.
/// </summary>
public class CreateAthleteInjuriesDto : BaseAthleteInjuriesDto
{
    /// <summary>The unique identifier of the athlete that has sustained an injury.</summary>
    public Guid AthleteId { get; set; } 
    
    /// <summary>The unique identifier of the sustained injury.</summary>
    public int InjuryId { get; set; } 
}