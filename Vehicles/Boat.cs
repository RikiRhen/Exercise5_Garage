namespace Exercise5_Garage.Vehicles
{
    internal class Boat : Vehicle
    {
        public int EngineCount { get; }
        public Boat(string type, string make, string model, string reg, string color, int wheels, int passengers, int engineCount) : base(type, make, model, reg, color, wheels, passengers)
        {
            EngineCount = engineCount;
        }

        public override string ToString()
        {
            return base.ToString() + $" with {EngineCount} engine(s).";
        }
    }
}
