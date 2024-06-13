namespace Exercise5_Garage.Vehicles
{
    internal class Airplane : Vehicle
    {
        public double Wingspan { get; }
        public Airplane(string type, string make, string model, string reg, string color, int wheels, int passengers, double wingspan) : base(type, make, model, reg, color, wheels, passengers)
        {
            Wingspan = wingspan;
        }

        public override string ToString()
        {
            return base.ToString() + $" with a wingspan of {Wingspan}m.";
        }
    }
}