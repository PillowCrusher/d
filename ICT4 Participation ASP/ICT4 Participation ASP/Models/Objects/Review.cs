using System;
using ICT4_Participation_ASP.Models.Accounts;

namespace ICT4_Participation_ASP.Models.Objects
{
    public class Review
    {
        public int HelpRequestId { get; protected set; }
        public Volunteer Volunteer { get; protected set; }
        public string Message { get; protected set; }
        public string Comment { get; protected set; }

        public Review(int helpRequestId, Volunteer volunteer, string message)
        {
            HelpRequestId = helpRequestId;
            Volunteer = volunteer;
            Message = message;
        }

        public Review(int helpRequestId, Volunteer volunteer, string message, string comment)
        {
            HelpRequestId = helpRequestId;
            Volunteer = volunteer;
            Message = message;
            Comment = comment;
        }

        public void AddComment(Volunteer volunteer, string comment)
        {
            if (Volunteer == volunteer)
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
                       && this.Volunteer == other.Volunteer;
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
