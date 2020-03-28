using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Weekend.BLL.Interfaces;
using Weekend.BLL.DTO;

namespace Weekend.WebSite.Controllers
{
    public class LoginController: Controller
    {
        private readonly IUser user;

        public LoginController(IUser user)
        {
            this.user = user;
        }

        [HttpPost]
        public IActionResult LogInConfirm(UserLoginFormDTO user)
        {
            var confirmed = this.user.Authtorizatiion(user);
            int statusCode = confirmed ? 200 : 204;
            return StatusCode(statusCode);
        }

        [HttpPost]
        public void SignUpConfirm(string Email, string fName, string lName, DateTime date, string password)
        {
            UserLoginFormDTO userLogin = new UserLoginFormDTO { Login = Email, Password = password };
            UserDTO user = new UserDTO { Login = Email, Birthday = date, FirstName = fName, LastName = lName };
            this.user.Registration(userLogin, user);
            Response.Redirect("/");
        }

        [HttpGet("/")]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpGet("/SignUp")]
        public IActionResult SignUp()
        {

            return View();
        }
    }
}
