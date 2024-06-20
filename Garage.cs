using System.Collections;

namespace Exercise5_Garage
{
    internal class Garage<T> : IEnumerable<T>, IGarage<T> where T : Vehicle
    {
        public string Name { get; }
        public int Capacity { get; }
        public int FreeSpots { get; private set; }
        private T[] _vehicles;
        private Dictionary<string, T> _knownVehicles = new();

        internal Garage(int capacity, string name)
        {
            _vehicles = new T[capacity];
            FreeSpots = capacity;
            Capacity = capacity;
            Name = name;
        }

        public bool FindPlate(string plate)
        {
            foreach (var item in ListVehicles())
            {
                if (item.Reg.Equals(plate))
                {
                    return true;
                }
            }
            return false;
        }

        public bool AddKnownVehicle(T item)
        {

            if (_knownVehicles.Count > 0 && _knownVehicles.ContainsKey(item.Reg)) { return false; }
            else { _knownVehicles.Add(item.Reg, item); return true; }
        }

        public bool RemoveKnownVehicle(string reg)
        {
            if (_knownVehicles.ContainsKey(reg)) { _knownVehicles.Remove(reg); return true; }
            else { return false; }


        }

        internal bool IsVehicleKnown(string reg)
        {
            if (_knownVehicles.ContainsKey(reg)) { return true; }
            else { return false; }

        }

        public void ParkKnownVehicle(string reg)
        {
            ParkVehicle(_knownVehicles[reg]);
        }

        public List<T> ListVehicles()
        {
            List<T> list = new();
            foreach (Vehicle v in _vehicles) { if (v != null) { list.Add((T)v); } };
            return list;
        }

        public Dictionary<string, int> FindTypes()
        {
            Dictionary<string, int> list = new();
            foreach (T item in _vehicles)
            {
                if (item != null)
                {
                    if (list.ContainsKey(item.Type))
                    {
                        list[item.Type]++;
                    }
                    else
                    {
                        list[item.Type] = 1;
                    }
                }
            }
            return list;
        }

        public bool ParkVehicle(Vehicle v)
        {
            int spot = FindSpot();
            if (_knownVehicles.ContainsKey(v.Reg))
            {
                Console.WriteLine("A vehicle with that licence plate is already registered. Parking failed.");
                return false;
            }
            if (spot >= 0 && spot < Capacity)
            {
                _vehicles[spot] = (T)v;
                FreeSpots--;
                return true;
            }
            Console.WriteLine("Location is full. Cannot park vehicle here right now.");
            return false;
        }

        public bool VehicleDeparture(string reg)
        {
            foreach (T v in _vehicles)
            {
                if (v != null)
                {
                    if (v.Reg == reg)
                    {
                        int index = Array.IndexOf(_vehicles, v);
                        _vehicles[index] = null!;
                        FreeSpots++;
                        return true;
                    }
                }
            }
            return false;
        }

        private int FindSpot()
        {
            int result = -1;
            foreach (T v in _vehicles)
            {
                if (v == null) { break; }
                else { result++; }
            }
            return result + 1;
        }

        internal T[] OneTimeUseMethodThatOnlyExistsForAestheticsAndNeverAgain()
        {
            return _vehicles;
        }

        public IEnumerator<T> GetEnumerator()
        {

            foreach (T v in _vehicles)
            {
                if (v != null) { yield return (T)v; }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


    }
}