using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Participation.Classes.ClassObjects
{
    public class Admin : Account
    {
        public string RFID { get; set; }

        public Admin(int id, string username, string email,string rfid)
            :base(id, username, email)
        {
            RFID = rfid;
        }

        public void BlockAccount(User user)
        {
            
        }

        public void SendWarning(string message, Volunteer volunteer)
        {
            
        }

        public void AddRfidToUser(Needy needy, string RFID)
        {

        }
    }
}
