using Microsoft.EntityFrameworkCore;
using PetSitter.Domain.Entities;

namespace PetSitter.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        DbSet<Animal> Animals => Set<Animal>();
    }
}