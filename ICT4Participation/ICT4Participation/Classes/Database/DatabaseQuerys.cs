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
            Query["InsertHelprequest"] = "INSERT INTO \"Helprequest\" (ID, Description, Location, TravelTime, StartDate, EndDate) values (:id, :description, :location, :traveltime, :startdate, :enddate);";
            Query["InsertReview"] = "INSERT INTO \"Review\" (ID, HelpRequestID, VolunteerID, Message, Comments) values (REVIEW_SEQ.nextval, :helprequestid, :volunteerid, :message, :comments);";
            Query["InsertChatMessage"] = "INSERT INTO \"ChatMessage\" (UserID, HelpRequestID, Time, Message) values (:userid, :helprequestid, :time, :message);";
            Query["InsertUserHelprequest"] = "INSERT INTO \"UserHelprequest\" (UserID, HelpRequestID) values (:userid, :helprequestid);";

            Query["GetUserLogin"] = "SELECT Username, Password FROM \"ACCOUNT\" WHERE USERNAME = :username AND PASSWORD = :password";
            Query["GetAllHelpRequests"] = "SELECT * FROM \"HELPREQUEST\"";
            Query["GetUserHelpRequests"] = "SELECT * FROM \"HELPREQUEST\" WHERE NEEDYID = :needyid";
            Query["GetChatMessagesFromHelprequest"] = "SELECT * FROM \"CHATMESSAGE\" WHERE HELPREQUEST_ID = :helprequest_id";
            
        }
    }
}
