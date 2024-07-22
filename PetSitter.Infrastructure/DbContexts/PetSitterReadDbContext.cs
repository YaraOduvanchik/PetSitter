using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PetSitter.Application.Dtos;

namespace PetSitter.Infrastructure.DbContexts;

public class PetSitterReadDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public PetSitterReadDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<UserDto> Users => Set<UserDto>();
    public DbSet<AnimalDto> Animals => Set<AnimalDto>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("PetSitter"));
        optionsBuilder.UseSnakeCaseNamingConvention();
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(PetSitterReadDbContext).Assembly,
            type => type.FullName?.Contains("Configurations.Read") ?? false);
    }
}