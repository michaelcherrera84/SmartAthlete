namespace SmartAthlete.DTOs.Coach;

/// <summary>
/// DTO representing an edited coach.
/// </summary>
public class EditCoachDto : BaseCoachDto
{
    /// <summary>The unique identifier of the coach.</summary>
    public Guid Id { get; set; }
    
    /// <summary>The unique identifier of the sport the coach coaches.</summary>
    public int SportId { get; set; }
}