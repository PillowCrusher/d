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

        public Volunteer(string name, string address, string city, string phonenumber, bool hasDrivingLincense, bool hasCar, DateTime birthDate, string photo, string vog)
            : base(name, address, city, phonenumber, hasDrivingLincense, hasCar)
        {
            VOG = vog;
            Photo = photo;
            BirthDate = birthDate;
        }
    }
}
