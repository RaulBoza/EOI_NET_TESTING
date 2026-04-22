using System;
using System.Globalization;

// Calculadora de consola simple (español)
while (true)
{
    Console.WriteLine();
    Console.WriteLine("--- Calculadora ---");
    Console.WriteLine("1) Sumar");
    Console.WriteLine("2) Restar");
    Console.WriteLine("3) Multiplicar");
    Console.WriteLine("4) Dividir");
    Console.WriteLine("5) Potencia");
    Console.WriteLine("6) Salir");
    Console.Write("Selecciona una opción (1-6): ");

    var option = Console.ReadLine();
    if (option == "6") break;

    if (!int.TryParse(option, out var opt) || opt < 1 || opt > 5)
    {
        Console.WriteLine("Opción inválida. Intenta de nuevo.");
        continue;
    }

    double a = ReadDouble("Introduce el primer número: ");
    double b = ReadDouble("Introduce el segundo número: ");

    try
    {
        double result = opt switch
        {
            1 => a + b,
            2 => a - b,
            3 => a * b,
            4 => Divide(a, b),
            5 => Math.Pow(a, b),
            _ => throw new InvalidOperationException()
        };

        Console.WriteLine($"Resultado: {result}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

static double ReadDouble(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        var s = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(s))
        {
            Console.WriteLine("Entrada vacía. Intenta de nuevo.");
            continue;
        }

        // Permitir coma o punto como separador decimal
        s = s.Trim().Replace(',', '.');
        if (double.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out var value))
            return value;

        Console.WriteLine("Número inválido. Intenta de nuevo.");
    }
}

static double Divide(double x, double y)
{
    if (y == 0) throw new DivideByZeroException("No se puede dividir entre cero.");
    return x / y;
}

Console.WriteLine("Saliendo. Hasta luego.");
