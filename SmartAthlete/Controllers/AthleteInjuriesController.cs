using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartAthlete.DTOs.AthleteInjury;
using SmartAthlete.Models;
using SmartAthlete.Services;

namespace SmartAthlete.Controllers;

/// <summary>
/// Provides API endpoints for managing <see cref="AthleteInjuries"/> entities.
/// Supports standard CRUD operations via HTTP methods.
/// </summary>
/// <param name="service">Generic service providing common CRUD operations for any entity type.</param>
/// <param name="mapper">
/// AutoMapper profile that defines how domain entities are translated to and from their corresponding DTOs.
/// </param>
[Route("[controller]")]
[ApiController]
public class AthleteInjuriesController(IAthleteInjuriesService service, IMapper mapper) : ControllerBase
{
    private readonly IAthleteInjuriesService _service = service;
    private readonly IMapper _mapper = mapper;

    /// <summary>
    /// Retrieves all athlete injuries from the database.
    /// </summary>
    /// <returns>A list of all <see cref="AthleteInjuries"/> objects.</returns>
    /// <response code="200">Returns the list of athlete injuries.</response>
    [HttpGet]
    public async Task<ActionResult<List<GetAthleteInjuriesDto>>> GetAthleteInjuries()
    {
        var athleteInjuries = await _service.GetAllAsync();
        return Ok(_mapper.Map<List<GetAthleteInjuriesDto>>(athleteInjuries));
    }

    /// <summary>
    /// Retrieves a specific athlete injury from the database.
    /// </summary>
    /// <param name="athleteId">The ID of the injured athlete</param>
    /// <param name="injuryId">The ID of the injury</param>
    /// <param name="date">The date of the incident</param>
    /// <returns></returns>
    [HttpGet("{athleteId:guid}/{injuryId:int}/{date:datetime}")]
    public async Task<ActionResult<GetAthleteInjuriesDto>> GetAthleteInjury(Guid athleteId, int injuryId,
        DateTime date)
    {
        var athleteInjury = await _service.GetByKeyAsync(athleteId, injuryId, date);
        if (athleteInjury is null) return NotFound("Athlete Injury not found.");
        return Ok(_mapper.Map<GetAthleteInjuriesDto>(athleteInjury));
    }

    /// <summary>
    /// Adds a new athlete injury to the database.
    /// </summary>
    /// <param name="newAthleteInjury">The <see cref="AthleteInjuries"/> object to add.</param>
    /// <returns>The newly created <see cref="AthleteInjuries"/> with its assigned ID.</returns>
    /// <response code="201">If the athlete injury is successfully created.</response>
    /// <response code="400">If the provided athlete injury data is invalid.</response>
    [HttpPost]
    public async Task<ActionResult<GetAthleteInjuriesDto>> AddAthleteInjuries(CreateAthleteInjuriesDto newAthleteInjury)
    {
        var athleteInjury = _mapper.Map<AthleteInjuries>(newAthleteInjury);
        await _service.AddAsync(athleteInjury);
        return CreatedAtAction(nameof(GetAthleteInjury), new
            {
                athleteId = athleteInjury.AthleteId,
                injuryId = athleteInjury.InjuryId,
                date = athleteInjury.Date
            },
            _mapper.Map<GetAthleteInjuriesDto>(athleteInjury));
    }

    /// <summary>
    /// Updates an existing athlete injury in the database.
    /// </summary>
    /// <param name="athleteId">The ID of the injured athlete</param>
    /// <param name="injuryId">The ID of the injury</param>
    /// <param name="date">The date of the incident</param>
    /// <param name="updatedAthleteInjury">The updated <see cref="AthleteInjuries"/> data.</param>
    /// <returns>The updated <see cref="AthleteInjuries"/> data if the update is successful.</returns>
    /// <response code="202">If the athlete injury was successfully updated.</response>
    /// <response code="404">If the athlete injury with the specified ID does not exist.</response>
    /// <remarks>
    /// Only the description may be updated. For updates to the athlete ID, injury ID, or date, please delete
    /// the entry and add a new entry
    /// </remarks>
    [HttpPut("{athleteId:guid}/{injuryId:int}/{date:datetime}")]
    public async Task<ActionResult<GetAthleteInjuriesDto>> UpdateAthleteInjuries(Guid athleteId, int injuryId,
        DateTime date, [FromBody] EditAthleteInjuryDto updatedAthleteInjury)
    {
        var athleteInjury = await _service.GetByKeyAsync(athleteId, injuryId, date);
        if (athleteInjury is null) return NotFound("Athlete Injury not found.");

        _mapper.Map(updatedAthleteInjury, athleteInjury);
        await _service.UpdateAsync(athleteInjury);

        athleteInjury = await _service.GetByKeyAsync(athleteId, injuryId, date);
        return Ok(_mapper.Map<GetAthleteInjuriesDto>(athleteInjury));
    }
    
    /// <summary>
    /// Deletes an athlete injury from the database.
    /// </summary>
    /// <param name="athleteId">The ID of the injured athlete</param>
    /// <param name="injuryId">The ID of the injury</param>
    /// <param name="date">The date of the incident</param>
    /// <returns>A <see cref="NoContentResult"/> if the deletion is successful.</returns>
    /// <response code="204">If the athlete injury was successfully deleted.</response>
    /// <response code="404">If the athlete injury with the specified ID does not exist.</response>
    [HttpDelete("{athleteId:guid}/{injuryId:int}/{date:datetime}")]
    public async Task<ActionResult> DeleteAthleteInjuries(Guid athleteId, int injuryId, DateTime date)
    {
        var delete = await _service.DeleteAsync(athleteId, injuryId, date);
        return delete ? NoContent() : NotFound("Athlete Injury not found.");
    }
}