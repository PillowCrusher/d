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

            objects.Clear();
            objects.Add(user.ID);
            objects.Add(titel);
            objects.Add(startTime);
            objects.Add(endTime);
            DataTable dt = Db.ExecuteReadQuery(objects, DatabaseQueries.Query[QueryId.GetUserHelpRequest]);

            foreach (DataRow dr in dt.Rows)
            {
                HelpRequest request = new HelpRequest(dr);
                user.AddHelpRequest(request);
            }
        }

        public List<HelpRequest> GetHelprequests(Needy user)
        {           
            List<object> parameters = new List<object>();
            parameters.Add(user.ID);

            DataTable dt =  Db.ExecuteReadQuery(parameters, DatabaseQueries.Query[QueryId.GetUserHelpRequests]);
            
            List<HelpRequest> requestses = new List<HelpRequest>();
            foreach (DataRow dr in dt.Rows)
            {
                HelpRequest request = new HelpRequest(dr);
                user.AddHelpRequest(request);
            }
            return requestses;
        }

        public void AddChatMessage(HelpRequest helpRequest, Needy needy, string message, DateTime time)
        {
            helpRequest.AddChatMessages(new ChatMessage(needy, message, time));
            List<object> objects = new List<object>();
            objects.Add(needy.ID);
            objects.Add(helpRequest.ID);
            objects.Add(time);
            objects.Add(message);
            Db.ExecuteNonQuery(objects, DatabaseQueries.Query[QueryId.InsertChatMessage]);
        }
    }
}
