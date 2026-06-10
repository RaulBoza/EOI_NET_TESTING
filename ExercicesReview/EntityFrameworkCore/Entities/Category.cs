using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.Entities
{
    internal class Category
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Product> Products { get; set; } = new List<Product>();


    }
}
