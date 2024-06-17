
namespace Exercise5_Garage
{
    internal interface IGarage<T> where T : Vehicle
    {
        int Capacity { get; }
        int FreeSpots { get; }
        string Name { get; }

        bool AddKnownVehicle(T item);
        bool FindPlate(string plate);
        bool ParkVehicle(Vehicle v);
        bool RemoveKnownVehicle(string reg);
        bool VehicleDeparture(string reg);
        Dictionary<string, int> FindTypes();
        void ParkKnownVehicle(string reg);
        IEnumerator<T> GetEnumerator();
        List<T> ListVehicles();
    }
}