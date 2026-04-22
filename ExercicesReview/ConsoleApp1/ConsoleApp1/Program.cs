var developer = "Desarrollador Desesperado";

Console.WriteLine("Hello, " + developer);
Console.WriteLine($"Hello, {developer}");


Console.WriteLine("Nombre:");
string name = Console.ReadLine() ?? "PorDefecto";

Console.WriteLine("Nombre:" + name);