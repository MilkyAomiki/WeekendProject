using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Weekend.BLL.Interfaces;

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
        public IActionResult LogInConfirm()
        {
                
            return View();
        }

        [HttpPost]
        public IActionResult SignUpConfirm()
        {
            return View();
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
