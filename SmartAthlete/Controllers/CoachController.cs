using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartAthlete.DTOs.Coach;
using SmartAthlete.Models;
using SmartAthlete.Services;

namespace SmartAthlete.Controllers;

/// <summary>
/// Provides API endpoints for managing <see cref="Coach"/> entities.
/// Supports standard CRUD operations via HTTP methods.
/// </summary>
/// <param name="service">Generic service providing common CRUD operations for any entity type.</param>
/// <param name="mapper">
/// AutoMapper profile that defines how domain entities are translated to and from their corresponding DTOs.
/// </param>
[Route("[controller]")]
[ApiController]
public class CoachController(IEntityService<Coach> service, IMapper mapper) : ControllerBase
{
    private readonly IEntityService<Coach> _service = service;
    private readonly IMapper _mapper = mapper;
    
    /// <summary>
    /// Retrieves all coaches from the database.
    /// </summary>
    /// <returns>A list of all <see cref="Coach"/> objects.</returns>
    /// <response code="200">Returns the list of coaches.</response>
    [HttpGet]
    public async Task<ActionResult<LinkedList<GetAllCoachesDto>>> GetCoaches()
    {
        var coaches = await _service.GetAllAsync();
        return Ok(_mapper.Map<LinkedList<GetAllCoachesDto>>(coaches));
    }
    
    /// <summary>
    /// Retrieves a specific coach by its unique identifier.
    /// </summary>
    /// <param name="id">The ID of the coach to retrieve.</param>
    /// <returns>The requested <see cref="Coach"/> object if found.</returns>
    /// <response code="200">Returns the requested coach.</response>
    /// <response code="404">If the coach with the specified ID does not exist.</response>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetOneCoachDto>> GetCoach(Guid id)
    {
        var coach = await _service.GetByIdAsync(id);
        if (coach is null) return NotFound("Coach not found.");
        return Ok(_mapper.Map<GetOneCoachDto>(coach));
    }
    
    /// <summary>
    /// Adds a new Coach to the database.
    /// </summary>
    /// <param name="newCoach">The <see cref="Coach"/> object to add.</param>
    /// <returns>The newly created <see cref="Coach"/> with its assigned ID.</returns>
    /// <response code="201">If the coach is successfully created.</response>
    /// <response code="400">If the provided coach data is invalid.</response>
    [HttpPost]
    public async Task<ActionResult<GetOneCoachDto>> AddCoach(CreateCoachDto newCoach)
    {
        var coach = _mapper.Map<Coach>(newCoach);
        await _service.AddAsync(coach);
        return CreatedAtAction(nameof(GetCoach), new { id = coach.Id }, _mapper.Map<GetOneCoachDto>(coach));
    }
    
    /// <summary>
    /// Updates an existing coach in the database.
    /// </summary>
    /// <param name="id">The ID of the coach to update.</param>
    /// <param name="updatedCoach">The updated <see cref="Coach"/> data.</param>
    /// <returns>The updated <see cref="Coach"/> data if the update is successful.</returns>
    /// <response code="202">If the coach was successfully updated.</response>
    /// <response code="404">If the coach with the specified ID does not exist.</response>
    [HttpPut("{id:guid}")]
    public async Task<ActionResult<GetOneCoachDto>> UpdateCoach(Guid id, EditCoachDto updatedCoach)
    {
        var coach = await _service.GetByIdAsync(id);
        if (coach is null) return NotFound("Coach not found.");
        
        _mapper.Map(updatedCoach, coach);
        await _service.UpdateAsync(coach);
        
        coach = await _service.GetByIdAsync(id);
        return Ok(_mapper.Map<GetOneCoachDto>(coach));
    }
    
    /// <summary>
    /// Deletes a coach from the database.
    /// </summary>
    /// <param name="id">The ID of the coach to delete.</param>
    /// <returns>A <see cref="NoContentResult"/> if the deletion is successful.</returns>
    /// <response code="204">If the coach was successfully deleted.</response>
    /// <response code="404">If the coach with the specified ID does not exist.</response>
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteCoach(Guid id)
    {
        var deleted = await _service.DeleteAsync(id);
        return deleted ? NoContent() : NotFound("Coach not found.");
    }
}