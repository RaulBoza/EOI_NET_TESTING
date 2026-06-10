using SalesAnalysis.Classes;

namespace SalesAnalysis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Exercise2();
        }

        static public void Exercise1()
        {
            List<Sale> sales = new List<Sale>()
            {
                new Sale("Laptop", "Electronics", 999.99, 1, new DateTime(2024, 1, 15)),
                new Sale("Smartphone", "Electronics", 499.99, 2, new DateTime(2024, 1, 20)),
                new Sale("Headphones", "Electronics", 199.99, 3, new DateTime(2024, 1, 25)),
                new Sale("Book", "Books", 19.99, 5, new DateTime(2024, 1, 30)),
                new Sale("Desk Chair", "Furniture", 149.99, 2, new DateTime(2024, 2, 5)),
                new Sale("Coffee Maker", "Appliances", 89.99, 1, new DateTime(2024, 2, 10)),
                new Sale("Blender", "Appliances", 59.99, 1, new DateTime(2024, 2, 15)),
                new Sale("Sofa", "Furniture", 899.99, 1, new DateTime(2025, 2, 20)),
                new Sale("Table Lamp", "Furniture", 39.99, 3, new DateTime(2024, 2, 25)),
                new Sale("E-book Reader", "Electronics", 129.99, 2, new DateTime(2024, 3, 1)),
                new Sale("Gaming Console", "Electronics", 399.99, 1, new DateTime(2024, 3, 5)),
                new Sale("Office Desk", "Furniture", 299.99, 1, new DateTime(2025, 3, 10)),
                new Sale("Air Fryer", "Appliances", 99.99, 1, new DateTime(2025, 3, 15)),
            };
            //add some sales to the list


            //5 most expensive sales
            var mostexpensivesales = sales.OrderByDescending(p => p.Price * p.Quantity).Take(5);

            Console.WriteLine("5 Most Expensive Sales:");
            foreach (var sale in mostexpensivesales)
            {
                Console.WriteLine($"- {sale.Product}: ${sale.Price * sale.Quantity:F2}");
            }
            Console.WriteLine("");


            //total by category
            var totalbycategory = sales.GroupBy(p => p.Category);

            Console.WriteLine("Total By Category:");
            foreach (var category in totalbycategory)
            {
                Console.WriteLine($"- {category.Key}: ${category.Sum(s => s.Price * s.Quantity):F2}");
            }
            Console.WriteLine("");


            //most sold product
            var mostsoldproduct = sales.OrderByDescending(p => p.Quantity).First();
            Console.WriteLine("¡¡Most Sold Product!!");
            Console.WriteLine(mostsoldproduct.ToString());
            Console.WriteLine("");


            //sales by month

            var salesbymonth = sales.GroupBy(p => p.Date.Month);
            Console.WriteLine("Sales By Month:");
            foreach (var month in salesbymonth)
            {
                Console.WriteLine($"- {month.Key}: ${month.Sum(s => s.Price * s.Quantity):F2}");
            }

            Console.WriteLine("Sales By Month:");
            sales.
                GroupBy(p => new { p.Date.Year, p.Date.Month })
                .OrderByDescending(g => g.Key.Year)
                .ThenByDescending(g => g.Key.Month)
                .ToList()
                .ForEach(m => Console.WriteLine($"- {m.Key}: ${m.Sum(s => s.Price * s.Quantity):F2}"));
        }
        static public void Exercise2()
        {
            //big text
            string text = "This is a large text string for testing purposes.";
            string text2 = "Historically, the world of data and the world of objects" +
                  " have not been well integrated. Programmers work in C# or Visual Basic" +
                  " and also in SQL or XQuery. On the one side are concepts such as classes," +
                  " objects, fields, inheritance, and .NET Framework APIs. On the other side" +
                  " are tables, columns, rows, nodes, and separate languages for dealing with" +
                  " them. Data types often require translation between the two worlds; there are" +
                  " different standard functions. Because the object world has no notion of query, a" +
                  " query can only be represented as a string without compile-time type checking or" +
                  " IntelliSense support in the IDE. Transferring data from SQL tables or XML trees to" +
                  " objects in memory is often tedious and error-prone.";

            UtilidadesTextos.ContarPalabras(text2).ToList().ForEach(p => Console.WriteLine($"- {p.Key}: {p.Value}"));
            
            Console.WriteLine(UtilidadesTextos.PalabraMasFrecuente(text2) + "is used " + UtilidadesTextos.ContarPalabras(text2).First(p => p.Key == UtilidadesTextos.PalabraMasFrecuente(text2)).Value + " times.");

            UtilidadesTextos.NumeroLetras(text2, 5).ForEach(p => Console.WriteLine($"- {p}"));

            Console.WriteLine(UtilidadesTextos.NumeroVocales(text) + " vocales.");
        }
    }
}