using Exercise5_Garage.UI;
using Exercise5_Garage.Vehicles;
using System.Collections.Generic;

namespace Exercise5_Garage
{
    internal class GarageManager
    {
        UserInterface UI = new UserInterface();
        Dictionary<string, Garage<Vehicle>> locations = new();
        Garage<Vehicle> garage = new(50, "TEST");
        GarageHandler handler = new GarageHandler();
        
        
        
        public void Run()
        {
            bool running = true;
            string input = "";
            locations.Add("TEST", garage);
            garage = locations["TEST"];
            
            while (running)
            {
                Console.Clear();
                Console.WriteLine(UI.GetMenu(garage.Name));
                input = UI.GetString("");

                switch (input)
                {
                    case "1":
                        handler.ListVehicles(garage);
                        UI.WaitForUserInput();
                        break;
                    case "2":
                        handler.ListTypes(garage);
                        UI.WaitForUserInput();
                        break;
                    case "3":
                        ArrivalsAndDepartures();
                        break;
                    case "4":
                        CreateNewLocation();
                        break;
                    case "5":
                        PopulateLocation(); //NOT IMPLEMENTED
                        break;
                    case "6":
                        handler.FindPlateInGarage(UI.GetString("Please enter the registry plate of the vehicle you wish to search for."), garage);
                        UI.WaitForUserInput();
                        break;
                    case "7":
                        FindVehiclesByProperty(); //NOT IMPLEMENTED
                        break;
                    case "0":
                        SwitchLocation();
                        break;
                    case "EXIT":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Couldn't recognize the input. Please try again.");
                        UI.WaitForUserInput();
                        break;
                }
            }
        }

        private void ArrivalsAndDepartures()
        {
            bool running = true;
            string input = "";
            while (running)
            {
                input = UI.GetString("Write 'A' for arrivals and 'D' for departures. To get back to the menu use the 'Back' command.");
                switch (input)
                {
                    case "A":
                        HandleArrival();
                        running = false;
                        break;
                    case "D":
                        HandleDeparture();
                        running = false;
                        break;
                    case "BACK":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Only the inputs of 'A', 'D' or 'back' work. Please try again");
                        break;
                }
            }
        }

        private void HandleArrival()
        {
            bool running = true;
            string input = "";
            while (running)
            {
                bool known = UI.GetBoolean("Has the vehicle been parked at this location before?: ");
                if (known)
                {
                    string reg = UI.GetString("Enter license plate of vehicle");
                    bool parked = handler.ParkKnownVehicle(reg, garage);
                    if (!parked) { Console.WriteLine("Vehicle was not found in the registry. Please register the vehicle."); }
                    else { Console.WriteLine($"{reg} has been parked."); UI.WaitForUserInput(); break; }
                    input = UI.GetString("Please define the type of vehicle you are parking.");
                }
                else
                {
                    input = UI.GetString("Please define the type of vehicle you are parking.");
                }
                switch (input)
                {
                    case "CAR":
                        Car car = handler.CreateNewCar();
                        handler.ParkVehicle(car, garage);
                        garage.AddKnownVehicle(car);
                        UI.WaitForUserInput();
                        running = false;
                        break;
                    case "BUS":
                        Bus bus = handler.CreateNewBus();
                        handler.ParkVehicle(bus, garage);
                        UI.WaitForUserInput();
                        running = false;
                        break;
                    case "AIRPLANE":
                        Airplane plane = handler.CreateNewAirplane();
                        handler.ParkVehicle(plane, garage);
                        UI.WaitForUserInput();
                        running = false;
                        break;
                    case "PLANE":
                        plane = handler.CreateNewAirplane();
                        handler.ParkVehicle(plane, garage);
                        UI.WaitForUserInput();
                        running = false;
                        break;
                    case "MOTORCYCLE":
                        Motorcycle mc = handler.CreateNewMC();
                        handler.ParkVehicle(mc, garage);
                        UI.WaitForUserInput();
                        running = false;
                        break;
                    case "MC":
                        mc = handler.CreateNewMC();
                        handler.ParkVehicle(mc, garage);
                        UI.WaitForUserInput();
                        running = false;
                        break;
                    case "BOAT":
                        Boat boat = handler.CreateNewBoat();
                        handler.ParkVehicle(boat, garage);
                        UI.WaitForUserInput();
                        running = false;
                        break;
                    case "BACK":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Only Car, Bus, Motorcycle, Airplane or Boat are accepted vehicle types. To return to previous menu enter 'Back'.");
                        break;
                }
            }
        }

