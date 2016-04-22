using System.Collections.Generic;

namespace ICT4Participation.Classes.Database
{
    public static class DatabaseQuerys
    {
        public static Dictionary<string, string> Query = new Dictionary<string, string>();

        static DatabaseQuerys()
        {
            Query["GetAccountID"] = "SELECT ID from \"Account\" where Username = :username";
            Query["InsertAccount"] = "INSERT INTO \"Account\" (Username, Password, Email) values (:username, :password, :email)";
            Query["InsertUser"] = "INSERT INTO \"User\" (ID, NAME, PHONENUMBER, HASDRIVINGLICENCE, HASCAR, OVPOSSIBLE) values (:id, :name, :phonenumber, :hasdrivinglicence, :hascar, :ovpossible)";
            Query["InsertVolunteer"] = "INSERT INTO \"Volunteer\" (ID, DATEOFBIRTH, PHOTO, VOG, ADRESS, CITY) values (:id, :dateofbirth, :photo, :vog, :adress, :city)";
            Query["InsertNeedy"] = "INSERT INTO \"Needy\" (ID, RFID, LOCATION) values (:id, :rfid, :location)";
            Query["InsertAdmin"] = "INSERT INTO \"Admin\" (ID, RFID) values (:id, :rfid)";
            Query["InsertHelprequest"] = "INSERT INTO \"Helprequest\" (Title, Description, Location, Urgent, TransportType, StartDate, EndDate, Interview) values (:title, :description, :location, :urgent, :transporttype, :startdate, :enddate, :interview)";
            Query["InsertReview"] = "INSERT INTO \"Review\" (ID, HelpRequestID, VolunteerID, Message) values (REVIEW_SEQ.nextval, :helprequestid, :volunteerid, :message)";
            Query["InsertChatMessage"] = "INSERT INTO \"ChatMessage\" (UserID, HelpRequestID, Time, Message) values (:userid, :helprequestid, :time, :message)";
            Query["InsertUserHelprequest"] = "INSERT INTO \"UserHelprequest\" (UserID, HelpRequestID) values (:userid, :helprequestid)";
            Query["InsertReport"] = "INSERT INTO \"Report\" (Reporter, Reported, Reason) values (:reporter, :reported, :reason)";

            Query["GetUserLogin"] =
                "select * from \"Account\" a left join \"User\" u on a.ID = u.ID left join \"Volunteer\" v on u.ID = v.ID left join \"Needy\" n on u.ID = n.ID where a.Username = :username and a.Password = :password";
            Query["GetUserLoginByRFID"] =
                "select * from \"Account\" a left join \"User\" u on a.ID = u.ID left join \"Volunteer\" v on u.ID = v.ID left join \"Needy\" n on u.ID = n.ID where n.RFID = :rfid";
            Query["GetAdminLogin"] =
                "select * from \"Account\" a left join \"Admin\" ad on a.ID = ad.ID where a.Username = :username and a.Password = :password and n.RFID = :rfid";
            Query["UpdateAccount"] = "update \"Account\" set Username = :username, Password = :password, Email = :email where ID = :id";
            Query["UpdateUser"] = "update \"User\" set Name = :name, Adress = :adress, City = :city, Phonenumber = :phonenumber, Hasdrivinglicence = :hasdrivinglicence, Hascar = :hascar where ID = :id";
            Query["UpdateVolunteer"] = "update \"Volunteer\" set DateOfBirth = :dateofbirth, photo = :photo, City = :vog where ID = :id";
            Query["GetChatMessagesFromHelprequest"] = "SELECT * FROM \"ChatMessage\" WHERE HELPREQUEST_ID = :helprequest_id";
            Query["DeleteHelpRequest"] = "DELETE FROM \"Helprequest\" where ID = :id";
            Query["UpdateHelpRequest"] = "UPDATE \"UserHelprequest\" SET  ";
            Query["BlockUser"] = "UPDATE \"Volunteer\" SET Blocked = true where ID = :id";
            Query["UnsubscribeUser"] = "UPDATE \"User\" set Deregistrationdate = :deregistrationdate where ID = :id";
            //VrijwilligersForm
            Query["GetAllHelpRequests"] =
                "SELECT h.ID, u.NAME, h.TITLE, h.DESCRIPTION, h.LOCATION, h.URGENT, h.TRANSPORTTYPE, h.STARTDATE, h.ENDDATE, h.INTERVIEW, h.COMPLETED " +
                "FROM \"Needy\" n " +
                " JOIN \"Helprequest\" h" +
                " ON h.NeedyID = n.ID" +
                " JOIN \"User\" u" +
                " ON u.ID = n.ID " +
                " WHERE h.COMPLETED = 0";
            Query["GetUserHelpRequests"] =
                "SELECT h.ID, u.NAME, h.TITLE, h.DESCRIPTION, h.LOCATION, h.URGENT, h.TRANSPORTTYPE, h.STARTDATE, h.ENDDATE, h.INTERVIEW, h.COMPLETED " +
                "FROM \"Needy\" n " +
                " JOIN \"Helprequest\" h" +
                " ON h.NeedyID = n.ID" +
                " JOIN \"User\" u" +
                " ON u.ID = n.ID " +
                " WHERE n.NAME = :needyid" +
                " AND h.COMPLETED = 0";

            Query["HelpRequestAccept"] = "UPDATE \"UserHelprequest\" SET Accepted = 1 WHERE(HelprequestID = :HelprequestID AND UserID = :UserID) ";
            Query["HelpRequestDecline"] = "UPDATE \"UserHelprequest\" SET Accepted = 2 WHERE(HelprequestID = :HelprequestID AND UserID = :UserID) ";
        }
    }
}
