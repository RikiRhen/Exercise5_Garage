namespace Exercise5_Garage.Vehicles
{
    internal class Bus : Vehicle
    {
        private bool DoubleDecker;
        public Bus(string type, string make, string model, string reg, string color, int wheels, int passengers, bool doubleDecker) : base(type, make, model, reg, color, wheels, passengers)
        {
            DoubleDecker = doubleDecker;
        }

        public override string ToString()
        {
            if (DoubleDecker)
            {
                return base.ToString() + $". This is a double decker bus.";
            }
            else
            {
                return base.ToString() + ".";
            }
        }
    }
}