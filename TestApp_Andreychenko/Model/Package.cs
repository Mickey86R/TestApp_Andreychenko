using System;

namespace TestApp_Andreychenko.Model
{
    internal class Package
    {
        public int ID { get; set; }

        public int Number { get; set; }
        public double Capacity { get; set; }
        public double Weight { get; set; }
        public DateTime Date { get; set; }

        public Package(int number, double capacity, double weight, DateTime date)
        {
            Number = number;
            Capacity = capacity;
            Weight = weight;
            Date = date;
        }

        public override string ToString()
        {
            return Number.ToString();
        }
    }
}
