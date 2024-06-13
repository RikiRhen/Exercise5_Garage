using System.Collections;

namespace Exercise5_Garage
{
    internal class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private static int _capacity;
        private T[] _vehicles;
        private int _freeSpots = _capacity;

        internal Garage(int capacity)
        {
            _capacity = capacity;
            _vehicles = new T[capacity];
        }

        internal bool FindPlate(string plate)
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

        internal List<T> ListVehicles()
        {
            List<T> list = new();
            foreach (Vehicle v in _vehicles) { if (v != null) { list.Add((T)v); } };
            return list;
        }

        internal Dictionary<string, int> FindTypes()
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

        internal bool ParkVehicle(Vehicle v)
        {
            int spot = FindSpot();
            if (spot >= 0 && spot < _capacity)
            {
                _vehicles[spot] = (T)v;
                _freeSpots--;
                return true;
            }
            return false;
        }

        internal bool RemoveVehicle(string reg)
        {
            foreach (T v in _vehicles)
            {
                if (v.Reg == reg)
                {
                    int index = Array.IndexOf(_vehicles, v);
                    _vehicles[index] = null!;
                    return true;
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
            return (T[])_vehicles;
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