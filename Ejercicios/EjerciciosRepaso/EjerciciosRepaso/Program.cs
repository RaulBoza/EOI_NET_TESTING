const string ROOT_RUTE = "C:\\Users\\rakim\\Documents\\GitHub\\EOI_NET_TESTING\\Ejercicios\\EjerciciosRepaso\\EjerciciosRepaso\\Files";
Directory.SetCurrentDirectory(ROOT_RUTE);

//WriteAndReadFiles();
static void WriteAndReadFiles()
{
    File.WriteAllText("hello.txt", "Hola mundo");

    string content = File.ReadAllText("hello.txt");
    Console.WriteLine(content);

    string[] lines = { "Línea 1", "Línea 2", "Línea 3" };
    File.WriteAllLines("lines.txt", lines);

    string[] readedLines = File.ReadAllLines("lines.txt");
    foreach (string auxLines in readedLines)
    {
        Console.WriteLine(auxLines);
    }

    File.AppendAllText("hello.txt", "\nEsta linea se añade al final.");
    File.AppendAllLines("lines.txt", new[] { "Penultima Linea", "Ultima Linea" });
}

//CheckExist();
static void CheckExist()
{
    string rute = "hello.txt";

    if (File.Exists(rute))
    {
        string content = File.ReadAllText(rute);
        Console.WriteLine($"El archivo {rute} existe.");
        Console.WriteLine(content);
    }
    else
    {
        Console.WriteLine($"El archivo {rute} no existe.");
    }
}

//Rutes();
static void Rutes()
{
    string rute = "hello.txt";

    string fullRute = Path.GetFullPath(rute);
    Console.WriteLine(fullRute);

    string folder = ROOT_RUTE;
    string file = "ruteToCombine.txt";
    string completeRute = Path.Combine(folder, file);
    Console.WriteLine(completeRute);

    string temp = Path.GetTempFileName();
    Console.WriteLine(temp);
}

//ManageDirectories();
static void ManageDirectories()
{
    string folder = ".";

    if (!Directory.Exists(folder))
    {
        Directory.CreateDirectory(folder);
        Console.WriteLine($"Folder \"{folder}\" created.");
    }
    else
    {
        Console.WriteLine($"Opening {folder}");
    }

    //List files in folder
    string[] filesNames = Directory.GetFiles(folder);
    string[] filestxt = Directory.GetFiles(folder, "*.txt");
    string[] allFiles = Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories);
    foreach (string file in allFiles)
    {
        Console.WriteLine(file);
    }

    //List folders in folder
    string[] subfolders = Directory.GetDirectories(folder);
    foreach (string auxfolder in subfolders)
    {
        Console.WriteLine(auxfolder);
    }

    string currentDirectory = Directory.GetCurrentDirectory();
    Console.WriteLine(currentDirectory);
}

//Streams();
static void Streams()
{
    using StreamReader reader1 = new StreamReader("hello.txt");
    string? line;
    int numLine = 1;

    while ((line = reader1.ReadLine()) != null)
    {
        Console.WriteLine($"{numLine}:{line}");
        numLine++;
    }

    using StreamWriter writter2 = new StreamWriter("lines.txt");

    for (int i = 0; i < 3; i++)
    {
        writter2.WriteLine($"Line {i + 1}");
    }
    writter2.WriteLine($"Fecha {DateTime.Now}");
    writter2.Close();

    using StreamReader reader2 = new StreamReader("lines.txt");
    numLine = 1;
    while ((line = reader2.ReadLine()) != null)
    {
        Console.WriteLine($"{numLine}:{line}");
        numLine++;
    }
    
    
}