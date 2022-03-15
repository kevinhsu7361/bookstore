using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookstore.Helpers;
using Microsoft.AspNetCore.Mvc;
using bookstore.ViewModels;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Authorization;
using bookstore.Models;
using Omu.ValueInjecter;

namespace bookstore.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        public static Author author = new Author();
        private readonly BookstoreContext db;
        private readonly JwtHelpers helpers;

        public AuthController(JwtHelpers helpers,BookstoreContext db)
        {
            this.db = db ;
            this.helpers = helpers;
        }
        
        [HttpPost("~/signup")]
        public void Register(Author author1)
        {
            string passwordHash = HashPassword(author1.Password);
            author.AuthorId = author1.AuthorId;
            author.AuthorName = author1.AuthorName;
            author.Email = author1.Email;
            author.Password = passwordHash;
            db.Authors.Add(author);
            db.SaveChanges();
        }

        [HttpPost("~/signin")]
        public void Login(LoginViewModel model)
        {
            if (CheckPassword(model))
            {
                string token = helpers.GenerateToken(model.Username);
                author.Token = token;
            }
        }

        private string HashPassword(string password)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            return passwordHash;
        }

        private bool CheckPassword(LoginViewModel model)
        {
            bool verified = BCrypt.Net.BCrypt.Verify(model.Password, author.Password);
            if (author.AuthorName == model.Username && verified)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}