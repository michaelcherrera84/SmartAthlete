namespace SmartAthlete.DTOs.Athlete;

/// <summary>
/// DTO representing a list of athletes.
/// </summary>
public class GetAllAthletesDto : BaseAthleteDto
{
    /// <summary>The unique identifier of the athlete.</summary>
    public Guid Id { get; set; }
}