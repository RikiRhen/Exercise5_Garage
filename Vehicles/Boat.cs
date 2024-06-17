namespace Exercise5_Garage.Vehicles
{
    internal class Boat : Vehicle
    {
        public int EngineCount { get; }
        public override string Category { get; } = "BOAT";
        public Boat(string reg, string make, string model, string type, string color, int engineCount) : base(reg, make, model, type, color)
        {
            EngineCount = engineCount;
        }

        public override string ToString()
        {
            return base.ToString() + $" and {EngineCount} engine(s).";
        }
    }
}
