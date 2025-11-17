using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using SmartAthlete.Data;
using SmartAthlete.Data.SeedData;
using SmartAthlete.Mappings;
using SmartAthlete.Services;
using SmartAthlete.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IEntityService<Athlete>, AthleteService>();
builder.Services.AddScoped<IEntityService<Coach>, CoachService>();
builder.Services.AddScoped<IEntityService<AthleteInjuries>, AthleteInjuriesService>();
builder.Services.AddScoped(typeof(IEntityService<>), typeof(EntityService<>));
builder.Services.AddScoped<IAthleteInjuriesService, AthleteInjuriesService>();

builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
    DbInitializer.SeedData(context);
}

app.Run();