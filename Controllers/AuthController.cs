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
        private readonly JwtHelpers helpers;

        public AuthController(JwtHelpers helpers,BookstoreContext db)
        {
            this.helpers = helpers;
        }
        
        [HttpPost("~/signup")]
        public async Task<ActionResult<LoginViewModel>> Register(LoginViewModel model)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);
            return Ok();
        }

        [HttpPost("~/signin")]
        public ActionResult<LoginViewModel> Login(LoginViewModel model)
        {
            
            if (CheckPassword(model.Username, model.Password))
            {
                return new LoginViewModel()
                {
                    Token = helpers.GenerateToken(model.Username)
                };
            }
            else
            {
                return BadRequest();
            }
        }

        private bool CheckPassword(string username, string password)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            bool verified = BCrypt.Net.BCrypt.Verify(password, passwordHash);

            if (username == "Will" && verified)
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