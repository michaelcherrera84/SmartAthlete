using Microsoft.EntityFrameworkCore;
using SmartAthlete.Data;
using SmartAthlete.Models;

namespace SmartAthlete.Services;

/// <summary>
/// Athlete Injuries service.
/// </summary>
/// <param name="context">The application's database context.</param>
public class AthleteInjuriesService(AppDbContext context) : EntityService<AthleteInjuries>(context), IAthleteInjuriesService
{
    private readonly AppDbContext _context = context;
    
    /// <inheritdoc/>
    protected override IQueryable<AthleteInjuries> QueryWithIncludes() =>
        _dbSet
            .Include(ais => ais.Athlete)
            .Include(ais => ais.Injury);
    
    /// <inheritdoc/>
    public override async Task<List<AthleteInjuries>> GetAllAsync()
    {
        return await QueryWithIncludes().ToListAsync();
    }
    
    /// <inheritdoc/>
    public async Task<AthleteInjuries?> GetByKeyAsync(Guid athleteId, int injuryId, DateTime date)
    {
        return await _context.AthleteInjuries
            .Include(ai => ai.Athlete)
            .Include(ai => ai.Injury)
            .FirstOrDefaultAsync(ai =>
                ai.AthleteId == athleteId &&
                ai.InjuryId == injuryId &&
                ai.Date == date);
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteAsync(Guid athleteId, int injuryId, DateTime date)
    {
        var athleteInjury = await GetByKeyAsync(athleteId, injuryId, date);
        if (athleteInjury is null) return false;
        _dbSet.Remove(athleteInjury);
        await _context.SaveChangesAsync();
        return true;
    }
}