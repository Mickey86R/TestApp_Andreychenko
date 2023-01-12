namespace TestApp_Andreychenko.Model
{
    internal class Auto
    {
        public int ID { get; set; }

        public string Number { get; set; }
        public double Capacity { get; set; }

        public Auto(string number, double capacity)
        {
            Number = number;
            Capacity = capacity;
        }

        public override string ToString()
        {
            return Number;
        }
    }
}
