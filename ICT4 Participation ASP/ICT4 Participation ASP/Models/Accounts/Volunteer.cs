using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ICT4_Participation_ASP.Models.Objects;

namespace ICT4_Participation_ASP.Models.Accounts
{
    public class Volunteer : User
    {
        public List<Available> Agenda { get; protected set; }
        public List<HelpRequest> HelpRequesten { get; protected set; }
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
            HelpRequesten = new List<HelpRequest>();
        }

        public Volunteer(DataRow dr)
            : this(Convert.ToInt32(dr["ID"]), dr["Username"].ToString(), dr["email"].ToString(), dr["name"].ToString(), dr["adres"].ToString(), dr["city"].ToString(), dr["phonenumber"].ToString(), Convert.ToBoolean(dr["HasDrivinglicence"]), Convert.ToBoolean(dr["HasCar"]), Convert.ToDateTime(dr["DateofBirth"]), dr["photo"].ToString(), dr["VOG"].ToString(), Convert.ToBoolean(dr["IsWarned"]), Convert.ToBoolean(dr["IsBlocked"]))
        {
            Agenda = new List<Available>();
            HelpRequesten = new List<HelpRequest>();
        }

        public void AddHelprequest(List<HelpRequest> helpRequesten)
        {
            HelpRequesten = null;
            HelpRequesten = helpRequesten;
        }

        public void AddSkill(List<Skill> skill)
        {
            Skills = null;
            Skills = skill;
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
            if (obj is Volunteer)
            {
                Volunteer other = ((Volunteer)obj);
                return this.ID == other.ID;
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