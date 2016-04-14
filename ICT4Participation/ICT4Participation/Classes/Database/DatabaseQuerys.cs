using System.Collections.Generic;

namespace ICT4Participation.Classes.Database
{
    public static class DatabaseQuerys
    {
        public static Dictionary<string, string> Query = new Dictionary<string, string>();

        static DatabaseQuerys()
        {
            Query["InsertAccount"] = "INSERT INTO \"Account\" (ID, Username, Password, Email) values (ACCOUNT_SEQ.nextval, :harry, :password, :email);";
            Query["InsertVolunteer"] = "INSERT INTO \"Account\" (ID, Username, Password, Email) values (ACCOUNT_SEQ.nextval, :harry, :password, :email);";
            Query["GetUserLogin"] = "SELECT Username, Password FROM \"ACCOUNT\" WHERE USERNAME = :username AND PASSWORD = :password";
            Query["GetAllHelpRequests"] = "SELECT * FROM \"HELPREQUEST\"";
            Query["GetUserHelpRequests"] = "SELECT * FROM \"HELPREQUEST\" WHERE NEEDYID = :needyid";
            Query["GetChatMessagesFromHelprequest"] = "SELECT * FROM \"CHATMESSAGE\" WHERE HELPREQUEST_ID = :helprequest_id";
            
        }
    }
}
