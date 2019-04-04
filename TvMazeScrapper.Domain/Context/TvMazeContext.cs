using Microsoft.EntityFrameworkCore;
using TvMazeScrapper.Domain.Context.Configurations;
using TvMazeScrapper.Domain.Models;

namespace TvMazeScrapper.Domain.Context
{
    public class TvMazeContext : DbContext
    {
        public TvMazeContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new ShowConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Show> Shows { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}
