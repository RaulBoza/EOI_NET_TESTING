using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;

const string ROOT_RUTE = "C:\\Users\\rakim\\Documents\\GitHub\\EOI_NET_TESTING\\ExercicesReview\\ExercicesJSON\\JSONs\\";
Directory.SetCurrentDirectory(ROOT_RUTE);

Product product1 = new Product("Keyboard Gaming Amazing", 59.99, 164, true);
Product product2 = new Product("Mouse RGB Ultra Neon", 39.99, 41, true);
Product product3 = new Product("Headset Xokas Edition", 279.99, 0, false);

List<Product> pcomponentesShop = new List<Product>{ product1, product2, product3 };
var options = new JsonSerializerOptions{ WriteIndented = true };
string? json = null;
json = JsonSerializer.Serialize(pcomponentesShop, options);

//Console.WriteLine(json??"No Products in PComponentes");
File.WriteAllText("products.json", json);


string jsonProducts = File.ReadAllText("products.json");

List<Product>? productList = JsonSerializer.Deserialize<List<Product>>(jsonProducts);

if (productList != null)
{
    foreach (Product auxproduct in productList)
    {
        Console.WriteLine($"""
            ====================================
            Product Name: {auxproduct.Name}
                    -----------------
            - Price:        {auxproduct.Price} EUR
            - Stock:        {auxproduct.Stock} units
            - Availability: {(auxproduct.IsAvailable ? "Available":"No Available")}

            ====================================
            """);
    }
}

//var otherOptions = new JsonSerializerOptions
//{
//    WriteIndented = true,                                    // Indentación
//    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,      // camelCase en JSON
//    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,  // Ignorar nulls
//    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping  // Acentos sin escapar
//};

FileInfo info = new FileInfo("products.json");

if (info.Exists)
{
    Console.WriteLine($"File Name: {info.Name}");
    Console.WriteLine($"File Size: {info.Length} bytes");
    Console.WriteLine($"Creation Time: {info.CreationTime}");
    Console.WriteLine($"Last Access Time: {info.LastAccessTime}");
    Console.WriteLine($"Last Write Time: {info.LastWriteTime}");
}
else
{
    Console.WriteLine("The file does not exist.");
}

class Product
{
    public Product()
    {
        Name = "name";
        Price = 0;
        Stock = 0;
        IsAvailable = false;
    }
    public Product(string name, double price, int stock, bool available)
    {
        Name = name;
        Price = price;
        Stock = stock;
        IsAvailable = available;
    }

    [JsonPropertyName("Name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("Price")]
    public double Price { get; set; }

    [JsonPropertyName("Stock")]
    public int Stock { get; set; }

    [JsonPropertyName("IsAvailable")]
    public bool IsAvailable { get; set; }
}
