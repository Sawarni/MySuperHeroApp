using Microsoft.EntityFrameworkCore;
using MySuperHeroApp.ApiService.Database.Configuration;
using MySuperHeroApp.ApiService.Model;

namespace MySuperHeroApp.ApiService.Database
{
    public class SuperHeroDbContext : DbContext
    {
        public SuperHeroDbContext(DbContextOptions<SuperHeroDbContext> options) : base(options)
        {
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply the configuration for SuperHero
            modelBuilder.ApplyConfiguration(new SuperHeroConfiguration());
        }
    }
}
