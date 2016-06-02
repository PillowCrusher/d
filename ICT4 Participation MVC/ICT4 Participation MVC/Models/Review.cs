using System;

namespace ICT4_Participation_MVC.Models
{
    public class Review
    {
        public int HelpRequestId { get; private set; }
        public int VolunteerId { get; private set; }
        public string Message { get; private set; }
        public string Comment { get; private set; }

        public Review(int helpRequestId, int volunteerId, string message)
        {
            HelpRequestId = helpRequestId;
            VolunteerId = volunteerId;
            Message = message;
        }

        public void AddComment(int volunteerId, string comment)
        {
            if (VolunteerId == volunteerId)
            {
                Comment = comment;
            }
            else
            {
                throw new ArgumentException("Je kant niet op deze review reageren omdat deze niet over jou gaat");
            }
        }

        public override string ToString()
        {
            return "Helprequest: " + HelpRequestId;
        }
    }
}
