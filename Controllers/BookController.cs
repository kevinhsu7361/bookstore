using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bookstore.Models;

namespace bookstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookstoreContext db;
        public BookController(BookstoreContext db)
        {
            this.db = db;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return db.Books.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            return null;
        }

        [HttpPost("")]
        public ActionResult<Book> PostBook(Book model)
        {
            return null;
        }

        [HttpPut("{id}")]
        public IActionResult PutBook(int id, Book model)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Book> DeleteBookById(int id)
        {
            return null;
        }
    }
}