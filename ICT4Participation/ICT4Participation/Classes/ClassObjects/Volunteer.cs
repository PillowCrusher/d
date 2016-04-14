using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Participation.Classes.ClassObjects
{
    public class Volunteer : User
    {
        public DateTime BirthDate { get; set; }
        public string Photo { get; set; }
        public string VOG { get; set; }

        public Volunteer(Account account, string name, string address, string city, string phonenumber, bool publicTransport, bool hasDrivingLincense, bool hasCar, DateTime birthDate, string photo, string vog)
            : base(account, name, address, city, phonenumber, publicTransport,  hasDrivingLincense, hasCar)
        {
            if (birthDate == null)
            {
                throw new ArgumentNullException("birhtDate","Birthdate is empty");
            }
            if (photo == null)
            {
                throw new ArgumentNullException("photo", "photo is empty");
            }
            if (vog == null)
            {
                throw new ArgumentNullException("vog", "vog is empty");
            }
        }
    }
}
