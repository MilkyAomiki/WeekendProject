using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Weekend.BLL.Interfaces;
using Weekend.BLL.DTO;
using System.ComponentModel.DataAnnotations;
using Weekend.WebSite.Models;

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

            return View("/Login");
        }

        [HttpGet("/")]
        public void FirstOpen()
        {
            Response.Redirect("/Login");
        }

        [HttpPost]
        public IActionResult SignUpConfirm(UserLoginFormDTO userLoginForm, UserDTO user)
        { 
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("SignUp", new SignupForm {UserLoginForm = userLoginForm, User = user});
            }

            try
            {
                if (this.user.Registration(userLoginForm, user))
                {
                    return Redirect("/");
                }
            }
            catch (ValidationException e)
            {
                ModelState.AddModelError("", e.Message);
                return this.RedirectToAction("SignUp", new SignupForm { UserLoginForm = userLoginForm, User = user });
            }

            return this.RedirectToAction("SignUp");
        }

        [HttpGet("/Login")]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpGet("/SignUp")]
        public IActionResult SignUp(SignupForm form = null)
        {
            if (form == null)
            {
                return View();

            }
            else
            {
                return View(form);
            }
            
        }

        public IActionResult LogOut()
        {
            return Redirect("/");
        }
    }
}
