﻿using System.Collections.Generic;
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
                "SELECT h.ID, h.TITLE, h.DESCRIPTION, h.LOCATION, h.TRAVELTIME, h.URGENT, h.TRANSPORTTYPE, h.STARTDATE, h.ENDDATE, h.VOLUNTEERSNUMBER, h.INTERVIEW " +
                "FROM \"Needy\" n " +
                " JOIN \"Helprequest\" h" +
                " ON h.NeedyID = n.ID" +
                " JOIN \"User\" u" +
                " ON u.ID = n.ID " +
                " WHERE h.COMPLETED = 0";

            Query[QueryId.GetAllHelpRequestsInc] =
                "SELECT h.ID, h.TITLE, h.DESCRIPTION, h.LOCATION, h.TRAVELTIME, h.URGENT, h.TRANSPORTTYPE, h.STARTDATE, h.ENDDATE, h.VOLUNTEERSNUMBER, h.INTERVIEW " +
                "FROM \"Needy\" n " +
                " JOIN \"Helprequest\" h" +
                " ON h.NeedyID = n.ID" +
                " JOIN \"User\" u" +
                " ON u.ID = n.ID ";

            //:needyid
            Query[QueryId.GetUserHelpRequests] =
                "SELECT h.ID, h.TITLE, h.DESCRIPTION, h.LOCATION, h.TRAVELTIME, h.URGENT, h.TRANSPORTTYPE, h.STARTDATE, h.ENDDATE, h.VOLUNTEERSNUMBER, h.INTERVIEW " +
                " FROM \"Needy\" n " +
                " JOIN \"Helprequest\" h " +
                " ON h.NeedyID = n.ID " +
                " WHERE n.ID = :p " +
                " AND h.COMPLETED = 0 " +
                " ORDER BY h.ID";

            //:needyid, :title, :startdate, :enddate
            Query[QueryId.GetUserHelpRequest] =
            "SELECT h.ID, h.TITLE, h.DESCRIPTION, h.LOCATION, h.TRAVELTIME, h.URGENT, h.TRANSPORTTYPE, h.STARTDATE, h.ENDDATE, h.VOLUNTEERSNUMBER, h.INTERVIEW " +
            " FROM \"Needy\" n " +
            " JOIN \"Helprequest\" h " +
            " ON h.NeedyID = n.ID " +
            " WHERE n.ID = :p " +
            " AND h.TITLE = :pp "+
            " AND h.STARTDATE = :ppp "+
            " AND h.ENDDATE = :pppp "+
            " AND h.COMPLETED = 0 " +
            " ORDER BY h.ID";

            //:VolunteerID
            Query[QueryId.GetFilteredHelpRequests] = 
            "SELECT h.ID, h.NEEDYID, h.TITLE, h.DESCRIPTION, h.LOCATION, h.TRAVELTIME, h.URGENT, h.TRANSPORTTYPE, h.STARTDATE, h.ENDDATE, h.VOLUNTEERSNUMBER, h.INTERVIEW " + 
            "FROM \"Helprequest\" h " +
            "WHERE ID NOT IN(SELECT HELPREQUESTID " +
                            "FROM \"RequiredSkills\" rs " + 
                            "WHERE SKILL NOT IN( SELECT ss.SKILL " +
                                                "FROM \"SkillSet\" ss " +
                                                "WHERE ss.VOLUNTEERID = :p)) " +
            "AND h.completed = 0 " +
            "ORDER BY h.STARTDATE";

            //:Username, :Password, :Barcode
            Query[QueryId.GetUserLogin] = "LogIn";

            //:barcode
            Query[QueryId.GetUserLoginByBarcode] = "SELECT * FROM TABLE(LogInBar(:p))";

            //:Username
            Query[QueryId.GetUserWarned] = "SELECT iswarned FROM \"User\" WHERE ID = (SELECT ID FROM \"Account\" WHERE username = :p)";

            //:Username
            Query[QueryId.ResetUserWarned] = "UPDATE \"User\" SET iswarned = 0 WHERE ID = (SELECT ID FROM \"Account\" WHERE username = :p)";

            Query[QueryId.GetNeedy] = "SELECT * FROM \"Needy\" u LEFT JOIN \"Account\" a ON u.ID = a.ID LEFT JOIN \"User\" us ON us.ID = a.ID";
            //:username, :password
            //Query[QueryId.GetUserLogin] =
            //    "select * " +
            //    "from \"Account\" a " +
            //    "left join \"User\" u " +
            //    "on a.ID = u.ID " +
            //    "left join \"Volunteer\" v " +
            //    "on u.ID = v.ID " +
            //    "left join \"Needy\" n " +
            //    "on u.ID = n.ID " +
            //    "where a.Username = :p " +
            //    "and a.Password = :pp " +
            //    "AND Deregistrationdate IS NULL";

            //:barcode
            //Query[QueryId.GetUserLoginByBarcode] =
            //    "select * " +
            //    "from \"Account\" a " +
            //    "left join \"User\" u " +
            //    "on a.ID = u.ID " +
            //    "left join \"Volunteer\" v " +
            //    "on u.ID = v.ID " +
            //    "left join \"Needy\" n " +
            //    "on u.ID = n.ID " +
            //    "where n.BARCODE = :p " +
            //    "AND Deregistrationdate IS NULL";

            //:username, :password, :barcode
            //Query[QueryId.GetAdminLogin] =
            //    "select * " +
            //    "from \"Account\" a " +
            //    "left join \"Admin\" ad " +
            //    "on a.ID = ad.ID " +
            //    "where a.Username = :p " +
            //    "and a.Password = :pp " +
            //    "and ad.BARCODE = :ppp";

            //:username
            //Query[QueryId.GetAccountID] = "SELECT ID from \"Account\" where Username = :p";

            //:helprequestID
            //Query[QueryId.GetAcceptedUsers] = 
            //    "SELECT u.ID, u.Name, u.Adres, u.City, u.Phonenumber, u.HasDrivinglicence, u.HasCar, u.DeregistrationDate, u.IsWarned " +
            //    "FROM \"User\" u " +
            //    "JOIN \"UserHelprequest\" uh " +
            //    "ON u.ID = uh.UserID WHERE uh.HelprequestID = :p " +
            //    "AND uh.Status = Accepted";

            Query[QueryId.GetAcceptedVolunteers] = 
                "select a.ID, a.Username, a.Email, u.Name, u.Adres, u.city, u.phonenumber, u.hasdrivinglicence, u.hascar, u.iswarned, v.dateofbirth, v.photo, v.vog, v.isblocked " +
                "from \"Account\" a Join \"User\" u " +
                "on a.ID = u.ID " +
                "Join \"Volunteer\" v " +
                "on a.ID = v.ID " +
                "JOIN \"UserHelprequest\" uh " +
                "on a.ID = uh.userID " +
                "WHERE uh.Status = 'Accepted' " +
                "AND uh.helprequestID = :p " +
                "AND v.ISBLOCKED = 0";

            Query[QueryId.GetAcceptedVolunteersNoHulprequest] = "select a.ID, a.Username, a.Email, u.Name, u.Adres, u.city, u.phonenumber, u.hasdrivinglicence, u.hascar, u.iswarned, v.dateofbirth, v.photo, v.vog, v.isblocked "+
               " from \"Account\" a Join \"User\" u "+
               "on a.ID = u.ID " +
               "Join \"Volunteer\" v "+
               "on a.ID = v.ID "+
               "WHERE v.Accepted = 1 "+
               "AND v.ISBLOCKED = 0";


            Query[QueryId.GetVOGVolunteers] = "select * from \"Account\" a left join \"User\" u on a.ID = u.ID left join \"Volunteer\" v on u.ID = v.ID  where v.ACCEPTED = 0";
            Query[QueryId.GetPendingVolunteers] = "select * from \"Account\" a "+ 
            " left join \"User\" u on a.ID = u.ID "+
            " left join \"Volunteer\" v on u.ID = v.ID "+
            " left join \"UserHelprequest\" uh on u.ID = uh.USERID "+
            " left join \"Helprequest\" h on uh.HelpRequestID = h.ID "+
            " where uh.STATUS = 'Pending' AND u.DEREGISTRATIONDATE IS NULL AND h.ID = :p";

            Query[QueryId.GetAllReviews] = "SELECT * FROM \"Review\"";

            //:helprequestid
            Query[QueryId.GetReviewsFromHelpRequest] = "SELECT * FROM \"Review\" r LEFT JOIN \"Volunteer\" v ON r.VolunteerID = v.ID  LEFT JOIN \"Account\" a ON v.ID = a.ID LEFT JOIN \"User\" u ON u.ID = a.ID WHERE HELPREQUESTID = :helprequestid";

            //:helprequestid
            Query[QueryId.GetChatMessagesFromHelprequest] = "SELECT * FROM \"ChatMessage\" c WHERE c.HELPREQUESTID = :p ORDER BY TIME";

            //:id
            Query[QueryId.GetAllReviewsVolunteer] = "SELECT * FROM \"Review\" WHERE VOLUNTEERID = :p AND COMMENTS IS NULL";

            //:id
            Query[QueryId.GetVolunteersHelprequest] =
                "SELECT u.ID, u.Name, u.Adres, u.City, u.Phonenumber, u.HasDrivinglicence, u.HasCar, u.DeregistrationDate, u.IsWarned " +
                "FROM \"User\" u " +
                "JOIN \"UserHelprequest\" uh " +
                "ON u.ID = uh.UserID WHERE uh.HelprequestID = :p " +
                "AND uh.Status = 'Accepted'";

            //:i
            
            //:id
            Query[QueryId.GetVolunteersHelprequested] =
                "SELECT *  FROM \"User\" u JOIN \"Account\" a ON u.ID = a.ID JOIN \"Volunteer\" ur ON ur.ID = a.ID " +
                "WHERE ur.ISBLOCKED = 0 AND u.ID IN (SELECT uh.VolunteerID FROM \"Review\" uh " +
                "WHERE uh.HelpRequestID IN(SELECT uhr.HelpRequestID  FROM \"UserHelprequest\" uhr WHERE uhr.Status = 'Accepted' " +
                "AND uhr.HelprequestID = :p))";
            
            //:userid
            Query[QueryId.GetAcceptedHelpRequests] =
                "SELECT h.ID, h.TITLE, h.DESCRIPTION, h.LOCATION, h.TRAVELTIME, h.URGENT, h.TRANSPORTTYPE, h.STARTDATE, h.ENDDATE, h.VOLUNTEERSNUMBER, h.INTERVIEW " +
                "FROM \"Helprequest\" h " +
                "JOIN \"UserHelprequest\" uh " +
                "ON h.ID = uh.HelprequestID " +
                "WHERE h.COMPLETED = 0 " +
                "AND uh.UserID = :p " +
                "AND uh.Status = 'Accepted'";

            Query[QueryId.GetReviewFromHelpRequestUser] =
                "SELECT * FROM \"Review\" WHERE HELPREQUESTID = :helprequest  AND VOLUNTEERID = :volunteer";

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
            Query[QueryId.AcceptVolunteer] = "UPDATE \"Volunteer\" SET ACCEPTED = 1 WHERE ID = :p";

            //:adres, :city, :phonenumber, :hasdrivinglicence, :hascar, :id";
            Query[QueryId.UpdateUser] = "update \"User\" SET Adres = :p, City = :pp, Phonenumber = :ppp, Hasdrivinglicence = :pppp, Hascar = :ppppp where ID = :pppppp";

            //:ID, :Adres, :City, :phonenumber, :hasdrivinglicence, :hascar, :photo, :vog
            Query[QueryId.UpdateVolunteer] = "UpdateVolunteer";

            //:reaction, :review, :id
            Query[QueryId.UpdateCommentReview] = "UPDATE \"Review\" SET COMMENTS = :p WHERE MESSAGE = :pp AND VOLUNTEERID = :ppp";

            //:id
            Query[QueryId.UnWarnUser] = "UPDATE \"User\" SET ISWARNED = 0 where ID = :p";

            //:deregistrationdate, :id
            Query[QueryId.UnsubscribeUser] = "UPDATE \"User\" set Deregistrationdate = :p where ID = :pp";

            //:helprequestid
            Query[QueryId.CompleteHelpRequest] = "UPDATE \"Helprequest\" SET Completed = 1 WHERE ID = :p";

            //DELETE
            //:id
            Query[QueryId.DenyVolunteer] = "DELETE FROM \"Account\" WHERE ID = :p";

            //:helprequestid, :volunteerid, :message
            Query[QueryId.DeleteReview] = "DELETE FROM \"Review\" WHERE HelpRequestID = :p AND VolunteerID = :pp AND message = :pp";

            //:id
            Query[QueryId.DeleteHelpRequest] = "DELETE FROM \"Helprequest\" where ID = :p";

            //:p, :pp
            Query[QueryId.DeleteReviews] = "DELETE FROM \"Review\" WHERE HelprequestID = :p AND VolunteerID = :pp";

            //INSERT
            //:needyid, :title, :description, :location, :traveltime, :urgent, :transporttype, :startdate, :enddate, :volunteersnumber, :interview
            Query[QueryId.InsertHelprequest] = "INSERT INTO \"Helprequest\" (NeedyID, Title, Description, Location, TravelTime, Urgent, TransportType, StartDate, EndDate, VolunteersNumber, Interview) values (:p, :pp, :ppp, :pppp, :ppppp, :pppppp, :ppppppp, :pppppppp, :ppppppppp, :pppppppppp, :ppppppppppp)";

            //:helprequestid, :volunteerid, :message
            Query[QueryId.InsertReview] = "INSERT INTO \"Review\" (HelpRequestID, VolunteerID, Message) values (:p, :pp, :ppp)";

            //:username, :password, :email
            //Query[QueryId.InsertAccount] = "INSERT INTO \"Account\" (Username, Password, Email) values (:p, :pp, :ppp)";

            //:id, :name, :adres, :city, :phonenumber, :hasdrivinglicence, :hascar
            //Query[QueryId.InsertUser] = "INSERT INTO \"User\" (ID, NAME, ADRES, CITY, PHONENUMBER, HASDRIVINGLICENCE, HASCAR) values (:p, :pp, :ppp, :pppp, :ppppp, :pppppp, :ppppppp)";

            //:username, :password, :email, :name, :adres, :city, :phonenumber, :hasdrivinglicence, :hascar, :dateofbirth, :photo, :vog
            Query[QueryId.InsertVolunteer] = "CreateVolunteer";

            //:username, :password, :email, :name, :adres, :city, :phonenumber, :hasdrivinglicence, :hascar, :ovPossible, :barcode
            Query[QueryId.InsertNeedy] = "CreateNeedy";

            //:id, :barcode
            Query[QueryId.InsertAdmin] = "INSERT INTO \"Admin\" (ID, BARCODE) values (:p, :pp)";

            //:userid, :helprequestid, :time, :message
            Query[QueryId.InsertChatMessage] = "INSERT INTO \"ChatMessage\" (UserID, SenderName, HelpRequestID, Time, Message) values (:p, :pp, :ppp, :pppp, :ppppp)";

            //:userid, :helprequestid
            Query[QueryId.InsertUserHelprequest] = "INSERT INTO \"UserHelprequest\" (UserID, HelpRequestID) values (:p, :pp)";

            //:reporter, :reported, :reason
            Query[QueryId.InsertReport] = "INSERT INTO \"Report\" (Reporter, Reported, Reason) values (:p, :pp, :ppp)";



            Query[QueryId.GetAllVolunteerHelpRequests] =
                "SELECT h.ID, h.TITLE, h.DESCRIPTION, h.LOCATION, h.TRAVELTIME, h.URGENT, h.TRANSPORTTYPE, h.STARTDATE, h.ENDDATE, h.VOLUNTEERSNUMBER, h.INTERVIEW  "+
                "FROM \"Helprequest\" h "+
                "JOIN \"UserHelprequest\" uh "+
                "ON h.ID = uh.HELPREQUESTID "+
                "JOIN \"Volunteer\" v "+
                "ON uh.USERID = v.ID "+
                "WHERE v.ID = :p";

            Query[QueryId.GetSkills] = "SELECT * FROM \"Skill\"";

            Query[QueryId.GetLastHelprequestID] = "SELECT MAX(id) FROM \"Helprequest\"";

            Query[QueryId.InsertHelprequestSkill] =
                "INSERT INTO \"RequiredSkills\"(HELPREQUESTID, SKILL) VALUES(:p, :pp)";

            Query[QueryId.InsertVolunteerSkill] =
                "INSERT INTO \"SkillSet\"(VOLUNTEERID, SKILL) VALUES(:p, :pp)";

            Query[QueryId.GetVolunteerSkills] = "SELECT s.* FROM \"Skill\" s, \"SkillSet\" ss WHERE s.NAME = ss.SKILL AND ss.VOLUNTEERID = 3";


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
