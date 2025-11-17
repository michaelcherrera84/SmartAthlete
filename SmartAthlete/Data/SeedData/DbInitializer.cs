using System.Text.Json;
using SmartAthlete.Models;

namespace SmartAthlete.Data.SeedData;

/// <summary>
/// Centralized database seeding utility.  
/// Reads JSON files from Data/SeedData and inserts them
/// into the database on startup.
/// </summary>
public static class DbInitializer
{
    /// <summary>
    /// Seeds all entity types used by the application.
    /// Each JSON file should contain a list of the corresponding entities.
    /// </summary>
    public static void SeedData(AppDbContext context)
    {
        // Seed each table from its matching JSON file
        SeedEntity<Sport>(context, "sports.json");
        SeedEntity<Injury>(context, "injuries.json");
        SeedEntity<Coach>(context, "coaches.json");
        SeedEntity<Athlete>(context, "athletes.json");
        SeedEntity<AthleteInjuries>(context, "athlete-injuries.json");
    }

    /// <summary>
    /// Generic method that seeds a table using JSON data.
    /// </summary>
    /// <typeparam name="TEntity">The entity type to seed.</typeparam>
    /// <param name="context">The application's DbContext.</param>
    /// <param name="fileName">The JSON file containing seed data.</param>
    private static void SeedEntity<TEntity>(AppDbContext context, string fileName)
        where TEntity : class
    {
        // If the table already contains data, do nothing
        if (context.Set<TEntity>().Any())
            return;

        // Build full path: <project root>/Data/SeedData/<fileName>
        var path = Path.Combine(
            Directory.GetCurrentDirectory(),
            "Data",
            "SeedData",
            fileName);

        // If the JSON file doesn't exist, skip seeding
        if (!File.Exists(path))
            return;

        // Load file text
        var json = File.ReadAllText(path);

        // Deserialize into a list of entities
        var data = JsonSerializer.Deserialize<List<TEntity>>(json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        // If deserialization failed or file was empty, skip
        if (data is null || data.Count == 0)
            return;

        // Insert into the database
        context.Set<TEntity>().AddRange(data);
        context.SaveChanges();
    }
}