using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4_Participation_ASP.Models
{
    public class Volunteer : User
    {
        public List<Available> Agenda { get; private set; }
        public List<Review> Reviews { get; private set; }

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
        public Volunteer(int id, string username, string email, string name, string adres, string city, string phonenumber, bool hasDrivingLincense, bool hasCar, DateTime birthDate, string photo, string vog, bool warned, bool blocked)
            : base(id, username, email, name, adres, city, phonenumber, hasDrivingLincense, hasCar, warned)
        {
            BirthDate = birthDate;
            Photo = photo;
            VOG = vog;
            IsBlocked = blocked;
        }

        public void AddReview()
        {
            
        }

        public void AddAvailable()
        {
            
        }
    }

}