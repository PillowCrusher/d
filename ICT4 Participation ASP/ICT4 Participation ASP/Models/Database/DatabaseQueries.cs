using System.Collections.Generic;
using ICT4_Participation_ASP.Models.Objects;

namespace ICT4_Participation_ASP.Models.Database
{
    public static class DatabaseQueries
    {
        public static readonly Dictionary<QueryId, string> Query = new Dictionary<QueryId, string>();

        static DatabaseQueries()
        {
            //GET
            Query[QueryId.GetAllHelpRequests] =
                "SELECT h.ID, u.NAME, h.TITLE, h.DESCRIPTION, h.LOCATION, h.URGENT, h.TRANSPORTTYPE, h.STARTDATE, h.ENDDATE, h.INTERVIEW, h.COMPLETED " +
                "FROM \"Needy\" n " +
                " JOIN \"Helprequest\" h" +
                " ON h.NeedyID = n.ID" +
                " JOIN \"User\" u" +
                " ON u.ID = n.ID " +
                " WHERE h.COMPLETED = 0";

            //:needyid
            Query[QueryId.GetUserHelpRequests] =
                "SELECT h.ID, u.NAME, h.TITLE, h.DESCRIPTION, h.LOCATION, h.URGENT, h.TRANSPORTTYPE, h.STARTDATE, h.ENDDATE, h.INTERVIEW, h.COMPLETED " +
                "FROM \"Needy\" n " +
                " JOIN \"Helprequest\" h" +
                " ON h.NeedyID = n.ID" +
                " JOIN \"User\" u" +
                " ON u.ID = n.ID " +
                " WHERE n.ID = :p" +
                " AND h.COMPLETED = 0";

            //:username, :password
            Query[QueryId.GetUserLogin] =
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
            Query[QueryId.GetUserLoginByBarcode] =
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
            Query[QueryId.GetAdminLogin] =
                "select * " +
                "from \"Account\" a " +
                "left join \"Admin\" ad " +
                "on a.ID = ad.ID " +
                "where a.Username = :p " +
                "and a.Password = :pp " +
                "and ad.BARCODE = :ppp";

            //:username
            Query[QueryId.GetAccountID] = "SELECT ID from \"Account\" where Username = :p";

            Query[QueryId.GetAcceptedVolunteers] = "select * from \"Volunteer\" v left join \"User\" u on v.ID = u.ID left join \"Account\" a on a.ID = u.ID WHERE ACCEPTED = 1";

            Query[QueryId.GetVOGVolunteers] = "select * from \"Volunteer\" v left join \"User\" u on v.ID = u.ID left join \"Account\" a on a.ID = u.ID WHERE ACCEPTED = 0";

            Query[QueryId.GetAllReviews] = "SELECT * FROM \"Review\"";

            //:helprequestid
            Query[QueryId.GetChatMessagesFromHelprequest] =
                "SELECT * FROM \"ChatMessage\" c " +
                "left join \"Account\" a " +
                "on c.USERID = a.ID " +
                "left join \"User\" u " +
                "on a.ID = u.ID " +
                "WHERE c.HELPREQUESTID = :p";

            //:id
            Query[QueryId.GetAllReviewsVolunteer] = "SELECT * FROM \"Review\" WHERE VOLUNTEERID = :p";

            //:id
            Query[QueryId.GetVolunteersHelprequest] =
                "select * " +
                "from \"UserHelprequest\" h, \"Volunteer\" v " +
                "left join \"User\" u " +
                "on v.ID = u.ID " +
                "left join \"Account\" a " +
                "on a.ID = u.ID " +
                "WHERE h.USERID = a.id " +
                "AND h.HELPREQUESTID = :p";

            //:userid
            Query[QueryId.GetAcceptedHelpRequests] = "SELECT HELPREQUESTID FROM \"UserHelprequest\" WHERE USERID = :p AND STATUS = 'Accepted'";



            //UPDATE
            //:id
            Query[QueryId.WarnUser] = "UPDATE \"User\" SET ISWARNED = 1 where ID = :p";

            //:id
            Query[QueryId.BlockUser] = "UPDATE \"Volunteer\" SET ISBLOCKED = 1 where ID = :p";

            //:id
            Query[QueryId.CompleteHelpRequest] = "UPDATE \"Helprequest\" SET COMPLETED = 1 WHERE ID = :p";

            //:HelprequestID, :UserID
            Query[QueryId.HelpRequestAccept] = "UPDATE \"UserHelprequest\" SET Status = 'Accepted' WHERE(HelprequestID = :p AND UserID = :pp)";

            //:HelprequestID, :UserID
            Query[QueryId.HelpRequestDecline] = "UPDATE \"UserHelprequest\" SET Status = 'Declined' WHERE(HelprequestID = :p AND UserID = :pp) ";

            //:id
            Query[QueryId.AcceptedVolunteer] = "UPDATE \"Volunteer\" SET ACCEPTED = 1 WHERE ID = :p";

            //:adres, :city, :phonenumber, :hasdrivinglicence, :hascar, :id";
            Query[QueryId.UpdateUser] = "update \"User\" SET Adres = :p, City = :pp, Phonenumber = :ppp, Hasdrivinglicence = :pppp, Hascar = :ppppp where ID = :pppppp";

            //:dateofbirth, photo = :photo, VOG = :vog where ID = :id"
            Query[QueryId.UpdateVolunteer] = "update \"Volunteer\" set DateOfBirth = :p, photo = :pp, VOG = :ppp where ID = :pppp";

            //:reaction, :review, :id
            Query[QueryId.UpdateCommentReview] = "UPDATE \"Review\" SET COMMENTS = :p WHERE MESSAGE = :pp AND VOLUNTEERID = :ppp";

            //:id
            Query[QueryId.UnWarnUser] = "UPDATE \"User\" SET ISWARNED = 0 where ID = :p";

            //:deregistrationdate, :id
            Query[QueryId.UnsubscribeUser] = "UPDATE \"User\" set Deregistrationdate = :p where ID = :pp";



            //DELETE
            //:id
            Query[QueryId.DenyVolunteer] = "DELETE FROM \"Account\" WHERE ID = :p";

            //:helprequestid, :volunteerid, :message
            Query[QueryId.DeleteReview] = "DELETE FROM \"Review\" WHERE HelpRequestID = :p AND VolunteerID = :pp AND message = :pp";

            //:id
            Query[QueryId.DeleteHelpRequest] = "DELETE FROM \"Helprequest\" where ID = :p";



            //INSERT
            //:needyid, :title, :description, :location, :urgent, :transporttype, :startdate, :enddate, :interview
            Query[QueryId.InsertHelprequest] = "INSERT INTO \"Helprequest\" (NeedyID, Title, Description, Location, Urgent, TransportType, StartDate, EndDate, Interview) values (:p, :pp, :ppp, :pppp, :ppppp, :pppppp, :ppppppp, :pppppppp, :ppppppppp)";

            //:helprequestid, :volunteerid, :message
            Query[QueryId.InsertReview] = "INSERT INTO \"Review\" (HelpRequestID, VolunteerID, Message) values (:p, :pp, :ppp)";

            //:username, :password, :email
            Query[QueryId.InsertAccount] = "INSERT INTO \"Account\" (Username, Password, Email) values (:p, :pp, :ppp)";

            //:id, :name, :adres, :city, :phonenumber, :hasdrivinglicence, :hascar
            Query[QueryId.InsertUser] = "INSERT INTO \"User\" (ID, NAME, ADRES, CITY, PHONENUMBER, HASDRIVINGLICENCE, HASCAR) values (:p, :pp, :ppp, :pppp, :ppppp, :pppppp, :ppppppp)";

            //:id, :dateofbirth, :photo, :vog
            Query[QueryId.InsertVolunteer] = "INSERT INTO \"Volunteer\" (ID, DATEOFBIRTH, PHOTO, VOG) values (:p, :pp, :ppp, :pppp)";

            //:id, :barcode, :ovPossible
            Query[QueryId.InsertNeedy] = "INSERT INTO \"Needy\" (ID, BARCODE, OVPOSSIBLE) values (:p, :pp, :ppp)";

            //:id, :barcode
            Query[QueryId.InsertAdmin] = "INSERT INTO \"Admin\" (ID, BARCODE) values (:p, :pp)";

            //:userid, :helprequestid, :time, :message
            Query[QueryId.InsertChatMessage] = "INSERT INTO \"ChatMessage\" (UserID, HelpRequestID, Time, Message) values (:p, :pp, :ppp, :pppp)";

            //:userid, :helprequestid
            Query[QueryId.InsertUserHelprequest] = "INSERT INTO \"UserHelprequest\" (UserID, HelpRequestID) values (:p, :pp)";

            //:reporter, :reported, :reason
            Query[QueryId.InsertReport] = "INSERT INTO \"Report\" (Reporter, Reported, Reason) values (:p, :pp, :ppp)";







            //NOG NAAR KIJKEN!!!!!!!!
            //
            //Query[QueryId.AddRFIDToNeedy] = "UPDATE \"Needy\" set RFID = :rfid where ID = :id";
            //
            //:userid, :helprequestid
            //Query[QueryId.CheckifUserHelprequestExists] = "SELECT * FROM \"UserHelprequest\" WHERE USERID = :p AND HelprequestID = :pp";
            //
            //Query[QueryId.UpdateNeedy] = "update \"Needy\" set RFID = :rfid, location = :location where ID = :id";
            //
            //Query[QueryId.UpdateHelpRequest] = "UPDATE \"UserHelprequest\" SET  ";
        }
    }
}
