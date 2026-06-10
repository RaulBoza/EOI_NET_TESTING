using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Library.Services;
using Library.Entities;

namespace Library.web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly LibraryServices _service = new LibraryServices();
        public List<Book> Books { get; set; } = new List<Book>();
        public void OnGet()
        {
            
        }
    }
}
