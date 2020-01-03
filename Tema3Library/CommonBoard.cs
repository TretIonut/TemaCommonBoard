using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3Library
{
    public class CommonBoard
    {
        private IUserService userService;
        private IMessageService messageService;

        public CommonBoard(IUserService userService, IMessageService messageService)
        {
            this.userService = userService;
            this.messageService = messageService;
        }

        //User specifications
        public User AddUser(string firstName, string lastName, DateTime birthDate, string userName, string userEmail, string userPassword)
        {
            return userService.AddUser(firstName, lastName, birthDate, userName, userEmail, userPassword);
        }

        public User GetUserByUserName(string userName)
        {
            return userService.GetUserByUserName(userName);
        }

        public bool CheckIfUserNameWasUsed(string userName)
        {
            return userService.CheckIfUserNameWasUsed(userName);
        }

        public bool CheckIfPasswordIsCorrect(string userName, string insertedPassword)
        {
            return userService.CheckIfPasswordIsCorrect(userName, insertedPassword);
        }

        //messages specification
        public Message AddMessage(string messageContent, DateTime messagePostTime)
        {
            return messageService.AddMessage(messageContent, messagePostTime);
        }

        public List<Message> GetOrderedMessages()
        {
            return messageService.GetOrderedMessages();
        }

    }
}
