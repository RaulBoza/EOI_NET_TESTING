using System;
using System.Collections.Generic;
using System.Text;

namespace SalesAnalysis.Classes
{
    internal class Sale
    {
        public string Product { get; set; }
        public string Category { get; set; }
        public double Price { get; set; } = 0;
        public int Quantity { get; set; } = 0;
        public DateTime Date { get; set; } = DateTime.Now;

        public Sale(string product, string category, double price, int quantity, DateTime date)
        {
            Product = product;
            Category = category;
            Price = price;
            Quantity = quantity;
            Date = date;
        }

        public override string ToString()
        {
            return $"Product: {Product}, Category: {Category}, Price: ${Price:F2}, Quantity: {Quantity}, Date: {Date.ToShortDateString()}";
        }
    }
}
