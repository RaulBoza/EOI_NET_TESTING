
namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator();
        }
        
        static void Calculator()
        {
            UserInterface ui = new UserInterface();
            Logic logic = new Logic();
            bool exitmenu = false;
            while (!exitmenu)
            {
                string choice = ui.ShowMenu();
                exitmenu = choice == "0";
               
                exitmenu = !logic.Calculate(choice);

            }
            ui.ShowMessage("Closing calculator...");
        }
    }
}