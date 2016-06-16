using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICT4_Participation_ASP.Models.Database;

namespace ICT4_Participation_ASP.Models.Handlers
{
    public class NeedyHandler : Handler
    {
        public void AddHelprequest(string titel, string description, string location, DateTime startTime, DateTime endTime, bool DrivingLicence, bool urgent, bool meeting, string skills)
        {
            List<object> objects = new List<object>();
            objects.Add(titel);
            objects.Add(description);
            objects.Add(location);
            objects.Add(startTime);
            objects.Add(endTime);
            objects.Add(DrivingLicence);
            objects.Add(urgent);
            objects.Add(meeting);
            objects.Add(skills);
            Db.ExecuteNonQuery(objects, DatabaseQueries.Query[]);
        }

    }
}
