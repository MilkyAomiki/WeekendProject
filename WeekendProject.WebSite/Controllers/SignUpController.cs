using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Weekend.BLL.DTO;
using Weekend.BLL.Interfaces;

namespace Weekend.WebSite.Controllers
{
    public class SignUpController : Controller
    {
        private readonly IUser user;

        public SignUpController(IUser user)
        {
            this.user = user;
        }

        [HttpGet("/SignUp")]
        public IActionResult SignUp(UserDTO user)
        {
            return View(user);
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
    }
}