using SmartAthlete.DTOs.Athlete;
using SmartAthlete.DTOs.Injury;

namespace SmartAthlete.DTOs.AthleteInjury;

/// <summary>
/// Athlete Injury Data Transfer Object.
/// </summary>
public class FullAthleteInjuriesDto : BaseAthleteInjuriesDto
{
    /// <summary>The unique identifier of the athlete that has sustained an injury.</summary>
    public Guid AthleteId { get; set; } 
    
    /// <summary>The athlete that has sustained an injury.</summary>
    public FullAthleteDto? Athlete { get; set; }

    /// <summary>The unique identifier of the sustained injury.</summary>
    public int InjuryId { get; set; } 
    
    /// <summary>The sustained injury.</summary>
    public FullInjuryDto? Injury { get; set; }
}