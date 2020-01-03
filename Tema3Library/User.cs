using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3Library
{
    public class User : Person
    {
        public string UserName { get; private set; }
        public string UserEmail { get; private set; }
        public string UserPassword { get; set; }

        public User(string firstName, string lastName, DateTime birthDate, string userName, string userEmail, string userPassword)
           : base(firstName, lastName, birthDate)
        {
            UserName = userName;
            UserEmail = userEmail;
            UserPassword = userPassword;
        }

    }
}
