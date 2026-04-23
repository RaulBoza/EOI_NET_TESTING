using System;

// Programa para calcular área y perímetro de varias figuras geométricas.
// Usa Math.PI, Math.Pow, coalescencia nula y pattern matching.

interface IShape { }

record Circle(double Radius) : IShape;
record Rectangle(double Width, double Height) : IShape;
record Square(double Side) : IShape;
record Triangle(double A, double B, double C) : IShape;
record Ellipse(double A, double B) : IShape; // A = semi-eje mayor, B = semi-eje menor
record Parallelogram(double Base, double Side, double Height) : IShape;
record Rhombus(double D1, double D2) : IShape; // diagonales
record Trapezoid(double Base1, double Base2, double Side1, double Side2, double Height) : IShape;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Seleccione una figura (número) o 's' para salir:");
            Console.WriteLine("1) Círculo\n2) Rectángulo\n3) Cuadrado\n4) Triángulo\n5) Elipse\n6) Paralelogramo\n7) Rombo\n8) Trapecio");
            Console.Write("> ");
            var choice = (Console.ReadLine() ?? string.Empty).Trim().ToLower();
            if (choice == "s" || choice == "salir") break;

            IShape? shape = choice switch
            {
                "1" => CreateCircle(),
                "2" => CreateRectangle(),
                "3" => CreateSquare(),
                "4" => CreateTriangle(),
                "5" => CreateEllipse(),
                "6" => CreateParallelogram(),
                "7" => CreateRhombus(),
                "8" => CreateTrapezoid(),
                _ => null
            };

            if (shape is null)
            {
                Console.WriteLine("Opción no válida. Intente de nuevo.\n");
                continue;
            }

            try
            {
                var area = CalculateArea(shape);
                var perim = CalculatePerimeter(shape);
                Console.WriteLine($"Área: {area:F4}");
                Console.WriteLine($"Perímetro: {perim:F4}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al calcular: {ex.Message}\n");
            }
        }
    }

    static double ReadDouble(string prompt)
    {
        Console.Write(prompt + ": ");
        var s = Console.ReadLine() ?? string.Empty; // coalescencia nula
        if (double.TryParse(s, out var v)) return v;
        Console.WriteLine("Entrada inválida, se usará 0.");
        return 0.0;
    }

    static Circle CreateCircle()
    {
        var r = ReadDouble("Radio");
        return new Circle(r);
    }

    static Rectangle CreateRectangle()
    {
        var w = ReadDouble("Ancho");
        var h = ReadDouble("Alto");
        return new Rectangle(w, h);
    }

    static Square CreateSquare()
    {
        var s = ReadDouble("Lado");
        return new Square(s);
    }

    static Triangle CreateTriangle()
    {
        var a = ReadDouble("Lado a");
        var b = ReadDouble("Lado b");
        var c = ReadDouble("Lado c");
        return new Triangle(a, b, c);
    }

    static Ellipse CreateEllipse()
    {
        var a = ReadDouble("Semi-eje mayor (a)");
        var b = ReadDouble("Semi-eje menor (b)");
        return new Ellipse(a, b);
    }

    static Parallelogram CreateParallelogram()
    {
        var bas = ReadDouble("Base");
        var side = ReadDouble("Lado");
        var h = ReadDouble("Altura");
        return new Parallelogram(bas, side, h);
    }

    static Rhombus CreateRhombus()
    {
        var d1 = ReadDouble("Diagonal 1");
        var d2 = ReadDouble("Diagonal 2");
        return new Rhombus(d1, d2);
    }

    static Trapezoid CreateTrapezoid()
    {
        var b1 = ReadDouble("Base mayor");
        var b2 = ReadDouble("Base menor");
        var s1 = ReadDouble("Lado 1");
        var s2 = ReadDouble("Lado 2");
        var h = ReadDouble("Altura");
        return new Trapezoid(b1, b2, s1, s2, h);
    }

    static double CalculateArea(IShape shape)
    {
        return shape switch
        {
            Circle c => Math.PI * Math.Pow(c.Radius, 2),
            Rectangle r => r.Width * r.Height,
            Square s => Math.Pow(s.Side, 2),
            Triangle t => HeronArea(t.A, t.B, t.C),
            Ellipse e => Math.PI * e.A * e.B,
            Parallelogram p => p.Base * p.Height,
            Rhombus r => (r.D1 * r.D2) / 2.0,
            Trapezoid t => (t.Base1 + t.Base2) / 2.0 * t.Height,
            _ => throw new ArgumentException("Figura desconocida")
        };
    }

    static double CalculatePerimeter(IShape shape)
    {
        return shape switch
        {
            Circle c => 2.0 * Math.PI * c.Radius,
            Rectangle r => 2.0 * (r.Width + r.Height),
            Square s => 4.0 * s.Side,
            Triangle t => t.A + t.B + t.C,
            Ellipse e => Math.PI * (3.0 * (e.A + e.B) - Math.Sqrt((3.0 * e.A + e.B) * (e.A + 3.0 * e.B))),
            Parallelogram p => 2.0 * (p.Base + p.Side),
            Rhombus r => 4.0 * Math.Sqrt(Math.Pow(r.D1 / 2.0, 2) + Math.Pow(r.D2 / 2.0, 2)),
            Trapezoid t => t.Base1 + t.Base2 + t.Side1 + t.Side2,
            _ => throw new ArgumentException("Figura desconocida")
        };
    }

    static double HeronArea(double a, double b, double c)
    {
        var p = (a + b + c) / 2.0;
        return Math.Sqrt(Math.Max(0.0, p * (p - a) * (p - b) * (p - c)));
    }
}
