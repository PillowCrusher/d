using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ICT4_Participation_ASP.Models.Database
{
    public class InMemoryDatabase : Repository
    {
        public DataTable ExecuteReadQuery(List<object> parameters, string query)
        {
            throw new NotImplementedException();
        }

        public void ExecuteNonQuery(List<object> parameters, string query)
        {
            throw new NotImplementedException();
        }

        public object ExecuteFunction(List<object> parameters, string function)
        {
            throw new NotImplementedException();
        }

        public object ExecuteSqlFunction(string function)
        {
            throw new NotImplementedException();
        }
    }
}