using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weekend.BLL.DTO;

namespace Weekend.WebSite.Models
{
    public class SignupForm
    {
        public UserLoginFormDTO UserLoginForm { get; set; }
        public UserDTO User { get; set; }
    }
}
