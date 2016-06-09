using System;

namespace ICT4_Participation_ASP.Models.Objects
{
    public class Review
    {
        public int HelpRequestId { get; protected set; }
        public int VolunteerId { get; protected set; }
        public string Message { get; protected set; }
        public string Comment { get; protected set; }

        public Review(int helpRequestId, int volunteerId, string message)
        {
            HelpRequestId = helpRequestId;
            VolunteerId = volunteerId;
            Message = message;
        }

        public Review(int helpRequestId, int volunteerId, string message, string comment)
        {
            HelpRequestId = helpRequestId;
            VolunteerId = volunteerId;
            Message = message;
            Comment = comment;
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

        public override bool Equals(object obj)
        {
            if (obj is Review)
            {
                Review other = ((Review) obj);
                return this.HelpRequestId == other.HelpRequestId
                       && this.VolunteerId == other.VolunteerId;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return "Helprequest: " + HelpRequestId;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
