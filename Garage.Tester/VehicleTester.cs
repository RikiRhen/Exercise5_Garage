using Exercise5_Garage.Vehicles;

namespace Exercise5.Tester
{
    public class VehicleTester
    {

        [Fact]
        public void Airplane_MakeSureReturnsToStringCorrectly()
        {
            Airplane test = new("121", "Boeing", "Airbus 704", "Airplane", "White", 55);
            string result = test.ToString();
            string expected = "Boeing Airbus 704, a White Airplane with the license plate 121 with a wingspan of 55m.";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Boat_MakeSureReturnsToStringCorrectly()
        {
            Boat test = new("999", "Yacht", "X99", "Sailboat", "White with blue stripes", 1);
            string result = test.ToString();
            string expected = "Yacht X99, a White with blue stripes Sailboat with the license plate 999 and 1 engine(s).";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Bus_MakeSureReturnsToStringCorrectly()
        {
            Bus test = new("BAB112", "Scania", "K94UB", "Bus",  "Blue", false);
            string result = test.ToString();
            string expected = "Scania K94UB, a Blue Bus with the license plate BAB112.";
            Assert.Equal(expected, result);
            test = new("BAB112", "Scania", "K94UB", "Bus", "Blue", true);
            result = test.ToString();
            expected = "Scania K94UB, a Blue Bus with the license plate BAB112. This is a double decker bus.";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Car_MakeSureReturnsToStringCorrectly()
        {
            Car test = new("BAB113", "Audi", "R8", "Supercar", "Copper", "512");
            string result = test.ToString();
            string expected = "Audi R8, a Copper Supercar with the license plate BAB113 and the VIN number: 512.";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Motorcycle_MakeSureReturnsToStringCorrectly()
        {
            Motorcycle test = new("BBA221", "Hayabusa", "Ninja H2", "Motorcycle", "Black", 998);
            string result = test.ToString();
            string expected = "Hayabusa Ninja H2, a Black Motorcycle with the license plate BBA221 and a 998 CC engine.";
            Assert.Equal(expected, result);
        }

    }
}