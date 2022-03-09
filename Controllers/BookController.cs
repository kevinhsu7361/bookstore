using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bookstore.Models;
using bookstore.ViewModels;
using Omu.ValueInjecter;

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
        public IEnumerable<BookRead> GetBooks()
        {
            var books = db.Books.ToList();
            List<BookRead> booklist = new List<BookRead>();
            foreach (var book in books)
            {
                if (book == null)
                {
                    //yield return NotFound();
                }
                db.Entry(book).Reference(b => b.Author).Load(); // 一對一
                var result = (new BookRead()).InjectFrom(book) as BookRead;
                result.AuthorName = book.Author.AuthorName;
                yield return result;
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            var book = db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            db.Entry(book).Reference(b => b.Author).Load(); // 一對一
            var result = (new BookRead()).InjectFrom(book) as BookRead;
            result.AuthorName = book.Author.AuthorName;
            return Ok(result);
        }

        [HttpPost("")]
        public ActionResult<Book> PostBook(Book model)
        {
            //var item = Mapper.Map<Book>(model);
            db.Books.Add(model);
            db.SaveChanges();
            return Created(nameof(GetBookById), new { id = model.BookId });
        }

        [HttpPut("{id}")]
        public IActionResult PutBook(int id, Book model)
        {
            var item = db.Books.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            item.BookId = model.BookId;
            item.BookName = model.BookName;
            item.Description = model.Description;
            db.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Book> DeleteBookById(int id)
        {
            var book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return Ok();
        }
    }
}