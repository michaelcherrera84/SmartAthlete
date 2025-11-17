using System.ComponentModel.DataAnnotations;

namespace SmartAthlete.Models;

/// <summary>
/// Represents a sports-related injury.
/// </summary>
public class Injury
{
    /// <summary>The unique identifier of the injury.</summary>
    public int Id { get; set; }
    
    /// <summary>The type of injury.</summary>
    [MaxLength(100)]
    public string Type { get; set; } = string.Empty;
}