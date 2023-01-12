using Microsoft.EntityFrameworkCore;

namespace TestApp_Andreychenko.Model
{
    internal class AutoContext : DbContext
    {
        public DbSet<Auto> Autos { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Repository.connectionString);
        }
    }
}
