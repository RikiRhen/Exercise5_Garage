namespace Exercise5_Garage
{
    internal interface IGarageHandler
    {
        void FindPlateInGarage(string plate, Garage<Vehicle> garage);
        void FindVehiclesByProperty(Garage<Vehicle> garage);
        void ListTypes(Garage<Vehicle> garage);
        void ListVehicles(Garage<Vehicle> garage);
        bool ParkKnownVehicle(string reg, Garage<Vehicle> garage);
        void ParkVehicle(Vehicle vehicle, Garage<Vehicle> garage);
        void RemoveVehicle(string reg, Garage<Vehicle> garage);
    }
}