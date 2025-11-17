using Microsoft.EntityFrameworkCore;
using SmartAthlete.Data;

namespace SmartAthlete.Services;

/// <summary>
/// Generic service providing common CRUD operations for any entity type.
/// </summary>
/// <typeparam name="T">The entity type this service will manage.</typeparam>
public class EntityService<T> : IEntityService<T> where T : class
{
    private readonly AppDbContext _context;
    protected readonly DbSet<T> _dbSet;
    
    /// <summary>
    /// Allows for including related entities in the query.
    /// </summary>
    protected virtual IQueryable<T> QueryWithIncludes() => _dbSet;
    
    /// <summary>
    /// Creates a new instance of the generic entity service.
    /// </summary>
    /// <param name="context">The application's DbContext.</param>
    public EntityService(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }
    
    /// <inheritdoc/>
    public virtual async Task<List<T>> GetAllAsync() => await _dbSet.ToListAsync();
    
    /// <inheritdoc/>
    public async Task<T?> GetByIdAsync(object id)
    {
        return await QueryWithIncludes()
            .FirstOrDefaultAsync(e => EF.Property<object>(e, "Id") == id);
    }

    /// <inheritdoc/>
    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task UpdateAsync(T entity)
    {
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteAsync(object id)
    {
        var entity = await GetByIdAsync(id);
        if (entity is null) return false;
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}