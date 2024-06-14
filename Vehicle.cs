using System.Collections;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Garage.Tester")]

namespace Exercise5_Garage
{
    internal abstract class Vehicle
    {
        internal string Reg { get; }
        internal string Make { get; }
        internal string Model { get; }
        internal string Type { get; }
        private string Color { get; }


        internal Vehicle(string reg, string make, string model, string type, string color)
        {
            Reg = reg;
            Make = make;
            Model = model;
            Type = type;
            Color = color;
        }

        public override string ToString()
        {
            return $"{Make} {Model}, a {Color} {Type} with the license plate {Reg}";
        }

        internal char GetSymbol()
        {
            return Type[0];
        }
    }
}