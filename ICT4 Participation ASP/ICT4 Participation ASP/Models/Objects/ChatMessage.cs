using System;
using System.Data;
using ICT4_Participation_ASP.Models.Accounts;

namespace ICT4_Participation_ASP.Models.Objects
{
    public class ChatMessage
    {
        public int Id { get; protected set; }
        public String SenderName { get; protected set; }
        public int HelprequestId { get; protected set; }
        public DateTime Time { get; protected set; }
        public string Message { get; protected set; }

        public string TotalString
        {
            get
            {
                return Time.Date.ToString("d") + " " + Time.Hour + ":" + Time.Minute + " | " + SenderName + ": " +
                       Message;
            }
        }

        public ChatMessage(int id, string senderName, int helprequestId, DateTime time, string message)
        {
            Id = id;
            SenderName = senderName;
            HelprequestId = helprequestId;
            Time = time;
            Message = message;
        }

        public ChatMessage(DataRow dr) 
            : this(Convert.ToInt32(dr["ID"]), dr["SenderName"].ToString(), Convert.ToInt32(dr["HelprequestID"]), Convert.ToDateTime(dr["Time"]), dr["Message"].ToString())
        {
            
        }*/
            

        public override bool Equals(object obj)
        {
            if (obj is ChatMessage)
            {
                ChatMessage other = ((ChatMessage)obj);
                return this.SenderName == other.SenderName
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
