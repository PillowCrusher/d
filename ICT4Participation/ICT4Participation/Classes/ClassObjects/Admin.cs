using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Participation.Classes.ClassObjects
{
    public class Admin
    {
        public string RFID { get; set; }
        public Account Account { get; set; }

        public Admin(Account account, string rfid)
        {
            this.Account = account;
            this.RFID = rfid;
        }

        public void BlockAccount(Account account)
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
