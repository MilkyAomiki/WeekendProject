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

        [HttpPost("/Login/LogInConfirm")]
        public IActionResult LogInConfirm(UserLoginFormDTO user)
        {
            var confirmed = this.user.Authtorizatiion(user);
            if (confirmed)
            {

                return Redirect("/User/" + user.Login);
            }

            return View("/Views/Login/LogIn");
        }

        [HttpGet("/")]
        public void FirstOpen()
        {
            Response.Redirect("/Login");
        }

        [HttpPost]
        public IActionResult SignUpConfirm(string Email, string fName, string lName, DateTime date, string password)
        {
            UserLoginFormDTO userLogin = new UserLoginFormDTO { Login = Email, Password = password };
            UserDTO user = new UserDTO { Login = Email, Birthday = date, FirstName = fName, LastName = lName };


            if (this.user.Registration(userLogin, user))
            {
                return Redirect("/");
            }
            return View("/Views/Login/SignUp");
        }

        [HttpGet("/Login")]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpGet("/SignUp")]
        public IActionResult SignUp()
        {

            return View();
        }

        public IActionResult LogOut()
        {
            return Redirect("/");
        }
    }
}
