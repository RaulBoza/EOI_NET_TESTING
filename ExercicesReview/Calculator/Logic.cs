using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    internal class Logic
    {
        UserInterface ui = new UserInterface();
        public bool ValidOption(string option) => option is "1" or "2" or "3" or "4";
        public bool Calculate(string option)
        {
            if (!(option is "1" or "2" or "3" or "4"))
            {
                ui.ShowError("Invalid option. Please select a valid operation.");
                return true;
            }
            double num1 = GetNumber("Enter first number: ");
            double num2 = GetNumber("Enter second number: ");
            if(option == "4" && num2 == 0)
            {
                ui.ShowError("Cannot divide by zero.");
                return true;
            }
            double result = EvaluateOperation(option, num1, num2);
            ui.ShowMessage($"Result: {result}");
            return true;
        }

        public double GetNumber(string message)
        {
            double number;
            ui.ShowMessage(message);
            string input = Console.ReadLine();

            while (!double.TryParse(input, out number))
            {
                ui.ShowError("Invalid input. Please enter a valid number.");
                input = Console.ReadLine();
            }
            return number;
        }

        public double EvaluateOperation(string option, double num1, double num2)
        {
            return option switch
            {
                "1" => Add(num1, num2),
                "2" => Subtract(num1, num2),
                "3" => Multiply(num1, num2),
                "4" => Divide(num1, num2),
                _ => throw new InvalidOperationException("Invalid operation")
            };
        }

        public double Add(double num1, double num2) => num1 + num2;
        public double Subtract(double num1, double num2) => num1 - num2;
        public double Multiply(double num1, double num2) => num1 * num2;
        public double Divide(double num1, double num2) => num1 / num2;
    }
}
