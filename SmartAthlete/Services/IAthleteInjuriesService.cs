using SmartAthlete.Models;

namespace SmartAthlete.Services;

/// <summary>
/// Athlete Injuries service.
/// </summary>
public interface IAthleteInjuriesService : IEntityService<AthleteInjuries>
{
    /// <summary>
    /// Retrieves an athlete injury by athlete ID, injury ID, and date.
    /// </summary>
    /// <param name="athleteId">The ID of the injured athlete</param>
    /// <param name="injuryId">The ID of the injury</param>
    /// <param name="date">The date of the incident</param>
    Task<AthleteInjuries?> GetByKeyAsync(Guid athleteId, int injuryId, DateTime date);
    
    /// <summary>
    /// Deletes an athlete injury by athlete ID, injury ID, and date.
    /// </summary>
    /// <param name="athleteId">The ID of the injured athlete</param>
    /// <param name="injuryId">The ID of the injury</param>
    /// <param name="date">The date of the incident</param>
    Task<bool> DeleteAsync(Guid athleteId, int injuryId, DateTime date);
}