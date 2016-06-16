using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
