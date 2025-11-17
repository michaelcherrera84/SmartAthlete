namespace SmartAthlete.DTOs.Coach;

/// <summary>
/// DTO representing a collection of coaches.
/// </summary>
public class GetAllCoachesDto : BaseCoachDto
{
    /// <summary>The unique identifier of the coach.</summary>
    public Guid Id { get; set; }
}