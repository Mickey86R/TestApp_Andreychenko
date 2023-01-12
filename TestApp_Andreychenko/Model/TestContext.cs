using Microsoft.EntityFrameworkCore;

namespace TestApp_Andreychenko.Model
{
    internal class TestContext : DbContext
    {
        public DbSet<Auto> Autos { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Voyage> Voyages { get; set; }
        public DbSet<Bringing> Bringings { get; set; }

        public TestContext()
            : base()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Repository.connectionString);
        }

    }
}
