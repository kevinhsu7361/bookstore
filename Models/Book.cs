using System;
using System.Collections.Generic;

namespace bookstore.Models
{
    public partial class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; } = null!;
        public string? Description { get; set; }
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; } = null!;
    }
}
