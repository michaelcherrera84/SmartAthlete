namespace SmartAthlete.DTOs.Sport;

/// <summary>
/// DTO representing a sport to be edited.
/// </summary>
public class EditSportDto : BaseSportDto
{
    /// <summary>The unique identifier of the sport.</summary>
    public int Id { get; set; }
}