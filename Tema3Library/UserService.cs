using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3Library
{
    public class UserService : IUserService
    {
        private List<User> users;

        public UserService()
        {
            this.users = new List<User>();
        }

        public User AddUser(string firstName, string lastName, DateTime birthDate, string userName, string userEmail, string userPassword)
        {
            User user = new User(firstName, lastName, birthDate, userName, userEmail, userPassword);
            this.users.Add(user);
            return user;
        }

        public User GetUserByUserName(string userName)
        {
            foreach (User user in this.users)
            {
                if (user.UserName == userName)
                {
                    return user;
                }
            }
            return null;
        }

        public bool CheckIfUserNameWasUsed(string userName)
        {
            User userCheck = GetUserByUserName(userName);
            if (userCheck != null)
            {
                foreach (User user in this.users)
                {
                    if (user.UserName == userCheck.UserName)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool CheckIfPasswordIsCorrect(string userName, string insertedPassword)
        {
            User userCheck = GetUserByUserName(userName);
            if (userCheck != null)
            {
                if (userCheck.UserPassword == insertedPassword)
                {
                    return false;
                }
            }
            return true;
        }

    }

}
