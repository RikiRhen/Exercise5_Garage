namespace Exercise5_Garage
{
    internal interface IGarageHandler
    {
        bool ParkKnownVehicle(string reg, Garage<Vehicle> garage);
        bool FindPlateInGarage(string plate, Garage<Vehicle> garage);
        bool DepartVehicle(string reg, Garage<Vehicle> garage);
        bool ParkVehicle(Vehicle vehicle, Garage<Vehicle> garage);
        void ListTypes(Garage<Vehicle> garage);
        void FindVehiclesByProperty(Garage<Vehicle> garage);
        void ListVehicles(Garage<Vehicle> garage);
    }
}