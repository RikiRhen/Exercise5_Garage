﻿namespace Exercise5_Garage.Vehicles
{
    internal class Bus : Vehicle
    {
        internal bool DoubleDecker;
        public override string Category { get; } = "BUS";
        public Bus(string reg, string make, string model, string type, string color, bool doubleDecker) : base(reg, make, model, type, color)
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