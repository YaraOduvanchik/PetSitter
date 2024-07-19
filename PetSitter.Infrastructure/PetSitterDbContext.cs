using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PetSitter.Domain.Entities;

namespace PetSitter.Infrastructure
{
    public class PetSitterDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public PetSitterDbContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        
        public PetSitterDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        //public PetSitterDbContext(DbContextOptions<PetSitterDbContext> options) : base(options)
        //{
            
        //}

        public DbSet<Animal> Animals => Set<Animal>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString(nameof(PetSitterDbContext)));
            optionsBuilder.UseSnakeCaseNamingConvention();
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PetSitterDbContext).Assembly);
        }
    }
}