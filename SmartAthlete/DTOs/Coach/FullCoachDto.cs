using SmartAthlete.DTOs.Sport;

namespace SmartAthlete.DTOs.Coach;

/// <summary>
/// Coach Data Transfer Object.
/// </summary>
public class FullCoachDto : BaseCoachDto
{
    /// <summary>The unique identifier of the coach.</summary>
    public Guid Id { get; set; }
    
    /// <summary>The unique identifier of the sport the coach coaches.</summary>
    public int SportId { get; set; }
    
    /// <summary>The sport the coach coaches.</summary>
    public FullSportDto? Sport { get; set; }
}