using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema3Library
{
    public class Message :IComparable<Message>
    {
        public string MessageContent;
        public DateTime MessagePostTime;

        public Message(string messageContent, DateTime messagePostTime)
        {
            MessageContent = messageContent;
            MessagePostTime = messagePostTime;
        }

        public int CompareTo(Message aux)
        {
            return aux.MessagePostTime.Ticks.CompareTo(this.MessagePostTime.Ticks);
        }

    }
}
