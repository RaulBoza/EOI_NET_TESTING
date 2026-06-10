using EntityFrameworkCore.Entities;
using EntityFrameworkCore.EntityFramework;
using System.Runtime.InteropServices.Marshalling;

namespace EntityFrameworkCore
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //AddCategory("Toys", "Children's toys and games");
            //AddProduct("Action Figure", "Superhero action figure", 29.99m, 20, 7);
            //ReadAllProducts();
            ReadProductsByCategory("Toys");
        }

        static void AddCategory(string name, string description)
        {
            var db = new ShopContext();
            var category = new Category { Name = name, Description = description };
            db.Categories.Add(category);
            db.SaveChanges();
            Console.WriteLine($"{name} category added successfully.");

        }

        static void AddProduct(string name, string description, decimal price, int stock, int categoryId)
        {
            var db = new ShopContext();
            var product = new Product { Name = name, Description = description, Price = price, Stock = stock, CreationDate = DateOnly.FromDateTime(DateTime.Today), CategoryId = categoryId };
            db.Products.Add(product);
            db.SaveChanges();
            Console.WriteLine($"{name} product added successfully.");
        }

        static void ReadAllProducts()
        {
            new ShopContext().Products
                .ToList()
                .ForEach(p => Console.WriteLine($"{p.Name} | {p.Description} | {p.Price} | {p.Stock}"));
        }

        static void ReadProductsByCategory(int categoryId)
        {
            var category = new ShopContext().Categories.
                FirstOrDefault(c => c.Id == categoryId);

            if (category != null)
            {
                new ShopContext().Products
                    .Where(p => p.CategoryId == categoryId)
                    .ToList()
                    .ForEach(p => Console.WriteLine($"{p.Name} | {p.Description} | {p.Price} | {p.Stock}"));
            }
            else
            {
                Console.WriteLine("Category not found.");
            }
        }
        static void ReadProductsByCategory(string categoryName)
        {
            var category = new ShopContext().Categories.
                FirstOrDefault(c => c.Name == categoryName);

            if (category != null)
            {
                new ShopContext().Products
                    .Where(p => p.Category.Name == categoryName)
                    .ToList()
                    .ForEach(p => Console.WriteLine($"{p.Name} | {p.Description} | {p.Price} | {p.Stock}"));
            }
            else
            {
                Console.WriteLine("Category not found.");
            }
        }
    }
}
