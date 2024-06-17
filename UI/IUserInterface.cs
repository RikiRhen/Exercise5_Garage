namespace Exercise5_Garage.UI
{
    internal interface IUserInterface
    {
        bool GetBoolean(string prompt);
        string GetMenu(string garage);
        double GetNumber(string prompt);
        string GetString(string prompt);
        void WaitForUserInput();
    }
}