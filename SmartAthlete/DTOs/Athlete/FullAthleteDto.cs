using SmartAthlete.DTOs.AthleteInjury;
using SmartAthlete.DTOs.Coach;
using SmartAthlete.DTOs.Sport;

namespace SmartAthlete.DTOs.Athlete;

/// <summary>
/// Athlete Data Transfer Object.
/// </summary>
public class FullAthleteDto : BaseAthleteDto
{
    /// <summary>The unique identifier of the athlete.</summary>
    public Guid Id { get; set; }
    
    /// <summary>The unique identifier of the athlete's coach.</summary>
    public Guid CoachId { get; set; }
    
    /// <summary>The athlete's coach.</summary>
    public FullCoachDto? Coach { get; set; }
    
    /// <summary>The unique identifier of the athlete's sport.</summary>
    public int SportId { get; set; } // foreign key
    
    /// <summary>The athlete's sport.</summary>
    public FullSportDto? Sport { get; set; }
    
    /// <summary>A list of injuries sustained by the athlete.</summary>
    public ICollection<AthleteInjury.GetInjuryForAthleteDto> AthleteInjuries { get; set; } = [];
}