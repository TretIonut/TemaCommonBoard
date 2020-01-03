using System;
using System.Collections.Generic;

namespace Tema3Library
{
    public interface IMessageService
    {
        Message AddMessage(string messageContent, DateTime messagePostTime);
        List<Message> GetMessage();
        List<Message> GetOrderedMessages();
    }
}