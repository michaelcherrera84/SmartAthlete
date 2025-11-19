using Microsoft.EntityFrameworkCore;
using SmartAthlete.Models;

namespace SmartAthlete.Data;

/// <summary>
/// Represents the application's database context.
/// </summary>
/// <param name="options">The options to be used by this context.</param>
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    /// <summary>Represents all athletes, each linked to a coach and sport.</summary>
    public DbSet<Athlete> Athletes => Set<Athlete>();
    
    /// <summary>Represents the many-to-many relationship between athletes and injuries.</summary>
    public DbSet<AthleteInjuries> AthleteInjuries => Set<AthleteInjuries>();
    
    /// <summary>Represents all coaches, each linked to a sport.</summary>
    public DbSet<Coach> Coaches => Set<Coach>();
    
    /// <summary>Represents all injuries that can occur to athletes.</summary>
    public DbSet<Injury> Injuries => Set<Injury>();
    
    /// <summary>Represents all sports in the system.</summary>
    public DbSet<Sport> Sports => Set<Sport>();
    
    /// <summary>Represents all users in the system.</summary>
    public DbSet<User> Users => Set<User>();
    
    /// <summary>
    /// Configures entity relationships and composite keys.
    /// </summary>
    /// <param name="modelBuilder">The model builder to configure entity mappings.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AthleteInjuries>(ai =>
        {
            // composite key for join table
            ai.HasKey(k => new {k.AthleteId, k.InjuryId, k.Date});
            
            // relationships
            ai.HasOne(a => a.Athlete)
                .WithMany(ai => ai.AthleteInjuries)
                .HasForeignKey(k => k.AthleteId)
                .OnDelete(DeleteBehavior.NoAction);
            
            ai.HasOne(i => i.Injury)
                .WithMany()
                .HasForeignKey(k => k.InjuryId)
                .OnDelete(DeleteBehavior.NoAction);
        });
    }
}