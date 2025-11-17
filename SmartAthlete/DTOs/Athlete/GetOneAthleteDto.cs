using SmartAthlete.DTOs.AthleteInjury;
using SmartAthlete.DTOs.Coach;
using SmartAthlete.DTOs.Sport;

namespace SmartAthlete.DTOs.Athlete;

/// <summary>
/// DTO representing a single athlete.
/// </summary>
public class GetOneAthleteDto : BaseAthleteDto
{
    /// <summary>The unique identifier of the athlete.</summary>
    public Guid Id { get; set; }
    
    /// <summary>The athlete's coach.</summary>
    public GetCoachForAthleteDto? Coach { get; set; }
    
    /// <summary>The athlete's sport.</summary>
    public FullSportDto? Sport { get; set; }
    
    /// <summary>A list of injuries sustained by the athlete.</summary>
    public ICollection<GetInjuryForAthleteDto> AthleteInjuries { get; set; } = [];
}