using System;
using ICT4_Participation_ASP.Models.Accounts;

namespace ICT4_Participation_ASP.Models.Objects
{
    public class Review
    {
        public Volunteer Volunteer { get; protected set; }
        public string Message { get; protected set; }
        public string Comment { get; protected set; }

        public Review(Volunteer volunteer, string message)
        {
            Volunteer = volunteer;
            Message = message;
        }

        public Review(Volunteer volunteer, string message, string comment)
        {
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
                return  this.Volunteer == other.Volunteer &&
                    this.Message == other.Message;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return "Vrijwilliger : " + Volunteer.Name+" beoordeling: "+Message;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
