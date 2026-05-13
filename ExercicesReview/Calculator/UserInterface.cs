using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    internal class UserInterface
    {
        public bool ShowMessage(string message)
        {
            Console.WriteLine(message);
            return true;
        }
        public bool ShowError(string error)
        {
            Console.WriteLine($"Error: {error}");
            return true;
        }
        public string ShowMenu()
        {
            Console.WriteLine("""
                        +-x= CALCULATOR =x-+
                        --------------------
                Select an operation:
                1. Addition
                2. Subtraction
                3. Multiplication
                4. Division
                0. Exit
                """);
            return(Console.ReadLine());
        }
    }
}
