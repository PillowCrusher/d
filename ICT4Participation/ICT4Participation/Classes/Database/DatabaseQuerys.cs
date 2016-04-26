using System.Collections.Generic;

namespace ICT4Participation.Classes.Database
{
    public static class DatabaseQuerys
    {
        public static Dictionary<string, string> Query = new Dictionary<string, string>();

        static DatabaseQuerys()
        {
            //AdminForm
            Query["WarnUser"] = "UPDATE \"User\" SET ISWARNED = 1 where ID = :id";

            Query["BlockUser"] = "UPDATE \"Volunteer\" SET ISBLOCKED = 1 where ID = :id";

            Query["AddRFIDToNeedy"] = "UPDATE \"Needy\" set RFID = :rfid where ID = :id";


            //VrijwilligersForm
            Query["GetAllHelpRequests"] =
                "SELECT h.ID, u.NAME, h.TITLE, h.DESCRIPTION, h.LOCATION, h.URGENT, h.TRANSPORTTYPE, h.STARTDATE, h.ENDDATE, h.INTERVIEW, h.COMPLETED " +
                "FROM \"Needy\" n " +
                " JOIN \"Helprequest\" h" +
                " ON h.NeedyID = n.ID" +
                " JOIN \"User\" u" +
                " ON u.ID = n.ID " +
                " WHERE h.COMPLETED = 0";


            //NeedyForm
            Query["GetUserHelpRequests"] =
                "SELECT h.ID, u.NAME, h.TITLE, h.DESCRIPTION, h.LOCATION, h.URGENT, h.TRANSPORTTYPE, h.STARTDATE, h.ENDDATE, h.INTERVIEW, h.COMPLETED " +
                "FROM \"Needy\" n " +
                " JOIN \"Helprequest\" h" +
                " ON h.NeedyID = n.ID" +
                " JOIN \"User\" u" +
                " ON u.ID = n.ID " +
                " WHERE n.ID = :needyid" +
                " AND h.COMPLETED = 0";

            Query["InsertHelprequest"] = "INSERT INTO \"Helprequest\" (NeedyID, Title, Description, Location, Urgent, TransportType, StartDate, EndDate, Interview) values (:needyid, :title, :description, :location, :urgent, :transporttype, :startdate, :enddate, :interview)";

            Query["InsertReview"] = "INSERT INTO \"Review\" (ID, HelpRequestID, VolunteerID, Message) values (REVIEW_SEQ.nextval, :helprequestid, :volunteerid, :message)";


            //LoginForm
            Query["GetUserLogin"] = "select * from \"Account\" a left join \"User\" u on a.ID = u.ID left join \"Volunteer\" v on u.ID = v.ID left join \"Needy\" n on u.ID = n.ID where a.Username = :username and a.Password = :password AND Deregistrationdate IS NULL";

            Query["GetUserLoginByRFID"] = "select * from \"Account\" a left join \"User\" u on a.ID = u.ID left join \"Volunteer\" v on u.ID = v.ID left join \"Needy\" n on u.ID = n.ID where n.RFID = :rfid AND Deregistrationdate IS NULL";

            Query["GetAdminLogin"] = "select * from \"Account\" a left join \"Admin\" ad on a.ID = ad.ID where a.Username = :username and a.Password = :password and ad.RFID = :rfid";


            //Administration
            Query["GetAccountID"] = "SELECT ID from \"Account\" where Username = :username";
            
            Query["InsertAccount"] = "INSERT INTO \"Account\" (Username, Password, Email) values (:username, :password, :email)";

            Query["InsertUser"] = "INSERT INTO \"User\" (ID, NAME, PHONENUMBER, HASDRIVINGLICENCE, HASCAR, OVPOSSIBLE) values (:id, :name, :phonenumber, :hasdrivinglicence, :hascar, :ovpossible)";

            Query["InsertVolunteer"] = "INSERT INTO \"Volunteer\" (ID, DATEOFBIRTH, PHOTO, VOG, ADRESS, CITY) values (:id, :dateofbirth, :photo, :vog, :adress, :city)";

            Query["InsertNeedy"] = "INSERT INTO \"Needy\" (ID, RFID, LOCATION) values (:id, :rfid, :location)";

            Query["InsertAdmin"] = "INSERT INTO \"Admin\" (ID, RFID) values (:id, :rfid)";

            Query["GetAcceptedVolunteers"] = "select * from \"Volunteer\" v left join \"User\" u on v.ID = u.ID left join \"Account\" a on a.ID = u.ID WHERE ACCEPTED = 1";

            Query["GetVOGVolunteers"] = "select * from \"Volunteer\" v left join \"User\" u on v.ID = u.ID left join \"Account\" a on a.ID = u.ID WHERE ACCEPTED = 0";

            //HelpRequest
            Query["InsertChatMessage"] = "INSERT INTO \"ChatMessage\" (UserID, HelpRequestID, Time, Message) values (:userid, :helprequestid, :time, :message)";

            Query["CheckifUserHelprequestExists"] = "SELECT * FROM \"UserHelprequest\" WHERE USERID = :userid AND HelprequestID = :helprequestid";

            Query["InsertUserHelprequest"] = "INSERT INTO \"UserHelprequest\" (UserID, HelpRequestID) values (:userid, :helprequestid)";

            Query["InsertReport"] = "INSERT INTO \"Report\" (Reporter, Reported, Reason) values (:reporter, :reported, :reason)";

            Query["HelpRequestAccept"] = "UPDATE \"UserHelprequest\" SET Accepted = 1 WHERE(HelprequestID = :HelprequestID AND UserID = :UserID) ";

            Query["HelpRequestDecline"] = "UPDATE \"UserHelprequest\" SET Accepted = 2 WHERE(HelprequestID = :HelprequestID AND UserID = :UserID) ";

            Query["DeleteReview"] = "DELETE FROM \"Review\" WHERE HelpRequestID = :helprequestid AND VolunteerID = :volunteerid AND message = :message";

            //not yet needed            
            Query["AcceptedVolunteer"] = "UPDATE \"Volunteer\" SET ACCEPTED = 1 WHERE ID = :id";

            Query["DenyVolunteer"] = "DELETE FROM \"Account\" WHERE ID = :id";

            Query["UpdateUser"] = "update \"User\" SET Phonenumber = :phonenumber, Hasdrivinglicence = :hasdrivinglicence, Hascar = :hascar, OVPOSSIBLE = :ovpossible where ID = :id";
            
            Query["UpdateVolunteer"] = "update \"Volunteer\" set DateOfBirth = :dateofbirth, photo = :photo, VOG = :vog, Adress = :adress, City = :city where ID = :id";
            
            Query["UpdateNeedy"] = "update \"Needy\" set RFID = :rfid, location = :location where ID = :id";
            
            Query["GetChatMessagesFromHelprequest"] = "SELECT * FROM \"ChatMessage\" c left join \"Account\" a on c.USERID = a.ID left join \"User\" u on a.ID = u.ID WHERE c.HELPREQUESTID = :helprequestid";
            
            Query["DeleteHelpRequest"] = "DELETE FROM \"Helprequest\" where ID = :id";


            Query["UpdateHelpRequest"] = "UPDATE \"UserHelprequest\" SET  ";

            Query["UnWarnUser"] = "UPDATE \"User\" SET ISWARNED = 0 where ID = :id";
            
            Query["UnsubscribeUser"] = "UPDATE \"User\" set Deregistrationdate = :deregistrationdate where ID = :id";
            
        }
    }
}
