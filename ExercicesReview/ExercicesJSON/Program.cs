using System.Text.Json;
using System.Text.Json.Serialization;

const string ROOT_RUTE = "C:\\Users\\rakim\\Documents\\GitHub\\EOI_NET_TESTING\\ExercicesReview\\ExercicesJSON\\JSONs\\";
Directory.SetCurrentDirectory(ROOT_RUTE);

Product product1 = new Product("Keyboard Gaming Amazing", 59.99, 164, true);
Product product2 = new Product("Mouse RGB Ultra Neon", 39.99, 41, true);
Product product3 = new Product("Headset Xokas Edition", 279.99, 0, false);

List<Product> pcomponentesShop = new List<Product>{ product1, product2, product3 };
var options = new JsonSerializerOptions{ WriteIndented = true };
string? json = null;
json = JsonSerializer.Serialize(pcomponentesShop, options);

Console.WriteLine(json??"No Products in PComponentes");
File.WriteAllText("producto.json", json);

class Product
{
    public Product(string name, double price, int stock, bool available)
    {
        Name = name;
        Price = price;
        Stock = stock;
        IsAvailable = available;
    }
    public string Name { get; set; } = "";
    public double Price { get; set; }
    public int Stock { get; set; }
    public bool IsAvailable { get; set; }
}
