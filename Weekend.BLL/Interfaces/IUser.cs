using System;
using System.Collections.Generic;
using System.Text;
using Weekend.BLL.DTO;

namespace Weekend.BLL.Interfaces
{
    public interface IUser
    {
        public bool Registration(UserLoginFormDTO userLoginForm);
        public UserDTO GetUser(string login);
        public bool Authtoriztiion(UserLoginFormDTO userLoginForm);

    }
}
