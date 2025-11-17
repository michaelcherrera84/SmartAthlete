using System.ComponentModel.DataAnnotations;

namespace SmartAthlete.Models;

/// <summary>
/// Represents a sport.
/// </summary>
public class Sport
{
    /// <summary>The unique identifier of the sport.</summary>
    public int Id { get; set; }
    
    /// <summary>The name of the sport.</summary>
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
}