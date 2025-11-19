using System.ComponentModel.DataAnnotations;

namespace SmartAthlete.Models;

/// <summary>
/// Represents a user.
/// </summary>
public class User
{
    /// <summary>The unique identifier of the user.</summary>
    public Guid Id { get; set; }
    
    /// <summary>The user's first name.</summary>
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;
    
    /// <summary>The user's last name.</summary>
    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;
    
    /// <summary>The user's email address.</summary>
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;

    /// <summary>The username of the user.</summary>
    [MaxLength(50)]
    public string Username { get; set; } = string.Empty;
    
    /// <summary>The hashed password of the user.</summary>
    public string PasswordHash { get; set; } = string.Empty;

    /// <summary>The role of the user.</summary>
    [MaxLength(50)]
    public string Role { get; set; } = string.Empty;
}