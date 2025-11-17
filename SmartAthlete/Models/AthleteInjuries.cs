using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SmartAthlete.Models;

/// <summary>
/// Represents an athlete injury incident.
/// </summary>
public class AthleteInjuries
{
    /// <summary>The unique identifier of the athlete that has sustained an injury.</summary>
    public Guid AthleteId { get; set; } // primary key / foreign key
    
    /// <summary>The athlete that has sustained an injury.</summary>
    public Athlete? Athlete { get; set; }

    /// <summary>The unique identifier of the sustained injury.</summary>
    public int InjuryId { get; set; } // primary key / foreign key
    
    /// <summary>The sustained injury.</summary>
    public Injury? Injury { get; set; }

    /// <summary>The date of the injury incident.</summary>
    public DateTime Date { get; set; }
    
    /// <summary>A description of the injury incident.</summary>
    [SuppressMessage("ReSharper", "EntityFramework.ModelValidation.UnlimitedStringLength")]
    public string Description { get; set; } = string.Empty;
}