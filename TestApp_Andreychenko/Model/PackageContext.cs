using Microsoft.EntityFrameworkCore;

namespace TestApp_Andreychenko.Model
{
    internal class PackageContext : DbContext
    {
        public DbSet<Package> Packages { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Repository.connectionString);
        }
    }
}
