using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Participation.Classes.ClassObjects
{
    public class Volunteer : User
    {
        public DateTime BirthDate { get; private set; }
        public string Photo { get; private set; }
        public string VOG { get; private set; }
        public string Address { get; private set; }
        public string City { get; private set; }

        public Volunteer(int id, string username, string email, string name, string address, string city, string phonenumber, bool publicTransport, bool hasDrivingLincense, bool hasCar, DateTime birthDate, string photo, string vog)
            : base(id, username, email, name, phonenumber, publicTransport,  hasDrivingLincense, hasCar)
        {
            VOG = vog;
            Photo = photo;
            BirthDate = birthDate;
            Address = address;
            City = city;
        }
    }
}
