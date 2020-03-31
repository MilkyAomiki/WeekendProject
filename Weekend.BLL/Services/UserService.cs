using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Weekend.BLL.DTO;
using Weekend.BLL.Interfaces;
using Weekend.DAL.Context;
using Weekend.DAL.Models;

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
            List<User> users = context.User.ToList();
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
            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            {
                if (e.InnerException.GetType() == typeof(PostgresException))
                {
                    var ep = (PostgresException)e.InnerException;
                    if (ep.Code == "23505")
                    {
                        throw new ValidationException("Login is already taken");
                    }
                }
                ;
            }
         
            User user1 = new User { Login = user.Login, Birthday = user.Birthday, FirstName = user.FirstName, LastName = user.LastName };
            context.User.Add(user1);
            context.SaveChanges();
            return true;

        }
    }
}
