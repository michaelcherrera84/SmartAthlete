using SmartAthlete.DTOs.User;
using SmartAthlete.Models;

namespace SmartAthlete.Services;

/// <summary>
/// Provides operations for managing and authenticating application users.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Retrieves a user by their username.
    /// </summary>
    /// <param name="userName">The username to search for.</param>
    /// <returns>The matching <see cref="User"/> if found; otherwise, <c>null</c>.</returns>
    Task<User?> GetByUsernameAsync(string userName);

    /// <summary>
    /// Validates a user's login credentials.
    /// </summary>
    /// <param name="userName">The username provided during login.</param>
    /// <param name="password">The plaintext password to verify against the stored password hash.</param>
    /// <returns>The authenticated <see cref="User"/> if the credentials are correct; otherwise, <c>null</c>.</returns>
    Task<User?> ValidateCredentialsAsync(string userName, string password);

    /// <summary>
    /// Creates a new user in the system.
    /// </summary>
    /// <param name="newUser">
    /// The data required to create the user, including a plaintext password
    /// that will be hashed before storage.
    /// </param>
    /// <returns>The newly created <see cref="User"/>.</returns>
    Task<User?> CreateUserAsync(CreateUserDto newUser);
}