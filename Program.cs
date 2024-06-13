using Exercise5_Garage;
using Exercise5_Garage.UI;
using Exercise5_Garage.Vehicles;

namespace Exercise5_Garage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserInterface<Vehicle> UI = new UserInterface<Vehicle>();
            Garage<Vehicle> garage = new(50);
            GarageHandler handler = new GarageHandler();
            Car car = new Car("Supercar", "Audi", "R8", "BAB113", "Copper", 4, 2, "512");
            Car car2 = new Car("Supercar", "Lamborghini", "Murcielago", "CCA 332", "Metallic", 4, 2, "114");
            Bus bus = new Bus("Bus", "Scania", "K94UB", "BAB112", "Blue", 6, 40, false);


            //var res = garage.Where(v => v.GetSymbol() == 'T');
            handler.AddVehicle(car, garage);
            handler.AddVehicle(car2, garage);
            handler.AddVehicle(bus, garage);
            UI.PrintSpaces(garage.OneTimeUseMethodThatOnlyExistsForAestheticsAndNeverAgain());
            handler.RemoveVehicle("BAB113", garage);
            UI.PrintSpaces(garage.OneTimeUseMethodThatOnlyExistsForAestheticsAndNeverAgain());
            handler.ListVehicles(garage);
            handler.ListTypes(garage);
            Console.ReadLine();
        }
    }
}
