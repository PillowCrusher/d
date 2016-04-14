using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Participation.Classes.ClassObjects
{
    public class Needy : User
    {
        public string RFID { get; set; }

        public Needy(Account account, string name, string address, string city, string phonenumber, bool publicTransport, bool hasDrivingLincense, bool hasCar, string rfid)
            : base(account, name, address, city, phonenumber, publicTransport, hasDrivingLincense, hasCar)
        {
            
        }

        public void AddHelpRequest(string titel, string description, string location, DateTime travelTime, DateTime startDate, DateTime endDate, bool urgent, bool requestintroduction)
        {

        }

        public void DeleteHelpRequest(HelpRequest helprequest)
        {

        }
    }
}
