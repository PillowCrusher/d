using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICT4_Participation_ASP.Models.Database;

namespace ICT4_Participation_ASP.Models.Handlers
{
    public class AdminHandler : Handler
    {
        public AdminHandler()
        {
            
        }

        public void AddNeedy()
        {
            List<object> objects = new List<object>();
            Db.ExecuteNonQuery(objects, DatabaseQueries.Query[""]);
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
