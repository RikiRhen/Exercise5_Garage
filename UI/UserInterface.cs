namespace Exercise5_Garage.UI
{
    internal class UserInterface<T>
    {
        internal void PrintMenu()
        {
            //Goes to manager-class when implemented
            Console.Clear();
            Console.WriteLine(GetMenu());
        }
        internal string GetMenu()
        {
            return "Garage Menu: " +
                "\n1. List the parked vehicles." +
                "\n2. List the type of vehicles." +
                "\n3. Arrivals and departures." + //ToDo: arrival of new car, create car and let it park.
                "\n4. Create new garage with a set capacity." + //ToDo
                "\n5. Populate the garage from file." + //ToDo
                "\n6. Search for plate." +
                "\n7. Search based on property." + //ToDo
                "\nExit - to close the program.";
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
