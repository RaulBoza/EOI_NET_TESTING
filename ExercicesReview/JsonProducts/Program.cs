/*Crea un programa que muestre el siguiente menú:
1) Mostrar productos
2) Añadir producto
0) Salir

Trabajaremos con un fichero que contendrá la información de varios productos. Un
producto en cada línea con los datos nombre y precio separados por punto y coma. 

-La opción 1 mostrará los productos del fichero (formatea la salida para que los precios salgan alineados
con 2 decimales). 
-La opción 2 te pedirá el nombre de un producto y el precio y lo insertaráal final del archivo.

Debes mostrar el menú hasta que el usuario seleccione salir. Cada una de las opciones
impleméntalas en funciones separadas que llamarás desde el Main.*/

using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;

Directory.SetCurrentDirectory("C:\\Users\\rakim\\Documents\\GitHub\\EOI_NET_TESTING\\ExercicesReview\\JsonProducts\\Products\\");


//List<Product> products = new List<Product>();
//Product product1 = new Product("Apple", 0.99f, new Date(1, 1, 2024));
//products.Add(product1);
//string jsonString = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
//File.WriteAllText("products.json", jsonString);

//MainMenu();

static void MainMenu()
{
    int option = -1;
    while(option != 0)
    {
        Console.WriteLine("""
            ============================
            ||     Products Menu      ||
            ============================
            ||                        ||
            || 1) Show products       ||
            || 2) Add product         ||
            || 0) Exit                ||
            ||                        ||
            ============================
            """);
        Console.Write("Select an option: ");

        switch (Console.ReadLine())
        {
            case "1":
                ShowProducts();
                break;
            case "2":
                AddProduct();
                break;
            case "0":
                option = 0;
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    ;
}
}

static void ShowProducts()
{

}

static List<Product> GetProduct()
{
    return new List<Product>();
}

static void AddProduct()
{

}

static void CloseProgram()
{

}


public class Product
{
    public Product(string name, float price, Date date)
    {
        productName = name;
        productPrice = price;
        addingDate = date;
    }
    [JsonPropertyName("Product Name")]
    public string productName { get; set; }
    [JsonPropertyName("Product Price")]
    public float productPrice  { get; set; }
    [JsonPropertyName("Adding Date")]
    public Date addingDate { get; set; }
}

public class Date
{
    public Date(int day, int month, int year)
    {
        this.day = day;
        this.month = month;
        this.year = year;
    }
    public int day { get; set; }
    public int month { get; set; }
    public int year { get; set; }
}

//[JsonConverter(typeof(CustomTypeJsonConverter))]
//public class CustomType (string attribute) : TypeConverter
//{
//    public static CustomType Parse(string attribute)
//    {
//        return new CustomType(attribute);
//    }
//    public string attribute { get; set; }
//}
//class CustomTypeJsonConverter : JsonConverter<CustomType>
//{
//    public override CustomType Read(
//        ref Utf8JsonReader reader,
//        Type typeToConvert,
//        JsonSerializerOptions options) =>
//        CustomType.Parse(reader.GetString()!);

//    public override void Write(
//        Utf8JsonWriter writer,
//        CustomType customType,
//        JsonSerializerOptions options) =>
//        writer.WriteStringValue(customType.ToString());
//}