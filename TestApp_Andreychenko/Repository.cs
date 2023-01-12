using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp_Andreychenko.Model;

namespace TestApp_Andreychenko
{
    internal static class Repository
    {
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TestDB_Andreychenko;MultipleActiveResultSets=true;Integrated Security=True";

        public static async Task AddAuto(string number, double capacity)
        {
            using (var AutoDB = new AutoContext())
            {
                await AutoDB.Autos.AddAsync(new Auto(number, capacity));
                await AutoDB.SaveChangesAsync();
            }
        }

        public static async Task AddVoyage(int autoID, DateTime date)
        {
            using (var VoyageDB = new VoyageContext())
            {
                await VoyageDB.Voyages.AddAsync(new Voyage(autoID, date));
                await VoyageDB.SaveChangesAsync();
            }
        }

        public static async Task AddPackage(int number, double capacity, double weight, DateTime date)
        {
            using (var PackageDB = new PackageContext())
            {
                await PackageDB.Packages.AddAsync(new Package(number, capacity, weight, date));
                await PackageDB.SaveChangesAsync();
            }
        }

        public static async Task AddBringing(int voyageID, int packageID, double weightBr, double weightNet)
        {
            using (var BringingDB = new BringingContext())
            {
                await BringingDB.Bringings.AddAsync(new Bringing(voyageID, packageID, weightBr, weightNet));
                await BringingDB.SaveChangesAsync();
            }
        }

        public static async Task<List<Auto>> GetAutos()
        {
            var list = new List<Auto>();

            using (var AutoDB = new AutoContext())
            {
                list = AutoDB.Autos.ToList();
            }
            return list;
        }

        public static async Task<List<Voyage>> GetVoyages()
        {
            var list = new List<Voyage>();

            using (var VoyageDB = new VoyageContext())
            {
                list = VoyageDB.Voyages.ToList();
            }
            return list;
        }

        public static async Task<List<Package>> GetPackages()
        {
            var list = new List<Package>();

            using (var PackageDB = new PackageContext())
            {
                list = PackageDB.Packages.ToList();
            }
            return list;
        }
    }
}
