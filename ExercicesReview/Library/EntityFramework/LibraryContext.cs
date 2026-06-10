using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Library.Entities;

namespace Library.EntityFramework
{
    public class LibraryContext : DbContext
    {
        
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=library.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "J.K. Rowling", Country = "United Kingdom" },
                new Author { Id = 2, Name = "George R.R. Martin", Country = "United States" },
                new Author { Id = 3, Name = "J.R.R. Tolkien", Country = "United Kingdom" },
                new Author { Id = 4, Name = "Agatha Christie", Country = "United Kingdom" },
                new Author { Id = 5, Name = "Stephen King", Country = "United States" },
                new Author { Id = 6, Name = "Isaac Asimov", Country = "United States" },
                new Author { Id = 7, Name = "Arthur C. Clarke", Country = "United Kingdom" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Harry Potter and the Philosopher's Stone", PublicationYear = 1997 },
                new Book { Id = 2, Title = "Harry Potter and the Chamber of Secrets", PublicationYear = 1998 },
                new Book { Id = 3, Title = "Harry Potter and the Prisoner of Azkaban", PublicationYear = 1999 },
                new Book { Id = 4, Title = "A Game of Thrones", PublicationYear = 1996 },
                new Book { Id = 5, Title = "A Clash of Kings", PublicationYear = 1998 },
                new Book { Id = 6, Title = "The Lord of the Rings", PublicationYear = 1954 },
                new Book { Id = 7, Title = "The Hobbit", PublicationYear = 1937 },
                new Book { Id = 8, Title = "Murder on the Orient Express", PublicationYear = 1934 },
                new Book { Id = 9, Title = "The Shining", PublicationYear = 1977 },
                new Book { Id = 10, Title = "Foundation", PublicationYear = 1951 },
                new Book { Id = 11, Title = "2001: A Space Odyssey", PublicationYear = 1968 }
            );

            modelBuilder.Entity<Author>()
                .HasMany(b => b.Books)
                .WithMany(a => a.Authors)
                .UsingEntity(j =>
                {
                    j.ToTable("AuthorsBooks");
                    j.HasData(
                        new { AuthorsId = 1, BooksId = 1 },
                        new { AuthorsId = 1, BooksId = 2 },
                        new { AuthorsId = 1, BooksId = 3 },
                        new { AuthorsId = 2, BooksId = 4 },
                        new { AuthorsId = 2, BooksId = 5 },
                        new { AuthorsId = 3, BooksId = 6 },
                        new { AuthorsId = 3, BooksId = 7 },
                        new { AuthorsId = 4, BooksId = 8 },
                        new { AuthorsId = 5, BooksId = 9 },
                        new { AuthorsId = 6, BooksId = 10 },
                        new { AuthorsId = 7, BooksId = 11 }
                        );
                });
        }
    }
}
