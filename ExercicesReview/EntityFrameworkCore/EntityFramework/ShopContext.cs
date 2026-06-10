using EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.EntityFramework
{
    internal class ShopContext : DbContext
    {

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=..\..\..\shop.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics", Description = "Electronic devices and gadgets" },
                new Category { Id = 2, Name = "Books", Description = "All kinds of books" },
                new Category { Id = 3, Name = "Clothing", Description = "Apparel and accessories" }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Description = "High-performance laptop", Price = 999.99m, Stock = 10, CreationDate = DateOnly.FromDateTime(DateTime.Today), CategoryId = 1 },
                new Product { Id = 2, Name = "Novel", Description = "Bestselling novel", Price = 19.99m, Stock = 50, CreationDate = DateOnly.FromDateTime(DateTime.Today), CategoryId = 2 },
                new Product { Id = 3, Name = "T-Shirt", Description = "Cotton t-shirt", Price = 14.99m, Stock = 100, CreationDate = DateOnly.FromDateTime(DateTime.Today), CategoryId = 3 }
                );
        }
        //public ShopContext(DbContextOptions options) : base(options)
        //{
        //}
        //public class ShopDbContextFactory : IDesignTimeDbContextFactory<ShopContext>
        //{
        //    public ShopContext CreateDbContext(string[] args)
        //    {
        //        var optionsBuilder = new DbContextOptionsBuilder<ShopContext>();
        //        optionsBuilder.UseSqlite("Data Source=shop.db");

        //        return new ShopContext(optionsBuilder.Options);
        //    }
        //}
    }
}
