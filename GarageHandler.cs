
namespace Exercise5_Garage
{
    internal class GarageHandler
    {
        internal void AddVehicle(Vehicle vehicle, Garage<Vehicle> garage)
        {
            if (garage.ParkVehicle(vehicle)) { Console.WriteLine($"{vehicle.Make} {vehicle.Model} {vehicle.Reg}, was parked successfully."); }
        }

        internal void RemoveVehicle(string reg, Garage<Vehicle> garage)
        {
            if (garage.RemoveVehicle(reg)) { Console.WriteLine($"{reg} has left the garage."); }
        }

        internal void ListVehicles(Garage<Vehicle> garage)
        {
            foreach (Vehicle v in garage.ListVehicles()) { Console.WriteLine(v); }
        }

        internal void ListTypes(Garage<Vehicle> garage)
        {
            var list = garage.FindTypes();
            Console.WriteLine("Types of vehicles in the garage:");
            foreach (var key in list) { Console.WriteLine($"{key.Key}: {key.Value}"); }
        }
    }
}