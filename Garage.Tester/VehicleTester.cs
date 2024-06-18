using Exercise5_Garage.Vehicles;

namespace Exercise5.Tester
{
    public class VehicleTester
    {

        [Fact]
        public void Airplane_MakeSureReturnsStatsCorrectly()
        {
            Airplane test = new("121", "Boeing", "747", "Airplane", "White", 55);
            string result = test.Reg;
            string expected = "121";
            Assert.Equal(expected, result);
            result = test.Make;
            expected = "Boeing";
            Assert.Equal(expected, result);
            result = test.Model;
            expected = "747";
            Assert.Equal(expected, result);
            result = test.Type;
            expected = "Airplane";
            Assert.Equal(expected, result);
            result = test.Color;
            expected = "White";
            Assert.Equal(expected, result);
            result = test.Category;
            expected = "AIRPLANE";
            Assert.Equal(expected, result);
            double res = test.Wingspan;
            Assert.Equal(55, res);
            result = test.ToString();
            expected = "Boeing 747, a White Airplane with the license plate 121 with a wingspan of 55m.";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Boat_MakeSureReturnsStatsCorrectly()
        {
            Boat test = new("999", "Yacht", "X99", "Sailboat", "White with blue stripes", 1);
            string result = test.Reg;
            string expected = "999";
            Assert.Equal(expected, result);
            result = test.Make;
            expected = "Yacht";
            Assert.Equal(expected, result);
            result = test.Model;
            expected = "X99";
            Assert.Equal(expected, result);
            result = test.Type;
            expected = "Sailboat";
            Assert.Equal(expected, result);
            result = test.Color;
            expected = "White with blue stripes";
            Assert.Equal(expected, result);
            result = test.Category;
            expected = "BOAT";
            int res = test.EngineCount;
            Assert.Equal(1, res);
            Assert.Equal(expected, result);
            result = test.ToString();
            expected = "Yacht X99, a White with blue stripes Sailboat with the license plate 999 and 1 engine(s).";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Bus_MakeSureReturnsStatsCorrectly()
        {
            Bus test = new("BAB112", "Scania", "K94UB", "Bus",  "Blue", false);
            string result = test.Reg;
            string expected = "BAB112";
            Assert.Equal(expected, result);
            result = test.Make;
            expected = "Scania";
            Assert.Equal(expected, result);
            result = test.Model;
            expected = "K94UB";
            Assert.Equal(expected, result);
            result = test.Type;
            expected = "Bus";
            Assert.Equal(expected, result);
            result = test.Color;
            expected = "Blue";
            Assert.Equal(expected, result);
            result = test.Category;
            expected = "BUS";
            Assert.Equal(expected, result);
            Assert.False(test.DoubleDecker);
            result = test.ToString();
            expected = "Scania K94UB, a Blue Bus with the license plate BAB112.";
            Assert.Equal(expected, result);
            test = new("BAB112", "Scania", "K94UB", "Bus", "Blue", true);
            Assert.True(test.DoubleDecker);
            result = test.ToString();
            expected = "Scania K94UB, a Blue Bus with the license plate BAB112. This is a double decker bus.";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Car_MakeSureReturnsStatsCorrectly()
        {
            Car test = new("BAB113", "Audi", "R8", "Supercar", "Copper", "512");
            string result = test.Reg;
            string expected = "BAB113";
            Assert.Equal(expected, result);
            result = test.Make;
            expected = "Audi";
            Assert.Equal(expected, result);
            result = test.Model;
            expected = "R8";
            Assert.Equal(expected, result);
            result = test.Type;
            expected = "Supercar";
            Assert.Equal(expected, result);
            result = test.Color;
            expected = "Copper";
            Assert.Equal(expected, result);
            result = test.Category;
            expected = "CAR";
            Assert.Equal(expected, result);
            result = test.VIN;
            expected = "512";
            Assert.Equal(expected, result);
            result = test.ToString();
            expected = "Audi R8, a Copper Supercar with the license plate BAB113 and the VIN number: 512.";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Motorcycle_MakeSureReturnsStatsCorrectly()
        {
            Motorcycle test = new("BBA221", "Hayabusa", "Ninja H2", "Motorcycle", "Black", 998);
            string result = test.Reg;
            string expected = "BBA221";
            Assert.Equal(expected, result);
            result = test.Make;
            expected = "Hayabusa"; //I know it's actually Suzuki but shush.
            Assert.Equal(expected, result);
            result = test.Model;
            expected = "Ninja H2";
            Assert.Equal(expected, result);
            result = test.Type;
            expected = "Motorcycle";
            Assert.Equal(expected, result);
            result = test.Color;
            expected = "Black";
            Assert.Equal(expected, result);
            result = test.Category;
            expected = "MOTORCYCLE";
            Assert.Equal(expected, result);
            double res = test.CubicEngine;
            Assert.Equal(998, res);
            result = test.ToString();
            expected = "Hayabusa Ninja H2, a Black Motorcycle with the license plate BBA221 and a 998 CC engine.";
            Assert.Equal(expected, result);
        }

    }
}