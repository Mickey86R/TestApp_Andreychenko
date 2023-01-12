using Microsoft.EntityFrameworkCore;

namespace TestApp_Andreychenko.Model
{
    internal class VoyageContext : DbContext
    {
        public DbSet<Voyage> Voyages { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Repository.connectionString);
        }
    }
}
