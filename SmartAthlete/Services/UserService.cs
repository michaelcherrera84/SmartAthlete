using Microsoft.EntityFrameworkCore;
using SmartAthlete.Data;
using SmartAthlete.DTOs.User;
using SmartAthlete.Models;

namespace SmartAthlete.Services;

/// <summary>
/// User service.
/// </summary>
/// <param name="context"></param>
public class UserService(AppDbContext context) : IUserService
{
    private readonly AppDbContext _context = context;
    
    /// <inheritdoc/>
    public async Task<User?> GetByUsernameAsync(string userName)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Username.ToLower() == userName.ToLower());
    }

    /// <inheritdoc/>
    public async Task<User?> ValidateCredentialsAsync(string userName, string password)
    {
        var user = await GetByUsernameAsync(userName);
        if (user == null) return null;
        
        var isValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
        return isValid ? user : null;
    }

    /// <inheritdoc/>
    public async Task<User?> CreateUserAsync(CreateUserDto newUser)
    {
        // Check username uniqueness
        var exists = await _context.Users.AnyAsync(u => u.Username.ToLower() == newUser.Username.ToLower());
        if (exists)
            throw new Exception("Username already exists.");

        // Hash password
        var hash = BCrypt.Net.BCrypt.HashPassword(newUser.PasswordHash);

        var user = new User()
        {
            Id = Guid.NewGuid(),
            FirstName = newUser.FirstName,
            LastName = newUser.LastName,
            Email = newUser.Email,
            Username = newUser.Username,
            PasswordHash = hash,
            Role = newUser.Role ?? ""
        };
        
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        
        return user;
    }
}