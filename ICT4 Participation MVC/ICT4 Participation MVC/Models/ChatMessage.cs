using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Participation.Classes.ClassObjects
{
    public class ChatMessage
    {
        public User Sender { get; private set; }
        public string Message { get; private set; }
        public DateTime Time { get; private set; }
        public string TotalString { get { return Time.Date.ToString("d") + " " + Time.Hour + ":" + Time.Minute + " | " + Sender.Name + ": " + Message; } }

        public ChatMessage(User sender, string message, DateTime time)
        {
            Sender = sender;
            Message = message;
            Time = time;
        }
    }
}
