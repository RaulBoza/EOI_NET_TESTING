using Library.Entities;
using Library.Services;

namespace Library
{
    internal class Program
    {
        static LibraryServices services = new LibraryServices();
        static async Task Main(string[] args)
        {
            List<Book> books = await services.GetBooksAllBooksAsync();
        }

        static async Task<int> CreateAuthorAsync()
        {
            var author = new Author
            {
                Name = "New Author",
                Country = "Unknown"
            };
            return await services.CreateAuthorAsync(author);
        }

        static async Task<int> CreateBookAuthorAsync(int authorId)
        {
            var book = new Book
            {
                Title = "New Book",
                ISBN = "1234567890",
                PublicationYear = 2024
            };
            
            return await services.CreateBookAuthorAsync(book, new List<int> { authorId });
        }
    }
}