        private void HandleDeparture()
        {
            handler.RemoveVehicle(UI.GetString("Plate of vehicle leaving: "), garage);
            UI.WaitForUserInput();
        }

        private void SwitchLocation()
        {
            Console.WriteLine("Saved locations: ");
            foreach (KeyValuePair<string, Garage<Vehicle>> kvp in locations)
            {
                Console.WriteLine(kvp.Key);
            }
            string key = UI.GetString("Name of location to switch focus to: ");
            if (!locations.ContainsKey(key)) { Console.WriteLine("No such location in the registry."); UI.WaitForUserInput(); }
            else { garage = locations[key]; Console.WriteLine($"Focused location successfully changed to {key}."); UI.WaitForUserInput(); }
        }

        private void CreateNewLocation()
        {
            int capacity = (int)UI.GetNumber("Enter the capacity of the new location: ");
            string name = UI.GetString("Enter the name of the new location: ");
            while (locations.ContainsKey(name))
            {
                name = UI.GetString("A location with that name already exists.");
            }
            locations.Add(name, new Garage<Vehicle>(capacity, name));
            Console.WriteLine($"{name} was added to the list of locations successfully.");
            UI.WaitForUserInput();
        }

        private void PopulateLocation()
        {
            List<Vehicle> testVehicles = new List<Vehicle> {
            new Car("BBA221", "AUDI", "R8", "SUPERCAR", "COPPER", "521"),
            new Airplane ("2212", "BOEING", "747", "PASSANGER PLANE", "WHITE", 64),
            new Boat ("98521AF4", "YACHT", "X99", "SAILBOAT", "WHITE WITH BLUE STRIPES", 1),
            new Motorcycle("HHH222", "HAYABUSA", "NINJA H2", "MC", "BLACK", 998),
            new Bus("BAB112", "SCANIA", "K94UB", "BUS", "BLUE", false),
            new Car("CCA335", "LAMBORGHINI", "MURCIELAGO", "SUPERCAR", "YELLOW", "663"),
            new Car("RAN321", "RENAULT", "CLIO", "HATCHBACK", "RED", "959"),
            new Car("NNA592", "PEUGEOT", "508", "SEDAN", "BLACK", "853"),
            new Car("REN449", "REUNAULT", "MEGANE", "SEDAN", "BLACK", "985"),
            new Bus("NAD959", "MERCEDES", "SPRINTER", "MINIBUS", "WHITE", false),
            new Bus("GOA589", "BEULAS", "JEWEL", "DOUBLEDECKER", "RED", true),
            new Bus("MGA512", "SCANIA", "TOURING", "BUS", "BLUE", false),
            new Motorcycle("KMJ982", "HONDA", "CBR650R", "MC", "RED", 649),
            new Motorcycle("KDF645", "DUCATI", "DIAVEL V4", "MC", "RED", 1158)
            };

            if (testVehicles.Count > garage.Capacity) 
            { 
                Console.WriteLine("List of test vehicles exceeds the capacity of current location.\n" +
                "Will proceed with filling the location from test vehicle list but ignore the ones that can't fit."); 

                for (int i = 0; i < garage.Capacity; i++)
                {
                    garage.ParkVehicle(testVehicles[i]);
                    garage.AddKnownVehicle(testVehicles[i]);
                }
                Console.WriteLine($"Populated {garage.Name} with {garage.Capacity} vehicle(s).");
                UI.WaitForUserInput();
            }
            else
            {
                foreach (var vehicle in testVehicles)
                {
                    garage.ParkVehicle(vehicle); 
                    garage.AddKnownVehicle(vehicle);
                }
                Console.WriteLine($"Populated {garage.Name} with {testVehicles.Count} vehicle(s).");
                UI.WaitForUserInput();
            }
        }

        private void FindVehiclesByProperty()
        {
            throw new NotImplementedException();
        }
    }
}
