using Exercise5_Garage.Vehicles;

namespace Exercise5.Tester
{
    public class VehicleTester
    {

        [Fact]
        public void Airplane_MakeSureReturnsToStringCorrectly()
        {
            Airplane test = new("Airplane", "Boeing", "Airbus 704", "121", "White", 6, 250, 55);
            string result = test.ToString();
            string expected = "Boeing Airbus 704, a White Airplane with 6 wheels that holds 250 passenger(s) with a wingspan of 55m.";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Boat_MakeSureReturnsToStringCorrectly()
        {
            Boat test = new("Sailboat", "Yacht", "X99", "999", "White with blue stripes", 0, 8, 1);
            string result = test.ToString();
            string expected = "Yacht X99, a White with blue stripes Sailboat with 0 wheels that holds 8 passenger(s) with 1 engine(s).";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Bus_MakeSureReturnsToStringCorrectly()
        {
            Bus test = new("Bus", "Scania", "K94UB", "BAB112", "Blue", 6, 40, false);
            string result = test.ToString();
            string expected = "Scania K94UB, a Blue Bus with 6 wheels that holds 40 passenger(s).";
            Assert.Equal(expected, result);
            test = new("Bus", "Scania", "K94UB", "BAB112", "Blue", 6, 40, true);
            result = test.ToString();
            expected = "Scania K94UB, a Blue Bus with 6 wheels that holds 40 passenger(s). This is a double decker bus.";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Car_MakeSureReturnsToStringCorrectly()
        {
            Car test = new("Supercar", "Audi", "R8", "BAB113", "Copper", 4, 2, "512");
            string result = test.ToString();
            string expected = "Audi R8, a Copper Supercar with 4 wheels that holds 2 passenger(s), VIN number: 512.";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Motorcycle_MakeSureReturnsToStringCorrectly()
        {
            Motorcycle test = new("Motorcycle", "Hayabusa", "Ninja H2", "BBA 221", "Black", 2, 1, 998);
            string result = test.ToString();
            string expected = "Hayabusa Ninja H2, a Black Motorcycle with 2 wheels that holds 1 passenger(s) with a 998 CC engine.";
            Assert.Equal(expected, result);
        }

    }
}