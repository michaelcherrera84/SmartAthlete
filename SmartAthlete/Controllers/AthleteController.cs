using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartAthlete.DTOs.Athlete;
using SmartAthlete.Models;
using SmartAthlete.Services;

namespace SmartAthlete.Controllers;

/// <summary>
/// Provides API endpoints for managing <see cref="Athlete"/> entities.
/// Supports standard CRUD operations via HTTP methods.
/// </summary>
/// <param name="service">Generic service providing common CRUD operations for any entity type.</param>
/// <param name="mapper">
/// AutoMapper profile that defines how domain entities are translated to and from their corresponding DTOs.
/// </param>
[Route("[controller]")]
[ApiController]
public class AthleteController(IEntityService<Athlete> service, IMapper mapper) : ControllerBase
{
    private readonly IEntityService<Athlete> _service = service;
    private readonly IMapper _mapper = mapper;

    /// <summary>
    /// Retrieves all athletes from the database.
    /// </summary>
    /// <returns>A list of all <see cref="Athlete"/> objects.</returns>
    /// <response code="200">Returns the list of athletes.</response>
    [HttpGet]
    public async Task<ActionResult<List<GetAllAthletesDto>>> GetAthletes()
    {
        var athletes = await _service.GetAllAsync();
        return Ok(_mapper.Map<List<GetAllAthletesDto>>(athletes));
    }

    /// <summary>
    /// Retrieves a specific athlete by its unique identifier.
    /// </summary>
    /// <param name="id">The ID of the athlete to retrieve.</param>
    /// <returns>The requested <see cref="Athlete"/> object if found.</returns>
    /// <response code="200">Returns the requested athlete.</response>
    /// <response code="404">If the athlete with the specified ID does not exist.</response>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetOneAthleteDto>> GetAthlete(Guid id)
    {
        var athlete = await _service.GetByIdAsync(id);
        if (athlete == null) return NotFound("Athlete not found.");
        return Ok(_mapper.Map<GetOneAthleteDto>(athlete));
    }

    /// <summary>
    /// Adds a new athlete to the database.
    /// </summary>
    /// <param name="newAthlete">The <see cref="Athlete"/> object to add.</param>
    /// <returns>The newly created <see cref="Athlete"/> with its assigned ID.</returns>
    /// <response code="201">If the athlete is successfully created.</response>
    /// <response code="400">If the provided athlete data is invalid.</response>
    [HttpPost]
    public async Task<ActionResult<GetOneAthleteDto>> AddAthlete(CreateAthleteDto newAthlete)
    {
        var athlete = _mapper.Map<Athlete>(newAthlete);
        await _service.AddAsync(athlete);
        return CreatedAtAction(nameof(GetAthlete), new { id = athlete.Id }, _mapper.Map<GetOneAthleteDto>(athlete));
    }
    
    /// <summary>
    /// Updates an existing athlete in the database.
    /// </summary>
    /// <param name="id">The ID of the Athlete to update.</param>
    /// <param name="updatedAthlete">The updated <see cref="Athlete"/> data.</param>
    /// <returns>The updated <see cref="Athlete"/> data if the update is successful.</returns>
    /// <response code="202">If the athlete was successfully updated.</response>
    /// <response code="404">If the athlete with the specified ID does not exist.</response>
    [HttpPut("{id:guid}")]
    public async Task<ActionResult<GetOneAthleteDto>> UpdateAthlete(Guid id, [FromBody] EditAthleteDto updatedAthlete)
    {
        var athlete = await _service.GetByIdAsync(id);
        if (athlete is null) return NotFound("Athlete not found.");
        
        _mapper.Map(updatedAthlete, athlete);
        await _service.UpdateAsync(athlete);
        
        // return AcceptedAtAction(nameof(GetAthlete), new { id = athlete.Id }, _mapper.Map<GetOneAthleteDto>(athlete));
        
        athlete = await _service.GetByIdAsync(id);
        return Ok(_mapper.Map<GetOneAthleteDto>(athlete));
    }

    /// <summary>
    /// Deletes an athlete from the database.
    /// </summary>
    /// <param name="id">The ID of the athlete to delete.</param>
    /// <returns>A <see cref="NoContentResult"/> if the deletion is successful.</returns>
    /// <response code="204">If the athlete was successfully deleted.</response>
    /// <response code="404">If the athlete with the specified ID does not exist.</response>
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAthlete(Guid id)
    {
        var deleted = await _service.DeleteAsync(id);
        return deleted ? NoContent() : NotFound("Athlete not found.");
    }
}