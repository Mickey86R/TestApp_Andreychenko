using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp_Andreychenko.Model
{
    internal class Bringing
    {
        public int ID { get; set; }

        [Column("Voyage_ID")]
        public int VoyageID { get; set; }

        [Column("Package_ID")]
        public int PackageID { get; set; }

        [Column("Weight_Brutto")]
        public double WeightBrutto { get; set; }

        [Column("Weight_Netto")]
        public double WeightNetto { get; set; }

        public Voyage Voyage { get; set; }
        public Package Package { get; set; }

        public Bringing(int voyageID, int packageID, double weightBrutto, double weightNetto)
        {
            VoyageID = voyageID;
            PackageID = packageID;
            WeightBrutto = weightBrutto;
            WeightNetto = weightNetto;
        }
    }
}
