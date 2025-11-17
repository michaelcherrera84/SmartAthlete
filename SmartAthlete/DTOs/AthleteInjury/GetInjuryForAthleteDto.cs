using SmartAthlete.DTOs.Injury;

namespace SmartAthlete.DTOs.AthleteInjury;

/// <summary>
/// DTO representing an athlete injury incident.
/// </summary>
public class GetInjuryForAthleteDto : BaseAthleteInjuriesDto
{
    /// <summary>The sustained injury.</summary>
    public FullInjuryDto? Injury { get; set; }
}