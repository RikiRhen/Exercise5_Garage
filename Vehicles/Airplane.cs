namespace Exercise5_Garage.Vehicles
{
    internal class Airplane : Vehicle
    {
        public double Wingspan { get; }
        public Airplane(string reg, string make, string model, string type, string color, double wingspan) : base(reg, make, model, type, color)
        {
            Wingspan = wingspan;
        }

        public override string ToString()
        {
            return base.ToString() + $" with a wingspan of {Wingspan}m.";
        }
    }
}