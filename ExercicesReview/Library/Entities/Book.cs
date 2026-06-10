using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public int PublicationYear { get; set; } = 0;

        public ICollection<Author> Authors { get; set; } = new List<Author>();

    }
}
