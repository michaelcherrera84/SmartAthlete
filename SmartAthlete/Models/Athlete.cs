using System.ComponentModel.DataAnnotations;

namespace SmartAthlete.Models;

/// <summary>
/// Represents a sport athlete.
/// </summary>
public class Athlete
{
    /// <summary>The unique identifier of the athlete.</summary>
    public Guid Id { get; set; }
    
    /// <summary>The athlete's first name.</summary>
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;
    
    /// <summary>The athlete's middle name.</summary>
    [MaxLength(50)]
    public string MiddleName { get; set; } = string.Empty;
    
    /// <summary>The athlete's last name.</summary>
    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;
    
    /// <summary>The athlete's date of birth.</summary>
    public DateTime DateOfBirth { get; set; }
    
    /// <summary>The athlete's email address.</summary>
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;
    
    /// <summary>The unique identifier of the athlete's coach.</summary>
    public Guid? CoachId { get; set; } // foreign key
    
    /// <summary>The athlete's coach.</summary>
    public Coach? Coach { get; set; }

    /// <summary>The unique identifier of the athlete's sport.</summary>
    public int? SportId { get; set; } // foreign key
    
    /// <summary>The athlete's sport.</summary>
    public Sport? Sport { get; set; }

    /// <summary>A list of injuries sustained by the athlete.</summary>
    public ICollection<AthleteInjuries> AthleteInjuries { get; set; } = [];
}