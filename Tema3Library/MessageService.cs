using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3Library
{
    public class MessageService : IMessageService
    {
        public List<Message> messages;

        public MessageService()
        {
            this.messages = new List<Message>();
        }

        public Message AddMessage(string messageContent, DateTime messagePostTime)
        {
            Message message = new Message(messageContent, messagePostTime);
            this.messages.Add(message);
            return message;
        }

        public List<Message> GetMessage()
        {
            return this.messages;
        }

        public List<Message> GetOrderedMessages()
        {
            this.messages.Sort();
            return this.messages;
        }
    }
}
