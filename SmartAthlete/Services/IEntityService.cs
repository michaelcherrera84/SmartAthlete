namespace SmartAthlete.Services;

/// <summary>
/// Generic service providing common CRUD operations for any entity type.
/// </summary>
/// <typeparam name="T">The entity type this service will manage.</typeparam>
public interface IEntityService<T> where T : class
{
    /// <summary>
    /// Retrieves all records of the entity type.
    /// </summary>
    Task<List<T>> GetAllAsync();
    
    /// <summary>
    /// Retrieves a single entity by its primary key ID.
    /// Returns null if not found.
    /// </summary>
    /// <param name="id">The primary key value.</param>
    Task<T?> GetByIdAsync(Object id);
    
    /// <summary>
    /// Inserts a new entity and saves changes.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    Task AddAsync(T entity);
    
    /// <summary>
    /// Updates an existing entity and saves changes.
    /// The entity must already be tracked or have a valid key.
    /// </summary>
    /// <param name="entity">The updated entity.</param>
    Task UpdateAsync(T entity);
    
    /// <summary>
    /// Deletes an entity by primary key ID.
    /// If the entity does not exist, the operation is ignored.
    /// </summary>
    /// <param name="id">The primary key of the entity to delete.</param>
    Task<bool> DeleteAsync(Object id);
}