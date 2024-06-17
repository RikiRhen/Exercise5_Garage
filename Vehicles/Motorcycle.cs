namespace Exercise5_Garage.Vehicles
{
    internal class Motorcycle : Vehicle
    {
        private int CubicEngine { get; }
        public override string Category { get; } = "MOTORCYCLE";
        public Motorcycle(string reg, string make, string model, string type, string color, int cubicEngine) : base(reg, make, model, type, color)
        {
            CubicEngine = cubicEngine;
        }

        public override string ToString()
        {
            return base.ToString() + $" and a {CubicEngine} CC engine.";
        }
    }
}