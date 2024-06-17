using System.Collections;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Garage.Tester")]
[assembly: InternalsVisibleTo("Exercise5_Garage")]

namespace Exercise5_Garage
{
    internal abstract class Vehicle
    {
        public virtual string Category { get; } = "VEHICLE";
        internal string Reg { get; }
        internal string Make { get; }
        internal string Model { get; }
        internal string Type { get; }
        internal string Color { get; }


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