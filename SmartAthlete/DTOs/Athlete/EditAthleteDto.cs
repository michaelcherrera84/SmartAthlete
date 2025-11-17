namespace SmartAthlete.DTOs.Athlete;

/// <summary>
/// DTO representing an athlete to be edited.
/// </summary>
public class EditAthleteDto : BaseAthleteDto
{
    /// <summary>The unique identifier of the athlete.</summary>
    public Guid Id { get; set; }
    
    /// <summary>The unique identifier of the athlete's coach.</summary>
    public Guid? CoachId { get; set; }
    
    /// <summary>The unique identifier of the athlete's sport.</summary>
    public int? SportId { get; set; } 
}