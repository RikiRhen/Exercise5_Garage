

using Exercise5_Garage.UI;
using Exercise5_Garage.Vehicles;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;

namespace Exercise5_Garage
{
    internal class GarageHandler
    {
        private readonly static string NOSUCHCAR = "No vehicle with that registry number is parked in the garage.";
        UserInterface UI = new();

        internal void ParkVehicle(Vehicle vehicle, Garage<Vehicle> garage)
        {
            if (garage.ParkVehicle(vehicle)) 
            { 
                Console.WriteLine($"{vehicle.Make} {vehicle.Model} {vehicle.Reg}, was parked successfully."); 
            }
        }

        internal void RemoveVehicle(string reg, Garage<Vehicle> garage)
        {
            if (garage.VehicleDeparture(reg)) { Console.WriteLine($"{reg} has left the garage."); }
            else { Console.WriteLine(NOSUCHCAR); }
        }

        internal void ListVehicles(Garage<Vehicle> garage)
        {
            foreach (Vehicle v in garage.ListVehicles()) { Console.WriteLine(v); }
            UI.PrintSpaces(garage.OneTimeUseMethodThatOnlyExistsForAestheticsAndNeverAgain());
        }

        internal void ListTypes(Garage<Vehicle> garage)
        {
            var list = garage.FindTypes();
            Console.WriteLine("Types of vehicles in the garage:");
            foreach (var key in list) { Console.WriteLine($"{key.Key}: {key.Value}"); }
        }

        private string[] GetBaseInfo()
        {
            string[] result =
            [
                UI.GetString("Registry plate: "),
                UI.GetString("Maker: "),
                UI.GetString("Model: "),
                UI.GetString("Type: "),
                UI.GetString("Colour: "),
            ];
            return result;
        }

        internal Car CreateNewCar()
        {
            string[] parameters = GetBaseInfo();
            string VIN = UI.GetString("VIN: ");
            Car car = new(parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], VIN);
            return car;
        }


        internal Bus CreateNewBus()
        {
            string[] parameters = GetBaseInfo();
            bool decker = UI.GetBoolean("Is the bus a double decker?: ");
            Bus bus = new(parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], decker);
            return bus;
        }
        internal Boat CreateNewBoat()
        {
            string[] parameters = GetBaseInfo();
            int engines = (int)UI.GetNumber("Number of engines: ");
            Boat boat = new(parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], engines);
            return boat;
        }

        internal Airplane CreateNewAirplane()
        {
            string[] parameters = GetBaseInfo();
            double wingspan = UI.GetNumber("Wingspan: ");
            Airplane plane = new(parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], wingspan);
            return plane;
        }


        internal Motorcycle CreateNewMC()
        {
            string[] parameters = GetBaseInfo();
            int cc = (int)UI.GetNumber("CC of engine: ");
            Motorcycle mc = new(parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], cc);
            return mc;
        }

        //Kallning: Car car = ChatGPTVersion<Car>();
        //          Bus bus = ChatGPTVersion<Bus>();

        //public static T ChatGPTVersion<T>() where T : Vehicle
        //{
        //    Type type = typeof(T);
        //    ConstructorInfo[] constructors = type.GetConstructors();
        //    ConstructorInfo constructor = constructors.First();

        //    ParameterInfo[] parameters = constructor.GetParameters();
        //    object[] args = new object[parameters.Length];

        //    for (int i = 0; i < parameters.Length; i++)
        //    {
        //        ParameterInfo param = parameters[i];
        //        Console.Write($"Enter {param.Name} ({param.ParameterType.Name }): ");

        //        switch (Type.GetTypeCode(param.ParameterType))
        //        {
        //            case TypeCode.Boolean:

        //                break;
        //            case: TypeCode.

        //            default:
        //                break;
        //        }

        //        string input = Console.ReadLine();

        //        args[i] = Convert.ChangeType(input, param.ParameterType);
        //    }

        //    return (T)constructor.Invoke(args);
        //}

        internal void FindPlateInGarage(string plate, Garage<Vehicle> garage)
        {
            if (garage.FindPlate(plate)) { Console.WriteLine($"A vehicle with the registry number {plate} is parked in the garage."); }
            else { Console.WriteLine(NOSUCHCAR); }
        }

        internal bool ParkKnownVehicle(string reg, Garage<Vehicle> garage)
        {
            if (garage.IsVehicleKnown(reg)) { garage.ParkKnownVehicle(reg); return true; } 
            else { return false; }
        }
    }
}