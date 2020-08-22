using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Weekend.WebSite.Controllers
{
    public class MessagesController : Controller
    {
        [HttpGet("/Messages")]
        public IActionResult Messages()
        {
            return View();
        }
    }
}