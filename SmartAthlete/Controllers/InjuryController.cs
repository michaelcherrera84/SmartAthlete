using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartAthlete.DTOs.Injury;
using SmartAthlete.Models;
using SmartAthlete.Services;

namespace SmartAthlete.Controllers;

/// <summary>
/// Provides API endpoints for managing <see cref="Injury"/> entities.
/// Supports standard CRUD operations via HTTP methods.
/// </summary>
/// <param name="service">Generic service providing common CRUD operations for any entity type.</param>
/// <param name="mapper">
/// AutoMapper profile that defines how domain entities are translated to and from their corresponding DTOs.
/// </param>
[Route("[controller]")]
[ApiController]
public class InjuryController(IEntityService<Injury> service, IMapper mapper) : ControllerBase
{
    private readonly IEntityService<Injury> _service = service;
    private readonly IMapper _mapper = mapper;

    /// <summary>
    /// Retrieves all injuries from the database.
    /// </summary>
    /// <returns>A list of all <see cref="Injury"/> objects.</returns>
    /// <response code="200">Returns the list of injuries.</response>
    [HttpGet]
    public async Task<ActionResult<List<FullInjuryDto>>> GetInjuries()
    {
        var injuries = await _service.GetAllAsync();
        return Ok(_mapper.Map<List<FullInjuryDto>>(injuries));
    }
    
    /// <summary>
    /// Retrieves a specific injury by its unique identifier.
    /// </summary>
    /// <param name="id">The ID of the injury to retrieve.</param>
    /// <returns>The requested <see cref="Injury"/> object if found.</returns>
    /// <response code="200">Returns the requested injury.</response>
    /// <response code="404">If the injury with the specified ID does not exist.</response>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<FullInjuryDto>> GetInjury(int id)
    {
        var injury = await _service.GetByIdAsync(id);
        if (injury is null) return NotFound("Injury not found.");
        return Ok(_mapper.Map<FullInjuryDto>(injury));
    }
    
    /// <summary>
    /// Adds a new injury to the database.
    /// </summary>
    /// <param name="newInjury">The <see cref="Injury"/> object to add.</param>
    /// <returns>The newly created <see cref="Injury"/> with its assigned ID.</returns>
    /// <response code="201">If the injury is successfully created.</response>
    /// <response code="400">If the provided injury data is invalid.</response>
    [HttpPost]
    public async Task<ActionResult<FullInjuryDto>> AddInjury(CreateInjuryDto newInjury)
    {
        var injury = _mapper.Map<Injury>(newInjury);
        await _service.AddAsync(injury);
        return CreatedAtAction(nameof(GetInjury), new { id = injury.Id }, _mapper.Map<FullInjuryDto>(injury));
    }
    
    /// <summary>
    /// Updates an existing injury in the database.
    /// </summary>
    /// <param name="id">The ID of the injury to update.</param>
    /// <param name="updatedInjury">The updated <see cref="Injury"/> data.</param>
    /// <returns>The updated <see cref="Injury"/> data if the update is successful.</returns>
    /// <response code="200">If the injury was successfully updated.</response>
    /// <response code="404">If the injury with the specified ID does not exist.</response>
    [HttpPut("{id:int}")]
    public async Task<ActionResult<FullInjuryDto>> UpdateInjury(int id, EditInjuryDto updatedInjury)
    {
        var injury = await _service.GetByIdAsync(id);
        if (injury is null) return NotFound("Injury not found.");
        
        _mapper.Map(updatedInjury, injury);
        await _service.UpdateAsync(injury);
        return Ok(_mapper.Map<FullInjuryDto>(injury));
    }
    
    /// <summary>
    /// Deletes an injury from the database.
    /// </summary>
    /// <param name="id">The ID of the injury to delete.</param>
    /// <returns>A <see cref="NoContentResult"/> if the deletion is successful.</returns>
    /// <response code="204">If the injury was successfully deleted.</response>
    /// <response code="404">If the injury with the specified ID does not exist.</response>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteInjury(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        return deleted ? NoContent() : NotFound("Injury not found.");
    }
}