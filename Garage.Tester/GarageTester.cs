using Exercise5_Garage;
using Exercise5_Garage.Vehicles;

namespace Exercise5.Tester
{
    public class GarageTester
    {
        Garage<Vehicle> garage = new(50);
        Car car = new Car("Supercar", "Audi", "R8", "BAB113", "Copper", 4, 2, "512");
        Car car2 = new Car("Supercar", "Lamborghini", "Murcielago", "CCA 332", "Metallic", 4, 2, "114");
        Bus bus = new Bus("Bus", "Scania", "K94UB", "BAB112", "Blue", 6, 40, false);


        [Fact]
        public void AddVechile_CheckingMethodAddsVehicleProperly()
        {
            bool result = garage.ParkVehicle(car);
            Assert.True(result);
            Assert.Contains(car, garage.ListVehicles());
        }

        [Fact]
        public void RemoveVehicle()
        {
            garage.ParkVehicle(car);
            bool result = garage.RemoveVehicle("BAB113");
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
    }
}