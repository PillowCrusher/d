using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ICT4_Participation_ASP.Models.Objects;

namespace ICT4_Participation_ASP.Models.Accounts
{
    public class Volunteer : User
    {
        public List<Available> Agenda { get; protected set; }
        public List<Review> Reviews { get; protected set; }
        public List<Skill> Skills { get; protected set; }

        /// <summary>
        /// De verjaardag van de volunteer
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// het file path van de foto van de volunteer
        /// </summary>
        public string Photo { get; set; }

        /// <summary>
        /// het file path van de VOG van de volunteer
        /// </summary>
        public string VOG { get; private set; }

        /// <summary>
        /// een bool of de volunteer is geblokkeerd door de admin of niet
        /// </summary>
        public bool IsBlocked { get; private set; }

        /// <summary>
        /// een instancie van een Volunteer wat de id,username, email, name, address, city, phonenumber
        /// publictransport, hasdrivinglincense, en hasCar overneemt uit User
        /// </summary>
        /// <param name="id"></param>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <param name="adres"></param>
        /// <param name="city"></param>
        /// <param name="phonenumber"></param>
        /// <param name="hasDrivingLincense"></param>
        /// <param name="hasCar"></param>
        /// <param name="birthDate"></param>
        /// <param name="photo"></param>
        /// <param name="vog"></param>
        /// <param name="warned"></param>
        /// <param name="blocked"></param>
        /// <param name="administration"></param>
        public Volunteer(int id, string username, string email, string name, string adres, string city,
            string phonenumber, bool hasDrivingLincense, bool hasCar, DateTime birthDate, string photo, string vog,
            bool warned, bool blocked)
            : base(id, username, email, name, adres, city, phonenumber, hasDrivingLincense, hasCar, warned)
        {
            BirthDate = birthDate;
            Photo = photo;
            VOG = vog;
            IsBlocked = blocked;

            Agenda = new List<Available>();
            Reviews = new List<Review>();
        }

        public Volunteer(string username, string email, string name, string adres, string city, string phonenumber,
            bool hasDrivingLincense, bool hasCar, DateTime birthDate, string photo, string vog)
            : base(username, email, name, adres, city, phonenumber, hasDrivingLincense, hasCar)
        {
            BirthDate = birthDate;
            Photo = photo;
            VOG = vog;

            Agenda = new List<Available>();
            Reviews = new List<Review>();
        }

        public void AddReview(Review review)
        {
            if (review.VolunteerId == ID)
            {
                Reviews.Add(review);
            }
            else
            {
                throw new ArgumentException("Deze review is niet voor deze vrijwilliger bedoeld");
            }
        }

        public void AddSkill(Skill skill)
        {
            if (Skills.Contains(skill) == false)
            {
                Skills.Add(skill);
            }
            else
            {
                throw new ArgumentException("Deze vrijwilliger heeft deze vaardigheid al");
            }
        }

        public void AddAvailable(Available available)
        {
            if (Agenda.Contains(available) == false)
            {
                Agenda.Add(available);
            }
            else
            {
                throw new ArgumentException("Beschibaarheid bestaat al");
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is HelpRequest)
            {
                HelpRequest other = ((HelpRequest) obj);
                return this.ID == other.ID;
            }
            else
            {
                return false;
            }
        }
    }

}