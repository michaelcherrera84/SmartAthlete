using SmartAthlete.DTOs.Athlete;
using SmartAthlete.DTOs.Injury;

namespace SmartAthlete.DTOs.AthleteInjury;

public class GetAthleteInjuriesDto : BaseAthleteInjuriesDto
{
    /// <summary>The athlete that has sustained an injury.</summary>
    public required GetAllAthletesDto Athlete { get; set; }
    
    /// <summary>The sustained injury.</summary>
    public required FullInjuryDto Injury { get; set; }
}