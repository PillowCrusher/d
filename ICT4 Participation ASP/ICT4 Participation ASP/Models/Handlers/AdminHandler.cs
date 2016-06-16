using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICT4_Participation_ASP.Models.Database;
using ICT4_Participation_ASP.Models.Objects;

namespace ICT4_Participation_ASP.Models.Handlers
{
    public class AdminHandler : Handler
    {
        public AdminHandler()
        {
            
        }

        public void AddNeedy(string username, string email, string name, string address, string city, string phonenumber, bool ov, bool drivinglicense, bool car, string barcode, string password)
        {
            List<object> objects = new List<object>();
            objects.Add(username);
            objects.Add(email);
            objects.Add(name);
            objects.Add(address);
            objects.Add(city);
            objects.Add(phonenumber);
            objects.Add(ov);
            objects.Add(drivinglicense);
            objects.Add(car);
            objects.Add(barcode);
            objects.Add(password);
            //Db.ExecuteNonQuery(objects, DatabaseQueries.Query[QueryId]);
        }

        public bool DeleteHelprequest()
        {
            throw new NotImplementedException();
        }

        public bool BlockUser()
        {
            throw new NotImplementedException();
        }

        public bool WarnUser()
        {
            throw new NotImplementedException();
        }
    }
}
