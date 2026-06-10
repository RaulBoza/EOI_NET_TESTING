using System;
using System.Collections.Generic;
using System.Text;
using Library.Entities;
using Library.EntityFramework;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{

    public class LibraryServices
    {
        private readonly LibraryContext _context = new LibraryContext();
        
        public async Task<int> CreateBookAuthorAsync(Book book, List<int> AuthorsIds)
        {
            book.Authors = await _context.Authors.Where(a => AuthorsIds.Contains(a.Id)).ToListAsync();
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book.Id;
        }

        public async Task<int> CreateAuthorAsync(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author.Id;
        }

        public async Task<List<Book>> GetBooksAllBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }
    }
}
