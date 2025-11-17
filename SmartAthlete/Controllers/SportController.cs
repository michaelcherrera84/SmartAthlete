using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartAthlete.DTOs.Sport;
using SmartAthlete.Models;
using SmartAthlete.Services;

namespace SmartAthlete.Controllers;

/// <summary>
/// Provides API endpoints for managing <see cref="Sport"/> entities.
/// Supports standard CRUD operations via HTTP methods.
/// </summary>
/// <param name="service">Generic service providing common CRUD operations for any entity type.</param>
/// <param name="mapper">
/// AutoMapper profile that defines how domain entities are translated to and from their corresponding DTOs.
/// </param>
[Route("[controller]")]
[ApiController]
public class SportController(IEntityService<Sport> service, IMapper mapper) : ControllerBase
{
    private readonly IEntityService<Sport> _service = service;
    private readonly IMapper _mapper = mapper;

    /// <summary>
    /// Retrieves all sports from the database.
    /// </summary>
    /// <returns>A list of all <see cref="Sport"/> objects.</returns>
    /// <response code="200">Returns the list of sports.</response>
    [HttpGet]
    public async Task<ActionResult<List<FullSportDto>>> GetSports()
    {
        var sports = await _service.GetAllAsync();
        return Ok(_mapper.Map<List<FullSportDto>>(sports));
    }
    
    /// <summary>
    /// Retrieves a specific sport by its unique identifier.
    /// </summary>
    /// <param name="id">The ID of the sport to retrieve.</param>
    /// <returns>The requested <see cref="Sport"/> object if found.</returns>
    /// <response code="200">Returns the requested sport.</response>
    /// <response code="404">If the sport with the specified ID does not exist.</response>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<FullSportDto>> GetSport(int id)
    {
        var sport = await _service.GetByIdAsync(id);
        if (sport is null) return NotFound("Sport not found.");
        return Ok(_mapper.Map<FullSportDto>(sport));
    }
    
    /// <summary>
    /// Adds a new sport to the database.
    /// </summary>
    /// <param name="newSport">The <see cref="Sport"/> object to add.</param>
    /// <returns>The newly created <see cref="Sport"/> with its assigned ID.</returns>
    /// <response code="201">If the sport is successfully created.</response>
    /// <response code="400">If the provided sport data is invalid.</response>
    [HttpPost]
    public async Task<ActionResult<FullSportDto>> AddSport(CreateSportDto newSport)
    {
        var sport = _mapper.Map<Sport>(newSport);
        await _service.AddAsync(sport);
        return CreatedAtAction(nameof(GetSport), new { id = sport.Id }, _mapper.Map<FullSportDto>(sport));
    }
    
    /// <summary>
    /// Updates an existing sport in the database.
    /// </summary>
    /// <param name="id">The ID of the sport to update.</param>
    /// <param name="updatedSport">The updated <see cref="Sport"/> data.</param>
    /// <returns>The updated <see cref="Sport"/> data if the update is successful.</returns>
    /// /// <response code="200">If the sport was successfully updated.</response>
    /// <response code="404">If the sport with the specified ID does not exist.</response>
    [HttpPut("{id:int}")]
    public async Task<ActionResult<FullSportDto>> UpdateSport(int id, EditSportDto updatedSport)
    {
        var sport = await _service.GetByIdAsync(id);
        if (sport is null) return NotFound("Sport not found.");
        
        _mapper.Map(updatedSport, sport);
        await _service.UpdateAsync(sport);
        return Ok(_mapper.Map<FullSportDto>(sport));
    }
    
    /// <summary>
    /// Deletes a sport from the database.
    /// </summary>
    /// <param name="id">The ID of the sport to delete.</param>
    /// <returns>A <see cref="NoContentResult"/> if the deletion is successful.</returns>
    /// <response code="204">If the sport was successfully deleted.</response>
    /// <response code="404">If the sport with the specified ID does not exist.</response>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteSport(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        return deleted ? NoContent() : NotFound("Sport not found.");
    }
}