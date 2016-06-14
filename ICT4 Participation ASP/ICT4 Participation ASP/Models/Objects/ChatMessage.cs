using System;
using ICT4_Participation_ASP.Models.Accounts;

namespace ICT4_Participation_ASP.Models.Objects
{
    public class ChatMessage
    {
        public User Sender { get; protected set; }
        public string Message { get; protected set; }
        public DateTime Time { get; protected set; }
        public string TotalString { get { return Time.Date.ToString("d") + " " + Time.Hour + ":" + Time.Minute + " | " + Sender.Name + ": " + Message; } }

        public ChatMessage(User sender, string message, DateTime time)
        {
            Sender = sender;
            Message = message;
            Time = time;
        }

        public override bool Equals(object obj)
        {
            if (obj is ChatMessage)
            {
                ChatMessage other = ((ChatMessage)obj);
                return this.Sender == other.Sender
                    && this.Message == other.Message
                    && this.Time == other.Time;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
