using Exercise5_Garage.Vehicles;

namespace Exercise5_Garage
{
    internal interface IGarageHandler
    {
        bool ParkKnownVehicle(string reg, IGarage<Vehicle> garage);
        bool FindPlateInGarage(string plate, IGarage<Vehicle> garage);
        bool DepartVehicle(string reg, IGarage<Vehicle> garage);
        bool ParkVehicle(Vehicle vehicle, IGarage<Vehicle> garage);
        void ListTypes(IGarage<Vehicle> garage);
        void FindVehiclesByProperty(IGarage<Vehicle> garage);
        void ListVehicles(IGarage<Vehicle> garage);
        Car CreateNewCar();
        Bus CreateNewBus();
        Boat CreateNewBoat();
        Airplane CreateNewAirplane();
        Motorcycle CreateNewMC();
    }
}