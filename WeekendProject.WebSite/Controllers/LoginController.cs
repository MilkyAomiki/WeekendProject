using Microsoft.AspNetCore.Mvc;
using Weekend.BLL.DTO;
using Weekend.BLL.Interfaces;

namespace Weekend.WebSite.Controllers
{
    public class LogInController : Controller
    {
        private readonly IUser user;

        public LogInController(IUser user)
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

        [HttpGet("/Login")]
        public IActionResult LogIn()
        {
            return View();
        }

        public IActionResult LogOut()
        {
            return Redirect("/");
        }
    }
}
