

using Exercise5_Garage.UI;
using Exercise5_Garage.Vehicles;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;

namespace Exercise5_Garage
{
    internal class GarageHandler : IGarageHandler
    {
        private readonly static string NOSUCHCAR = "No vehicle with that registry number is parked in the garage.";
        UserInterface UI = new();

        public bool ParkVehicle(Vehicle vehicle, Garage<Vehicle> garage)
        {
            if (garage.ParkVehicle(vehicle))
            {
                Console.WriteLine($"{vehicle.Make} {vehicle.Model} {vehicle.Reg}, was parked successfully.");
                return true;
            }
            else { return false; }
        }

        public bool DepartVehicle(string reg, Garage<Vehicle> garage)
        {
            if (garage.VehicleDeparture(reg)) { Console.WriteLine($"{reg} has left the garage."); return true; }
            else { Console.WriteLine(NOSUCHCAR); return false; }
        }

        public void ListVehicles(Garage<Vehicle> garage)
        {
            Console.Clear();
            Console.WriteLine($"Vehicles currently parked in {garage.Name}:");
            foreach (Vehicle v in garage.ListVehicles()) { Console.WriteLine(v); }
            UI.PrintSpaces(garage.OneTimeUseMethodThatOnlyExistsForAestheticsAndNeverAgain());
        }

        public void ListTypes(Garage<Vehicle> garage)
        {
            Console.Clear();
            var list = garage.FindTypes();
            Console.WriteLine($"Types of vehicles currently parked in {garage.Name}:");
            foreach (var key in list) { Console.WriteLine($"{key.Key}: {key.Value}"); }
        }

        public bool FindPlateInGarage(string plate, Garage<Vehicle> garage)
        {
            Console.Clear();
            if (garage.FindPlate(plate)) { Console.WriteLine($"A vehicle with the registry number {plate} is parked at the location."); return true; }
            else { Console.WriteLine(NOSUCHCAR); return false; }
        }

        public bool ParkKnownVehicle(string reg, Garage<Vehicle> garage)
        {
            if (garage.IsVehicleKnown(reg)) { garage.ParkKnownVehicle(reg); return true; }
            else { return false; }
        }

        public void FindVehiclesByProperty(Garage<Vehicle> garage)
        {
            List<Vehicle> vehicles = garage.ListVehicles();
            List<Vehicle> finishedList = new();
            Dictionary<string, string> criteria = GetFilters();

            if (vehicles.Count == 0)
            {
                Console.WriteLine("List of vehicles at this location is empty.");
                return;
            }

            List<Vehicle> tempList = new();
            foreach (var key in criteria)
            {
                switch (key.Key)
                {
                    case "CATEGORY":
                        tempList = vehicles.Where(v => v.Category.Equals(criteria[key.Key])).ToList();
                        vehicles = tempList.ToList();
                        break;
                    case "MAKE":
                        tempList = vehicles.Where(v => v.Make.Equals(criteria[key.Key])).ToList();
                        vehicles = tempList.ToList();
                        break;
                    case "MODEL":
                        tempList = vehicles.Where(v => v.Model.Equals(criteria[key.Key])).ToList();
                        vehicles = tempList.ToList();
                        break;
                    case "TYPE":
                        tempList = vehicles.Where(v => v.Type.Equals(criteria[key.Key])).ToList();
                        vehicles = tempList.ToList();
                        break;
                    case "COLOR":
                        tempList = vehicles.Where(v => v.Color.Equals(criteria[key.Key])).ToList();
                        vehicles = tempList.ToList();
                        break;
                        //case "WINGSPAN":
                        //    tempList = vehicles.Where(v => v.Wingspan.Equals(criteria[key.Value])).ToList();
                        //    vehicles = tempList.ToList();
                }
            }

            finishedList = tempList.ToList();

            if (!finishedList.Any())
            {
                Console.WriteLine("No vehicles with the set filters were found.");
            }
            else
            {
                Console.WriteLine("Printing list of vehicles based on your set filters:");
                foreach (var vehicle in finishedList)
                {
                    Console.WriteLine(vehicle);
                }
            }

            UI.WaitForUserInput();
        }

        internal string[] GetBaseInfo()
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

        internal Dictionary<string, string> GetFilters()
        {
            var criteria = new Dictionary<string, string>();
            string input;

            do
            {
                string property = UI.GetString("Enter the property you want to filter by;\n" +
                    "Make, Model, Type, Color, Category (e.g. Motorcycle or Car)\n" +
                    "or enter 'done' to finish: ");

                if (property.ToUpper() == "DONE")
                {
                    break;
                }

                string value = UI.GetString($"Enter the {property} you wish to filter with: ");
                criteria.Add(property, value);
                input = UI.GetString("Do you want to add another filter? (yes/no): ");

            } while (input.ToUpper() != "NO");

            return criteria;
        }
    }
}