using System;
using System.Collections.Generic;

namespace Tema3Library
{
    public interface IUserService
    {
        User AddUser(string firstName, string lastName, DateTime birthDate, string userName, string userEmail, string userPassword);
        bool CheckIfPasswordIsCorrect(string userName, string insertedPassword);
        bool CheckIfUserNameWasUsed(string userName);
        User GetUserByUserName(string userName);
    }
}