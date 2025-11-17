using Microsoft.EntityFrameworkCore;
using SmartAthlete.Data;
using SmartAthlete.Models;

namespace SmartAthlete.Services;

/// <summary>
/// Athlete service.
/// </summary>
/// <param name="context">The application's database context.</param>
public class AthleteService(AppDbContext context) : EntityService<Athlete>(context)
{
    /// <inheritdoc/>
    protected override IQueryable<Athlete> QueryWithIncludes() =>
        _dbSet
            .Include(a => a.Coach)
            .Include(a => a.Sport)
            .Include(a => a.AthleteInjuries)
            .ThenInclude(ai => ai.Injury);
}