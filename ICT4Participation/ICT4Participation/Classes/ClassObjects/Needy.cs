using ICT4Participation.Classes.Database;
using Oracle.ManagedDataAccess.Client;
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
        public string Location { get; private set; }

        public Needy(Account account, string name, string location, string phonenumber, bool publicTransport, bool hasDrivingLincense, bool hasCar, string rfid)
            : base(account, name, phonenumber, publicTransport, hasDrivingLincense, hasCar)
        {
            RFID = rfid;
            Location = location;
        }

        public void AddHelpRequest(string titel, string description, bool urgent, TransportationType transportType, DateTime startDate, DateTime endDate, bool requestintroduction)
        {
            OracleParameter[] parameters =
            {
                new OracleParameter("title", titel),
                new OracleParameter("description", description),
                new OracleParameter("location", Location),
                new OracleParameter("urgent", Convert.ToInt32(urgent)),
                new OracleParameter("transporttype", transportType.ToString()),
                new OracleParameter("startdate", startDate),
                new OracleParameter("enddate", endDate),
                new OracleParameter("interview", Convert.ToInt32(requestintroduction))
            };
            DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["InsertHelprequest"], parameters);
        }

        public void DeleteHelpRequest(HelpRequest helprequest)
        {

        }
    }
}
