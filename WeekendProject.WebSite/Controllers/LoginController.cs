using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.ComponentModel.DataAnnotations;
using Weekend.BLL.DTO;
using Weekend.BLL.Interfaces;

namespace Weekend.WebSite.Controllers
{
    public class LoginController : Controller
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
            else
            {
                ModelState.AddModelError("", "User with given login and password was not found");
                return View("/Views/Login/LogIn.cshtml", user);
            }

            
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
                return this.RedirectToAction("SignUp", user);
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
                return View("~/Views/Login/SignUp.cshtml", user);
            }

            return RedirectToAction("SignUp");
        }

        [HttpGet("/Login")]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpGet("/SignUp")]
        public IActionResult SignUp(UserDTO user)
        {            
            return View(user);


        }

        public IActionResult LogOut()
        {
            return Redirect("/");
        }
    }
}
