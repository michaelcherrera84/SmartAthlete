using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartAthlete.DTOs.User;
using SmartAthlete.Services;

namespace SmartAthlete.Controllers;

/// <summary>
/// Controller responsible for user authentication: register, login, logout, and getting the current user.
/// </summary>
[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _service;

    /// <summary>
    /// Constructor that injects the user service.
    /// </summary>
    /// <param name="service">The user service to interact with the user data.</param>
    public AuthController(IUserService service)
    {
        _service = service;
    }

    /// <summary>
    /// Registers a new user.
    /// </summary>
    /// <param name="newUser">User details to create.</param>
    /// <returns>Returns the created user data or a BadRequest if creation failed.</returns>
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateUserDto newUser)
    {
        var user = await _service.CreateUserAsync(newUser);
        if (user == null)
            return BadRequest("User creation failed.");

        // Return basic user info (no password) to confirm creation
        return Ok(new
        {
            user.Id,
            user.FirstName,
            user.LastName,
            user.Email,
            user.Username,
            user.Role
        });
    }

    /// <summary>
    /// Logs in a user and issues a cookie-based authentication token.
    /// </summary>
    /// <param name="loginUser">The username and password to authenticate.</param>
    /// <returns>Ok if login succeeds; Unauthorized if credentials are invalid.</returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginUser)
    {
        // Validate the credentials against the user service
        var user = await _service.ValidateCredentialsAsync(loginUser.Username, loginUser.PasswordHash);
        if (user == null)
            return Unauthorized("Invalid username or password.");

        // --- Claims section ---
        // Claims represent the identity and roles of the user.
        // They are key/value pairs that describe the user for authorization purposes.
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), // Unique user ID
            new Claim(ClaimTypes.Name, user.Username), // Username
            new Claim(ClaimTypes.Role, user.Role) // Role (e.g., Admin, User)
        };

        // Create an identity from the claims, specifying "Cookies" as the authentication scheme
        var identity = new ClaimsIdentity(claims, "Cookies");
        var principal = new ClaimsPrincipal(identity);

        // Sign in the user using the cookie authentication middleware
        await HttpContext.SignInAsync("Cookies", principal, new AuthenticationProperties
        {
            IsPersistent = true, // Keep user logged in across browser sessions
            ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7) // Cookie expiration
        });

        return Ok(new { message = "Login successful." });
    }

    /// <summary>
    /// Logs out the current user by clearing the authentication cookie.
    /// </summary>
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync("Cookies");
        return Ok(new { message = "Logged out." });
    }

    /// <summary>
    /// Returns information about the currently authenticated user.
    /// </summary>
    /// <returns>User details or Unauthorized if not authenticated.</returns>
    [Authorize]
    [HttpGet("me")]
    public async Task<IActionResult> Me()
    {
        // Get the user's ID from the claims
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null)
            return Unauthorized();

        // Use the username to fetch user data (could also fetch by ID if preferred)
        var user = await _service.GetByUsernameAsync(User.Identity!.Name!);

        return Ok(new
        {
            user!.Id,
            user.FirstName,
            user.LastName,
            user.Email,
            user.Username,
            user.Role
        });
    }
}