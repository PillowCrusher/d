using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICT4_Participation_ASP.Models.Accounts;
using ICT4_Participation_ASP.Models.Database;
using ICT4_Participation_ASP.Models.Objects;

namespace ICT4_Participation_ASP.Models.Handlers
{
    public class AdminHandler : Handler
    {
        public AdminHandler()
        {
            
        }

        public void AddNeedy(string username, string email, string name, string address, string city, string phonenumber, int ov, int drivinglicense, int car, string barcode, string password)
        {
            List<object> objects = new List<object>();
            objects.Add(username);
            objects.Add(password);
            objects.Add(email);
            objects.Add(name);
            objects.Add(address);
            objects.Add(city);
            objects.Add(phonenumber);
            objects.Add(drivinglicense);
            objects.Add(car);
            objects.Add(ov);
            objects.Add(barcode);
            Db.ExecuteSqlProcedure(objects, DatabaseQueries.Query[QueryId.InsertNeedy]);
        }

        public void DeleteHelprequest(HelpRequest hr)
        {
            List<object> objects = new List<object>();
            objects.Add(hr.ID);
            Db.ExecuteNonQuery(objects, DatabaseQueries.Query[QueryId.DeleteHelpRequest]);
        }

        public void BlockUser(Volunteer v)
        {
            List<object> objects = new List<object>();
            objects.Add(v.ID);
            Db.ExecuteNonQuery(objects, DatabaseQueries.Query[QueryId.BlockUser]);
        }

        public void WarnUser(User u)
        {
            List<object> objects = new List<object>();
            objects.Add(u.ID);
            Db.ExecuteNonQuery(objects, DatabaseQueries.Query[QueryId.WarnUser]);
        }

        public List<Volunteer> FillAccepted()
        {
            List<object> parameters = new List<object>();


            DataTable dt = Db.ExecuteReadQuery(parameters,DatabaseQueries.Query[QueryId.GetAcceptedVolunteers]);


            List<Volunteer> acceptedVolunteers = new List<Volunteer>();

            foreach (DataRow dr in dt.Rows)
            {
                acceptedVolunteers.Add(new Volunteer(dr));
            }

            return acceptedVolunteers;
        }

        public List<Volunteer> FillUnaccepted()
        {

            List<object> parameters = new List<object>();


            DataTable dt = Db.ExecuteReadQuery(parameters, DatabaseQueries.Query[QueryId.GetVOGVolunteers]);


            List<Volunteer> acceptedVolunteers = new List<Volunteer>();

            foreach (DataRow dr in dt.Rows)
            {
                acceptedVolunteers.Add(new Volunteer(dr));
            }

            return acceptedVolunteers;
        }

    }
}
