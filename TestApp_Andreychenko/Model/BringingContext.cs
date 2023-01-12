using Microsoft.EntityFrameworkCore;

namespace TestApp_Andreychenko.Model
{
    internal class BringingContext : DbContext
    {
        public DbSet<Bringing> Bringings { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Repository.connectionString);
        }
    }
}
