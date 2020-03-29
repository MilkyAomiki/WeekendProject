using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Weekend.BLL.DTO;
using Weekend.BLL.Interfaces;

namespace Weekend.WebSite.Controllers
{
    public class ProfileController: Controller
    {
        private readonly IUser user;

        public ProfileController(IUser user)
        {
            this.user = user;
        }

        [Route("/User/{login}")]
        [HttpGet]
        public IActionResult Profile(string login)
        {
            UserDTO userDTO;
            userDTO = user.GetUser(login);
            return View("Views/Home/Index.cshtml", userDTO);
        }
    }
}
