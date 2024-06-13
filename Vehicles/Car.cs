namespace Exercise5_Garage.Vehicles
{
    internal class Car : Vehicle
    {
        private string VIN { get; }
        public Car(string type, string make, string model, string reg, string color, int wheels, int passengers, string vin) : base(type, make, model, reg, color, wheels, passengers)
        {
            VIN = vin;
        }

        public override string ToString()
        {
            return base.ToString() + $", VIN number: {VIN}.";
        }
    }
}