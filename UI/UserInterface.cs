using System.Linq.Expressions;

namespace Exercise5_Garage.UI
{
    internal class UserInterface : IUserInterface
    {
        public string GetMenu(string garage)
        {
            return $"{garage} Menu: " +
                "\n1. List the parked vehicles." +
                "\n2. List the type of vehicles." +
                "\n3. Arrivals and departures." +
                "\n4. Create new location with a set capacity." +
                "\n5. Populate the location from a preset of vehicles." +
                "\n6. Search for plate." +
                "\n7. Search based on property." + //WIP
                "\n0. Switch location." +
                "\nExit - to close the program.";
        }

        public void WaitForUserInput()
        {
            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();
        }

        public string GetString(string prompt)
        {
            string? result;
            while (true)
            {
                try
                {
                    Console.WriteLine(prompt);
                    result = Console.ReadLine();

                    if (string.IsNullOrEmpty(result) || string.IsNullOrWhiteSpace(result))
                    {
                        throw new ArgumentException("Input cannot be empty or consist only of white space.");
                    }

                    return result.ToUpper();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public double GetNumber(string prompt)
        {
            double result = -1;

            while (true)
            {
                try
                {
                    Console.WriteLine(prompt);
                    double.TryParse(Console.ReadLine(), out result);

                    if (result == -1)
                    {
                        throw new ArgumentException("Input cannot be a negative number.");
                    }
                    return result;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public bool GetBoolean(string prompt)
        {
            while (true)
            {
                string input = GetString(prompt).ToUpper();

                if (input.Equals("YES"))
                {
                    return true;
                }
                else if (input.Equals("NO"))
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Could not register your answer. Please write 'Yes' or 'No'");
                }
            }
        }

        internal void PrintSpaces(Vehicle[] list)
        {
            int i = 0;
            foreach (Vehicle v in list)
            {
                if (i % 20 == 0) { Console.Write("\n|"); }
                else if (i % 10 == 0) { Console.Write("\n\n|"); }
                if (v != null) { Console.Write($"{v.GetSymbol()}|"); i++; }
                else { Console.Write(" |"); i++; }
            }
            Console.WriteLine("\n");
        }
    }
}
