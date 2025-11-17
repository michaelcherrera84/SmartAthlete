using SmartAthlete.DTOs.Sport;

namespace SmartAthlete.DTOs.Coach;

public class GetOneCoachDto : BaseCoachDto
{
    /// <summary>The unique identifier of the coach.</summary>
    public Guid Id { get; set; }
    
    /// <summary>The sport the coach coaches.</summary>
    public FullSportDto? Sport { get; set; }
}