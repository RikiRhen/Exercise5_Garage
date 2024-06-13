using System.Collections;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Garage.Tester")]

namespace Exercise5_Garage
{
    internal abstract class Vehicle
    {
        internal string Type { get; }
        internal string Make { get; }
        internal string Model { get; }
        private string Color { get; }
        private int Wheels { get; }
        private int Passengers { get; }
        internal string Reg { get; }

        internal Vehicle(string type, string make, string model, string reg, string color, int wheels, int passengers)
        {
            Type = type;
            Make = make;
            Model = model;
            Reg = reg;
            Color = color;
            Wheels = wheels;
            Passengers = passengers;
        }

        public override string ToString()
        {
            return $"{Make} {Model}, a {Color} {Type} with {Wheels} wheels that holds {Passengers} passenger(s)";
        }

        internal char GetSymbol()
        {
            return Type[0];
        }
    }
}