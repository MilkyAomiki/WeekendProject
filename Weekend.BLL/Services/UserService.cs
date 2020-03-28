using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Weekend.BLL.DTO;
using Weekend.DAL.Context;
using Weekend.DAL.Models;
using Weekend.BLL.Interfaces;

namespace Weekend.BLL.Services
{
    public class UserService : IUser
    {
        private readonly WeekendContext context;

        public UserService(WeekendContext context)
        {
            this.context = context;
        }
        public bool Authtorizatiion(UserLoginFormDTO userLoginForm)
        {
            bool isExist;
            var user = context.UserLoginForm.Where(p => p.Login == userLoginForm.Login && p.Password == userLoginForm.Password).FirstOrDefault();
            if (user != null)
            {
                isExist = true;
            }
            else
            {
                isExist = false;
            }
            return isExist;
        }

        public UserDTO GetUser(string login)
        {
            var user = context.User.Where(p => p.Login == login).FirstOrDefault();
            return new UserDTO { Login = user.Login, FirstName = user.FirstName, LastName = user.LastName, Birthday = user.Birthday, Sex = user.Sex, Relationship = user.Relationship, Language = user.Language, Avatar = user.Avatar };
        }

        public bool Registration(UserLoginFormDTO userLoginForm, UserDTO user)
        {

            UserLoginForm newUser = new UserLoginForm { Login = userLoginForm.Login, Password = userLoginForm.Password };
            context.UserLoginForm.Add(newUser);
            context.SaveChanges();
            User user1 = new User { Login = user.Login, Birthday = user.Birthday, FirstName = user.FirstName, LastName = user.LastName };
            context.User.Add(user1);
            context.SaveChangesAsync();
            return true;

        }
    }
}
