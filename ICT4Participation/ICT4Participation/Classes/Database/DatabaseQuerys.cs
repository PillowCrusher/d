using System.Collections.Generic;

namespace ICT4Participation.Classes.Database
{
    public static class DatabaseQuerys
    {
        public static Dictionary<string, string> query = new Dictionary<string, string>();

        static DatabaseQuerys()
        {
            query["GetAllLogins"] = "SELECT * FROM EMPLOYEELOGINS";
            
        }
    }
}
