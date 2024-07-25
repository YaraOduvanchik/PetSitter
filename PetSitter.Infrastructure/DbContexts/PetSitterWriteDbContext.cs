using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PetSitter.Domain.Entities;

namespace PetSitter.Infrastructure.DbContexts;

public class PetSitterWriteDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public PetSitterWriteDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<Animal> Animals => Set<Animal>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Sitter> Sitters => Set<Sitter>();
    public DbSet<Disease> Diseases => Set<Disease>();
    public DbSet<Vaccination> Vaccinations => Set<Vaccination>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("PetSitter"));
        optionsBuilder.UseSnakeCaseNamingConvention();
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(PetSitterWriteDbContext).Assembly,
            type => type.FullName?.Contains("Configurations.Write") ?? false);
    }
}