using System.Collections.Generic;

namespace ICT4Participation.Classes.Database
{
    public static class DatabaseQuerys
    {
        public static Dictionary<string, string> Query = new Dictionary<string, string>();

        static DatabaseQuerys()
        {
            Query["GetUserLogin"] = "SELECT * FROM \"ACCOUNT\" WHERE USERNAME = :username AND PASSWORD = :password";
            Query["GetAllHelpRequests"] = "SELECT * FROM \"HELPREQUEST\"";
            Query["GetUserHelpRequests"] = "SELECT * FROM \"HELPREQUEST\" WHERE NEEDYID = :needyid";
            Query["GetChatMessagesFromHelprequest"] = "SELECT * FROM \"CHATMESSAGE\" WHERE HELPREQUEST_ID = :helprequest_id";
            Query["Blargh"] = "";
        }
    }
}
