using Microsoft.EntityFrameworkCore;
using OptixMovies.Entities;

namespace OptixMovies.Database
{
    public class OptixContext : DbContext
    {
        public OptixContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(x=>x.Id);
            });
        }
    }
}