namespace SmartAthlete.DTOs.Athlete;

/// <summary>
/// DTO representing a new athlete.
/// </summary>
public class CreateAthleteDto : BaseAthleteDto
{
    /// <summary>The unique identifier of the athlete's coach.</summary>
    public Guid? CoachId { get; set; }
    
    /// <summary>The unique identifier of the athlete's sport.</summary>
    public int? SportId { get; set; } // foreign key
}