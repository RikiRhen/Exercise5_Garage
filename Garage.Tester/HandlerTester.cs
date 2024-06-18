using System;
using Exercise5_Garage;
using Exercise5_Garage.Vehicles;

namespace Garage.Tester
{
    public class HandlerTester
    {
        private Garage<Vehicle> _garage = new(50, "TEST");
        private GarageHandler _handler = new();
        Car car = new Car("BBA221", "AUDI", "R8", "SUPERCAR", "COPPER", "521");
       

        [Fact]
        public void ParkKnownVehicle()
        {
            _garage.AddKnownVehicle(car);
            bool result = _handler.ParkKnownVehicle("BBA221", _garage);
            Assert.True(result);
            result = _handler.ParkKnownVehicle("AAA111", _garage);
            Assert.False(result);
        }

        [Fact]
        public void ParkVehicle()
        {
            bool result = _handler.ParkVehicle(car, _garage);
            Assert.True(result);
        }

        [Fact]
        public void DepartVehicle() //Returns bool, paramters: a string(licence plate) and a garage
        {
            bool result = _handler.ParkVehicle(car, _garage);
            Assert.True(result);
            result = _handler.DepartVehicle("BBA221", _garage);
            Assert.True(result);
        }
    }
}
