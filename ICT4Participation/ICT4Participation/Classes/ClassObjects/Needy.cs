using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Participation.Classes.ClassObjects
{
    public class Needy : User
    {
        public bool PublicTransport { get; set; }
        public string RFID { get; set; }

        public Needy(string name, string address, string city, string phonenumber, bool hasDrivingLincense, bool hasCar, bool publicTransport, string rfid)
            : base(name, address, city, phonenumber, hasDrivingLincense, hasCar)
        {

        }
    }
}
