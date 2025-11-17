using AutoMapper;
using SmartAthlete.DTOs.Athlete;
using SmartAthlete.DTOs.AthleteInjury;
using SmartAthlete.DTOs.Coach;
using SmartAthlete.DTOs.Injury;
using SmartAthlete.DTOs.Sport;
using SmartAthlete.Models;

namespace SmartAthlete.Mappings;

/// <summary>
/// Central AutoMapper profile that defines how domain entities are translated
/// to and from their corresponding Data Transfer Objects (DTOs).
/// 
/// AutoMapper uses these rules to automatically convert objects during
/// controller-service interactions:
/// 
/// - Entity → DTO   (usually for API responses)
/// - DTO → Entity   (usually for Create/Update operations)
/// 
/// Each CreateMap call registers a bidirectional mapping between types.
/// </summary>
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // -----------------------
        // Athlete Mappings
        // -----------------------

        // Maps the Athlete entity to the AthleteDto used for API responses.
        CreateMap<Athlete, FullAthleteDto>();
        CreateMap<Athlete, GetAllAthletesDto>();
        CreateMap<Athlete, GetOneAthleteDto>();
        
        // Maps incoming create requests into a new Athlete entity.
        CreateMap<CreateAthleteDto, Athlete>();
        
        // Maps update/edit requests into an existing Athlete entity.
        CreateMap<EditAthleteDto, Athlete>();


        // -----------------------
        // AthleteInjuries Mappings (Join Table)
        // -----------------------
        
        // Maps the AthleteInjuries join entity to a DTO for responses.
        CreateMap<AthleteInjuries, FullAthleteInjuriesDto>();
        CreateMap<AthleteInjuries, GetInjuryForAthleteDto>();
        CreateMap<AthleteInjuries, GetAthleteInjuriesDto>();
        
        // Maps incoming create requests into a new AthleteInjuries record.
        CreateMap<CreateAthleteInjuriesDto, AthleteInjuries>();
        
        // Maps edit/update operations for AthleteInjuries.
        CreateMap<EditAthleteInjuryDto, AthleteInjuries>();


        // -----------------------
        // Coach Mappings
        // -----------------------
        
        // Maps Coach entity to response DTO.
        CreateMap<Coach, FullCoachDto>();
        CreateMap<Coach, GetOneCoachDto>();
        CreateMap<Coach, GetCoachForAthleteDto>();
        CreateMap<Coach, GetAllCoachesDto>();
        
        // Maps create requests to Coach entity.
        CreateMap<CreateCoachDto, Coach>();
        
        // Maps update request to Coach entity.
        CreateMap<EditCoachDto, Coach>();


        // -----------------------
        // Injury Mappings
        // -----------------------
        
        // Maps Injury entity to response DTO.
        CreateMap<Injury, FullInjuryDto>();
        
        // Maps create requests to Injury entity.
        CreateMap<CreateInjuryDto, Injury>();
        
        // Maps update request to Injury entity.
        CreateMap<EditInjuryDto, Injury>();


        // -----------------------
        // Sport Mappings
        // -----------------------
        
        // Maps Sport entity to response DTO.
        CreateMap<Sport, FullSportDto>();
        
        // Maps create request to Sport entity.
        CreateMap<CreateSportDto, Sport>();
        
        // Maps update request to Sport entity.
        CreateMap<EditSportDto, Sport>();
    }
}