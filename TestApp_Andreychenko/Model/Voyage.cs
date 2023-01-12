using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp_Andreychenko.Model
{
    internal class Voyage
    {
        public int ID { get; set; }

        [Column("Auto_ID")]
        public int AutoID { get; set; }
        public DateTime Date { get; set; }

        public virtual Auto Auto { get; set; }

        public Voyage(int autoID, DateTime date) 
        {
            AutoID = autoID;
            Date = date;
        }

        public override string ToString()
        {
            return ID.ToString();
        }
    }
}
