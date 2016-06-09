using System.Collections.Generic;

namespace ICT4_Participation_ASP.Models.Database
{
    public static class DatabaseQueries
    {
        public static Dictionary<string, string> Query = new Dictionary<string, string>();

        static DatabaseQueries()
        {
            //GET
            Query["GetAllHelpRequests"] =
                "SELECT h.ID, u.NAME, h.TITLE, h.DESCRIPTION, h.LOCATION, h.URGENT, h.TRANSPORTTYPE, h.STARTDATE, h.ENDDATE, h.INTERVIEW, h.COMPLETED " +
                "FROM \"Needy\" n " +
                " JOIN \"Helprequest\" h" +
                " ON h.NeedyID = n.ID" +
                " JOIN \"User\" u" +
                " ON u.ID = n.ID " +
                " WHERE h.COMPLETED = 0";

            //:needyid
            Query["GetUserHelpRequests"] =
                "SELECT h.ID, u.NAME, h.TITLE, h.DESCRIPTION, h.LOCATION, h.URGENT, h.TRANSPORTTYPE, h.STARTDATE, h.ENDDATE, h.INTERVIEW, h.COMPLETED " +
                "FROM \"Needy\" n " +
                " JOIN \"Helprequest\" h" +
                " ON h.NeedyID = n.ID" +
                " JOIN \"User\" u" +
                " ON u.ID = n.ID " +
                " WHERE n.ID = :p" +
                " AND h.COMPLETED = 0";

            //:username, :password
            Query["GetUserLogin"] =
                "select * " +
                "from \"Account\" a " +
                "left join \"User\" u " +
                "on a.ID = u.ID " +
                "left join \"Volunteer\" v " +
                "on u.ID = v.ID " +
                "left join \"Needy\" n " +
                "on u.ID = n.ID " +
                "where a.Username = :p " +
                "and a.Password = :pp " +
                "AND Deregistrationdate IS NULL";

            //:barcode
            Query["GetUserLoginByBarcode"] =
                "select * " +
                "from \"Account\" a " +
                "left join \"User\" u " +
                "on a.ID = u.ID " +
                "left join \"Volunteer\" v " +
                "on u.ID = v.ID " +
                "left join \"Needy\" n " +
                "on u.ID = n.ID " +
                "where n.BARCODE = :p " +
                "AND Deregistrationdate IS NULL";

            //:username, :password, :barcode
            Query["GetAdminLogin"] =
                "select * " +
                "from \"Account\" a " +
                "left join \"Admin\" ad " +
                "on a.ID = ad.ID " +
                "where a.Username = :p " +
                "and a.Password = :pp " +
                "and ad.BARCODE = :ppp";

            //:username
            Query["GetAccountID"] = "SELECT ID from \"Account\" where Username = :p";

            Query["GetAcceptedVolunteers"] = "select * from \"Volunteer\" v left join \"User\" u on v.ID = u.ID left join \"Account\" a on a.ID = u.ID WHERE ACCEPTED = 1";

            Query["GetVOGVolunteers"] = "select * from \"Volunteer\" v left join \"User\" u on v.ID = u.ID left join \"Account\" a on a.ID = u.ID WHERE ACCEPTED = 0";

            Query["GetAllReviews"] = "SELECT * FROM \"Review\"";

            //:helprequestid
            Query["GetChatMessagesFromHelprequest"] =
                "SELECT * FROM \"ChatMessage\" c " +
                "left join \"Account\" a " +
                "on c.USERID = a.ID " +
                "left join \"User\" u " +
                "on a.ID = u.ID " +
                "WHERE c.HELPREQUESTID = :p";

            //:id
            Query["GetAllReviewsVolunteer"] = "SELECT * FROM \"Review\" WHERE VOLUNTEERID = :p";

            //:id
            Query["GetVolunteersHelprequest"] =
                "select * " +
                "from \"UserHelprequest\" h, \"Volunteer\" v " +
                "left join \"User\" u " +
                "on v.ID = u.ID " +
                "left join \"Account\" a " +
                "on a.ID = u.ID " +
                "WHERE h.USERID = a.id " +
                "AND h.HELPREQUESTID = :p";

            //:userid
            Query["GetAcceptedHelpRequests"] = "SELECT HELPREQUESTID FROM \"UserHelprequest\" WHERE USERID = :p AND STATUS = 'Accepted'";



            //UPDATE
            //:id
            Query["WarnUser"] = "UPDATE \"User\" SET ISWARNED = 1 where ID = :p";

            //:id
            Query["BlockUser"] = "UPDATE \"Volunteer\" SET ISBLOCKED = 1 where ID = :p";

            //:id
            Query["CompleteHelpRequest"] = "UPDATE \"Helprequest\" SET COMPLETED = 1 WHERE ID = :p";

            //:HelprequestID, :UserID
            Query["HelpRequestAccept"] = "UPDATE \"UserHelprequest\" SET Status = 'Accepted' WHERE(HelprequestID = :p AND UserID = :pp)";

            //:HelprequestID, :UserID
            Query["HelpRequestDecline"] = "UPDATE \"UserHelprequest\" SET Status = 'Declined' WHERE(HelprequestID = :p AND UserID = :pp) ";
            
            //:id
            Query["AcceptedVolunteer"] = "UPDATE \"Volunteer\" SET ACCEPTED = 1 WHERE ID = :p";
            
            //:adres, :city, :phonenumber, :hasdrivinglicence, :hascar, :id";
            Query["UpdateUser"] = "update \"User\" SET Adres = :p, City = :pp, Phonenumber = :ppp, Hasdrivinglicence = :pppp, Hascar = :ppppp where ID = :pppppp";

            //:dateofbirth, photo = :photo, VOG = :vog where ID = :id"
            Query["UpdateVolunteer"] = "update \"Volunteer\" set DateOfBirth = :p, photo = :pp, VOG = :ppp where ID = :pppp";

            //:reaction, :review, :id
            Query["UpdateCommentReview"] = "UPDATE \"Review\" SET COMMENTS = :p WHERE MESSAGE = :pp AND VOLUNTEERID = :ppp";

            //:id
            Query["UnWarnUser"] = "UPDATE \"User\" SET ISWARNED = 0 where ID = :p";

            //:deregistrationdate, :id
            Query["UnsubscribeUser"] = "UPDATE \"User\" set Deregistrationdate = :p where ID = :pp";



            //DELETE
            //:id
            Query["DenyVolunteer"] = "DELETE FROM \"Account\" WHERE ID = :p";

            //:helprequestid, :volunteerid, :message
            Query["DeleteReview"] = "DELETE FROM \"Review\" WHERE HelpRequestID = :p AND VolunteerID = :pp AND message = :pp";

            //:id
            Query["DeleteHelpRequest"] = "DELETE FROM \"Helprequest\" where ID = :p";



            //INSERT
            //:needyid, :title, :description, :location, :urgent, :transporttype, :startdate, :enddate, :interview
            Query["InsertHelprequest"] = "INSERT INTO \"Helprequest\" (NeedyID, Title, Description, Location, Urgent, TransportType, StartDate, EndDate, Interview) values (:p, :pp, :ppp, :pppp, :ppppp, :pppppp, :ppppppp, :pppppppp, :ppppppppp)";

            //:helprequestid, :volunteerid, :message
            Query["InsertReview"] = "INSERT INTO \"Review\" (HelpRequestID, VolunteerID, Message) values (:p, :pp, :ppp)";

            //:username, :password, :email
            Query["InsertAccount"] = "INSERT INTO \"Account\" (Username, Password, Email) values (:p, :pp, :ppp)";

            //:id, :name, :adres, :city, :phonenumber, :hasdrivinglicence, :hascar
            Query["InsertUser"] = "INSERT INTO \"User\" (ID, NAME, ADRES, CITY, PHONENUMBER, HASDRIVINGLICENCE, HASCAR) values (:p, :pp, :ppp, :pppp, :ppppp, :pppppp, :ppppppp)";

            //:id, :dateofbirth, :photo, :vog
            Query["InsertVolunteer"] = "INSERT INTO \"Volunteer\" (ID, DATEOFBIRTH, PHOTO, VOG) values (:p, :pp, :ppp, :pppp)";

            //:id, :barcode, :ovPossible
            Query["InsertNeedy"] = "INSERT INTO \"Needy\" (ID, BARCODE, OVPOSSIBLE) values (:p, :pp, :ppp)";

            //:id, :barcode
            Query["InsertAdmin"] = "INSERT INTO \"Admin\" (ID, BARCODE) values (:p, :pp)";

            //:userid, :helprequestid, :time, :message
            Query["InsertChatMessage"] = "INSERT INTO \"ChatMessage\" (UserID, HelpRequestID, Time, Message) values (:p, :pp, :ppp, :pppp)";

            //:userid, :helprequestid
            Query["InsertUserHelprequest"] = "INSERT INTO \"UserHelprequest\" (UserID, HelpRequestID) values (:p, :pp)";

            //:reporter, :reported, :reason
            Query["InsertReport"] = "INSERT INTO \"Report\" (Reporter, Reported, Reason) values (:p, :pp, :ppp)";







            //NOG NAAR KIJKEN!!!!!!!!
            //
            //Query["AddRFIDToNeedy"] = "UPDATE \"Needy\" set RFID = :rfid where ID = :id";
            //
            //:userid, :helprequestid
            //Query["CheckifUserHelprequestExists"] = "SELECT * FROM \"UserHelprequest\" WHERE USERID = :p AND HelprequestID = :pp";
            //
            //Query["UpdateNeedy"] = "update \"Needy\" set RFID = :rfid, location = :location where ID = :id";
            //
            //Query["UpdateHelpRequest"] = "UPDATE \"UserHelprequest\" SET  ";
        }
    }
}
