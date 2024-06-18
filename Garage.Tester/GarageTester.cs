using Exercise5_Garage;
using Exercise5_Garage.Vehicles;

namespace Exercise5.Tester
{
    public class GarageTester
    {
        Garage<Vehicle> garage = new(50, "test");
        Car car = new("BAB113", "Audi", "R8", "Supercar", "Copper", "512");
        Car car2 = new("CCA 332", "Lamborghini", "Murcielago", "Supercar", "Metallic", "114");
        Bus bus = new("BAB002", "Scania", "K94UB", "Bus", "Blue", false);


        [Fact]
        public void ParkVehicle_CorrectlyParksVehicle()
        {
            bool result = garage.ParkVehicle(car);
            Assert.True(result);
            Assert.Contains(car, garage.ListVehicles());
        }

        [Fact]
        public void VehicleDeparture_CorrectlyDepartsVehicle()
        {
            garage.ParkVehicle(car);
            bool result = garage.VehicleDeparture("BAB113");
            Assert.True(result);
            Assert.DoesNotContain(car, garage.ListVehicles());
        }

        [Fact]
        public void ListVehicles_ReturnsCorrectListWithAllAddedVehicles()
        {
            garage.ParkVehicle(car);
            garage.ParkVehicle(car2);
            garage.ParkVehicle(bus);
            var vehicles = garage.ListVehicles();
            Assert.Contains(car, vehicles);
            Assert.Contains(car2, vehicles);
            Assert.Contains(bus, vehicles);
        }

        [Fact]
        public void FindTypes_ReturnsCorrectDictionaryWithAllTypes()
        {
            garage.ParkVehicle(car);
            garage.ParkVehicle(car2);
            garage.ParkVehicle(bus);
            var vehicles = garage.FindTypes();

            Assert.True(vehicles.ContainsKey("Supercar"));
            Assert.True(vehicles.ContainsKey("Bus"));
            Assert.Equal(2, vehicles["Supercar"]);
            Assert.Equal(1, vehicles["Bus"]);
        }

        [Fact]
        public void FindPlate_CorrectlyFindsPlate()
        {
            garage.ParkVehicle(car);
            garage.ParkVehicle(car2);
            garage.ParkVehicle(bus);

            Assert.True(garage.FindPlate("BAB113"));
            Assert.False(garage.FindPlate("nah"));
        }

        [Fact]
        public void AddKnownVehicle_IsCorrectlyAddingNewVehicleToListOfKnownVehicles()
        {
            bool result = garage.AddKnownVehicle(car);
            Assert.True(result);
        }

        [Fact]
        public void IsVehicleKnown_IsCorrectlyReturningKnownVehicles()
        {
            garage.AddKnownVehicle(car);
            bool result = garage.IsVehicleKnown(car.Reg);
            Assert.True(result);
            result = garage.IsVehicleKnown(car2.Reg);
            Assert.False(result);
        }

        [Fact]
        public void RemoveKnownVehicle_IsCorrectlyRemovingVehicles()
        {
            garage.AddKnownVehicle(car);
            garage.AddKnownVehicle(car2);
            bool result = garage.RemoveKnownVehicle(car2.Reg);
            Assert.True(result);
            result = garage.IsVehicleKnown(car2.Reg);
            Assert.False(result);
        }
    }
}