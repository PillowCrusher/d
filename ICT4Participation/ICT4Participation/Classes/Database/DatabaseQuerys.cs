using System.Collections.Generic;

namespace ICT4Participation.Classes.Database
{
    public static class DatabaseQuerys
    {
        public static Dictionary<string, string> Query = new Dictionary<string, string>();

        static DatabaseQuerys()
        {
            Query["GetAccountID"] = "SELECT ACCOUNT_SEQ.nextval from dual;";
            Query["InsertAccount"] = "INSERT INTO \"Account\" (ID, Username, Password, Email) values (:id, :username, :password, :email);";
            Query["InsertUser"] = "INSERT INTO \"User\" (ID, NAME, ADRESS, CITY, PHONENUMBER, HASDRIVINGLICENCE, HASCAR, DEREGISTRATIONDATE) values (:id, :name, :adress, :city, :phonenumber, :hasdrivinglicence, :hascar, :deregistrationdate);";
            Query["InsertVolunteer"] = "INSERT INTO \"Volunteer\" (ID, DATEOFBIRTH, PHOTO, VOG) values (:id, :dateofbirth, :photo, :vog);";
            Query["InsertNeedy"] = "INSERT INTO \"Needy\" (ID, OVPOSSIBLE, RFID) values (:id, :ovpossible, :rfid);";
            Query["InsertAdmin"] = "INSERT INTO \"Admin\" (ID, RFID) values (:id, :rfid);";
            Query["InsertHelprequest"] = "INSERT INTO \"Helprequest\" (ID, Title, Description, Location, Urgent, TransportType, StartDate, EndDate, Interview) values (:id, :title, :description, :location, :urgent, :transporttype, :startdate, :enddate, :interview);";
            Query["InsertReview"] = "INSERT INTO \"Review\" (ID, HelpRequestID, VolunteerID, Message) values (REVIEW_SEQ.nextval, :helprequestid, :volunteerid, :message);";
            Query["InsertChatMessage"] = "INSERT INTO \"ChatMessage\" (UserID, HelpRequestID, Time, Message) values (:userid, :helprequestid, :time, :message);";
            Query["InsertUserHelprequest"] = "INSERT INTO \"UserHelprequest\" (UserID, HelpRequestID) values (:userid, :helprequestid);";
            Query["InsertReport"] = "INSERT INTO \"Report\" (Reporter, Reported, Reason) values (:reporter, :reported, :reason);";

            Query["GetUserLogin"] = "SELECT Username, Password FROM \"Account\" WHERE USERNAME = :username AND PASSWORD = :password";
            Query["GetAllHelpRequests"] = "SELECT * FROM \"Helprequest\"";
            Query["GetUserHelpRequests"] = "SELECT * FROM \"Helprequest\" WHERE NEEDYID = :needyid";
            Query["GetChatMessagesFromHelprequest"] = "SELECT * FROM \"ChatMessage\" WHERE HELPREQUEST_ID = :helprequest_id";

            Query["UpdateHelpRequest"] = "UPDATE \"UserHelprequest\" SET  ";

        }
    }
}
