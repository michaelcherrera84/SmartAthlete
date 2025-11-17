using Microsoft.EntityFrameworkCore;
using SmartAthlete.Data;
using SmartAthlete.Models;

namespace SmartAthlete.Services;

/// <summary>
/// Coach service.
/// </summary>
/// <param name="context">The application's database context.</param>
public class CoachService(AppDbContext context) : EntityService<Coach>(context)
{
    /// <inheritdoc/>
    protected override IQueryable<Coach> QueryWithIncludes() =>
        _dbSet
            .Include(c => c.Sport);
}