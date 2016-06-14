using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4_Participation_ASP.Models.Database
{
    interface Repository
    {
        DataTable ExecuteReadQuery(List<object> parameters, string query);

        void ExecuteNonQuery(List<object> parameters, string query);

        object ExecuteSqlFunction(List<object> parameters, string function);
    }
}
