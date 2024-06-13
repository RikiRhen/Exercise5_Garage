namespace Exercise5_Garage.Vehicles
{
    internal class Motorcycle : Vehicle
    {
        private int CubicEngine { get; }
        public Motorcycle(string type, string make, string model, string reg, string color, int wheels, int passengers, int cubicEngine) : base(type, make, model, reg, color, wheels, passengers)
        {
            CubicEngine = cubicEngine;
        }

        public override string ToString()
        {
            return base.ToString() + $" with a {CubicEngine} CC engine.";
        }
    }
}