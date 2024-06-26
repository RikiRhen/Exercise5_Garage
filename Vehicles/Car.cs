﻿namespace Exercise5_Garage.Vehicles
{
    internal class Car : Vehicle
    {
        internal string VIN { get; }
        public override string Category { get; } = "CAR";
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