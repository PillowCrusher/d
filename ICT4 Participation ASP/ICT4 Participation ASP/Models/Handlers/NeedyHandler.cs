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
    public class NeedyHandler : Handler
    {

        public void AddHelprequest(Needy user, string titel, string description, string location, int traveltime,  int urgent, string Transportation, DateTime startTime, DateTime endTime, int ammount, int meeting)//string skills)
        {
            List<object> objects = new List<object>();
            objects.Add(user.ID);
            objects.Add(titel);
            objects.Add(description);
            objects.Add(location);
            objects.Add(traveltime);
            objects.Add(urgent);
            objects.Add(Transportation);
            objects.Add(startTime);
            objects.Add(endTime);
            objects.Add(ammount);
            objects.Add(meeting);
           // objects.Add(skills);
            Db.ExecuteNonQuery(objects, DatabaseQueries.Query[QueryId.InsertHelprequest]);
        }

        public List<HelpRequest> GetHelprequests(Needy user)
        {
            List<object> parameters = new List<object>();
            parameters.Add(user.ID);

            DataTable dt = Db.ExecuteReadQuery(null, Db.ExecuteSqlFunction(parameters, DatabaseQueries.Query[QueryId.GetUserHelpRequests]).ToString());
            
            List<HelpRequest> requestses = new List<HelpRequest>();
            foreach (DataRow dr in dt.Rows)
            {
                HelpRequest request = new HelpRequest(dr);
                requestses.Add(request);
            }
            return requestses;
        }
    }
}
