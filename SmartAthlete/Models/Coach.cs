using System.ComponentModel.DataAnnotations;

namespace SmartAthlete.Models;

/// <summary>
/// Represents a sport coach.
/// </summary>
public class Coach
{
    /// <summary>The unique identifier of the coach.</summary>
    public Guid Id { get; set; }
    
    /// <summary>The coach's first name.</summary>
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;
    
    /// <summary>The coach's middle name.</summary>
    [MaxLength(50)]
    public string MiddleName { get; set; } = string.Empty;
    
    /// <summary>The coach's last name.</summary>
    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;
    
    /// <summary>The coach's date of birth.</summary>
    public DateTime DateOfBirth { get; set; }
    
    /// <summary>The coach's email address.</summary>
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;
    
    /// <summary>The unique identifier of the sport the coach coaches.</summary>
    public int SportId { get; set; } // foreign key
    
    /// <summary>The sport the coach coaches.</summary>
    public Sport? Sport { get; set; }
}