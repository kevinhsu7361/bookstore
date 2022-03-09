using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookstore.Helpers;
using Microsoft.AspNetCore.Mvc;
using bookstore.ViewModels;

namespace bookstore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtHelpers helpers;

        public AuthController(JwtHelpers helpers)
        {
            this.helpers = helpers;
        }

        [HttpPost("login")]
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
            if (username == "Will")
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