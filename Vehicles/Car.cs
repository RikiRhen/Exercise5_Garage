namespace Exercise5_Garage.Vehicles
{
    internal class Car : Vehicle
    {
        private string VIN { get; }
        public Car(string reg, string make, string model, string type, string color, string vin) : base(reg, make, model, type, color)
        {
            VIN = vin;
        }

        public override string ToString()
        {
            return base.ToString() + $" and the VIN number: {VIN}.";
        }
    }
}