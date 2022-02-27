using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.ViewModels
{
    public class BookRead
    {
        public int BookId { get; set; }
        public string BookName { get; set; } = null!;
        public string? Description { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
    }
}