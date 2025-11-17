namespace SmartAthlete.DTOs.Coach;

/// <summary>
/// DTO representing a new coach.
/// </summary>
public class CreateCoachDto : BaseCoachDto
{
    /// <summary>The unique identifier of the sport the coach coaches.</summary>
    public int SportId { get; set; }
}