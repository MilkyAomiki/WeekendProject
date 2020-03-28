using System;
using System.Collections.Generic;
using System.Text;
using Weekend.BLL.DTO;

namespace Weekend.BLL.Interfaces
{
    /// <summary>
    /// Main functionality for user authtorization
    /// </summary>
    public interface IUser
    {
        public bool Registration(UserLoginFormDTO userLoginForm, UserDTO user);
        public UserDTO GetUser(string login);
        public bool Authtorizatiion(UserLoginFormDTO userLoginForm);

    }
}
