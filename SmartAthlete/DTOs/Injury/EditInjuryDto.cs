namespace SmartAthlete.DTOs.Injury;

/// <summary>
/// DTO representing an edited injury.
/// </summary>
public class EditInjuryDto : BaseInjuryDto
{
    /// <summary>The unique identifier of the injury.</summary>
    public int Id { get; set; }
}