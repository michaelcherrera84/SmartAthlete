using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using SmartAthlete.Data;
using SmartAthlete.Data.SeedData;
using SmartAthlete.Mappings;
using SmartAthlete.Services;
using SmartAthlete.Models;

var builder = WebApplication.CreateBuilder(args);

// ----------------------
// SERVICE REGISTRATION
// ----------------------

// Add controllers (API endpoints)
builder.Services.AddControllers();

// OpenAPI / Swagger
builder.Services.AddOpenApi();

// Add the database context using SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register application services for dependency injection
builder.Services.AddScoped<IEntityService<Athlete>, AthleteService>();
builder.Services.AddScoped<IEntityService<Coach>, CoachService>();
builder.Services.AddScoped<IEntityService<AthleteInjuries>, AthleteInjuriesService>();
builder.Services.AddScoped(typeof(IEntityService<>), typeof(EntityService<>));
builder.Services.AddScoped<IAthleteInjuriesService, AthleteInjuriesService>();
builder.Services.AddScoped<IUserService, UserService>();

// ----------------------
// AUTHENTICATION & AUTHORIZATION
// ----------------------

// Add cookie-based authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        // Path to redirect to if unauthorized
        options.LoginPath = "/auth/login";  
        options.LogoutPath = "/auth/logout";

        // Cookie configuration
        options.Cookie.Name = "SmartAthleteAuth";
        options.Cookie.HttpOnly = true;         // prevents client-side JS from reading the cookie
        options.ExpireTimeSpan = TimeSpan.FromDays(7); // cookie expiration
        options.SlidingExpiration = true;       // renew cookie on activity
    });

// Add authorization (for [Authorize] attributes)
builder.Services.AddAuthorization();

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactAppPolicy", policy =>
    {
        policy.WithOrigins("https://localhost:3000") // React frontend URL
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials(); // must allow credentials for cookies
    });
});

// AutoMapper registration for mapping DTOs <-> entities
builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);

// ----------------------
// BUILD APP
// ----------------------
var app = builder.Build();

// ----------------------
// MIDDLEWARE PIPELINE
// ----------------------

// Development tools
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

// Use CORS before authentication/authorization
app.UseCors("ReactAppPolicy");

// Redirect HTTP -> HTTPS
app.UseHttpsRedirection();

// Developer exception page (detailed errors in development)
app.UseDeveloperExceptionPage();

// Routing middleware (needed for controller endpoints)
app.UseRouting();

// **Authentication must come before authorization**
// This reads the cookie from requests and sets HttpContext.User
app.UseAuthentication();

// This enforces [Authorize] on controllers/actions
app.UseAuthorization();

// Map controller endpoints
app.MapControllers();

// ----------------------
// DATABASE MIGRATION & SEEDING
// ----------------------
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // Apply any pending migrations
    context.Database.Migrate();

    // Seed initial data (users, athletes, etc.)
    DbInitializer.SeedData(context);
}

// Run the application
app.Run();