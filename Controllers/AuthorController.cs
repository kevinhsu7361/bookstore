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
    public class AuthorController : ControllerBase
    {
        public AuthorController()
        {
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<Author>> GetAuthors()
        {
            return new List<Author> { };
        }

        [HttpGet("{id}")]
        public ActionResult<Author> GetAuthorById(int id)
        {
            return null;
        }

        [HttpPost("")]
        public ActionResult<Author> PostAuthor(Author model)
        {
            return null;
        }

        [HttpPut("{id}")]
        public IActionResult PutAuthor(int id, Author model)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Author> DeleteAuthorById(int id)
        {
            return null;
        }
    }
}