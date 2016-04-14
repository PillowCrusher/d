using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Participation.Classes.ClassObjects
{
    public class ChatMessage
    {
        public string Message { get; set; }
        public DateTime Time { get; set; }

        public ChatMessage(User sender, string message, DateTime time)
        {
            if (sender == null)
            {
                throw new ArgumentNullException("sender", "sender is empty");
            }
            if (message == null)
            {
                throw new ArgumentNullException("message", "message is empty");
            }
            if (time == null)
            {
                throw new ArgumentNullException("time", "time is empty");
            }
            this.Message = message;
            this.Time = time;
        }

        public ChatMessage(User sender, string message, DateTime time, HelpRequest helprequest)
        {
            if (sender == null)
            {
                throw new ArgumentNullException("sender", "sender is empty");
            }
            if (message == null)
            {
                throw new ArgumentNullException("message", "message is empty");
            }
            if (time == null)
            {
                throw new ArgumentNullException("time", "time is empty");
            }
            if (helprequest == null)
            {
                throw new ArgumentNullException("helprequest", "helprequest is empty");
            }
            this.Message = message;
            this.Time = time;
        }
    }
}
