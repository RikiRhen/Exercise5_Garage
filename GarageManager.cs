using Exercise5_Garage.UI;
using Exercise5_Garage.Vehicles;

namespace Exercise5_Garage
{
    internal class GarageManager
    {
        UserInterface UI = new UserInterface();
        Garage<Vehicle> garage = new(50);
        GarageHandler handler = new GarageHandler();
        
        Car car = new Car("Supercar", "Audi", "R8", "BAB113", "Copper", "512");
        Car car2 = new Car("Supercar", "Lamborghini", "Murcielago", "CCA 332", "Metallic", "114");
        Bus bus = new Bus("Bus", "Scania", "K94UB", "BAB112", "Blue", false);
        //handler.ParkVehicle(car, garage);
        //handler.ParkVehicle(car2, garage);
        //handler.ParkVehicle(bus, garage);
        
        public void Run()
        {
            bool running = true;
            string input = "";
            handler.ParkVehicle(car, garage);
            while (running)
            {
                Console.Clear();
                Console.WriteLine(UI.GetMenu());
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
                        CreateNewGarage(); //NOT IMPLEMENTED
                        break;
                    case "5":
                        PopulateGarageFromFile(); //NOT IMPLEMENTED
                        break;
                    case "6":
                        handler.FindPlateInGarage(UI.GetString("Please enter the registry plate of the vehicle you wish to search for."), garage);
                        UI.WaitForUserInput();
                        break;
                    case "7":
                        FindVehiclesByProperty(); //NOT IMPLEMENTED
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
                input = UI.GetString("What type of vehicle are you parking?");
                switch (input)
                {
                    case "CAR":
                        Car car = handler.CreateNewCar();
                        handler.ParkVehicle(car, garage);
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

        private void CreateNewGarage()
        {
            throw new NotImplementedException();
        }

        private void PopulateGarageFromFile()
        {
            throw new NotImplementedException();
        }

        private void FindVehiclesByProperty()
        {
            throw new NotImplementedException();
        }
    }
}
