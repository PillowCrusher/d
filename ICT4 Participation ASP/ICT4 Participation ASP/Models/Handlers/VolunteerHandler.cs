using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICT4_Participation_ASP.Models.Accounts;
using ICT4_Participation_ASP.Models.Database;
using ICT4_Participation_ASP.Models.Objects;

namespace ICT4_Participation_ASP.Models.Handlers
{
    public class VolunteerHandler : Handler
    {
        public VolunteerHandler()
        {

        }

        public void UpdateProfileData(List<object> parameters)
        {
            try
            {
                Db.ExecuteSqlProcedure(parameters, DatabaseQueries.Query[QueryId.UpdateVolunteer]);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Unsubscribe(DateTime time, Volunteer volunteer)
        {
            try
            {
                List<object> parameters = new List<object>();
                parameters.Add(time);
                parameters.Add(volunteer.ID);
                Db.ExecuteNonQuery(parameters, DatabaseQueries.Query[QueryId.UnsubscribeUser]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
