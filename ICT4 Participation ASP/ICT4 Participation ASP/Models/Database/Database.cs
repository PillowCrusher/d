using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace ICT4_Participation_ASP.Models.Database
{
    public class Database : Repository
    {
        private Administration _administration;
        
        public Database(Administration administration)
        {
            _administration = administration;
        }

        public void UnSubscribe(User user)
        {
            try
            {
                DateTime deRegistrationDate = DateTime.Now;
                OracleParameter[] userParameter =
                {
                new OracleParameter("deregistrationdate", deRegistrationDate),
                new OracleParameter("id", user.ID)
                };
                OracleManager.ExecuteNonQuery(DatabaseQuerys.Query["UnsubscribeUser"], userParameter);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void BlockAccount(User user)
        {
            try
            {
                OracleParameter[] userParameter =
                {
                new OracleParameter("id", user.ID)
                };
                OracleManager.ExecuteNonQuery(DatabaseQuerys.Query["BlockUser"], userParameter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SendWarning(string message, User user)
        {
            try
            {
                OracleParameter[] userParameter =
                {
                new OracleParameter("id", user.ID)
                };
                OracleManager.ExecuteNonQuery(DatabaseQuerys.Query["WarnUser"], userParameter);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void AddRfidToUser(Needy needy, string rfid)
        {
            OracleParameter[] userParameter =
                {
                new OracleParameter("rfid", rfid),
                new OracleParameter("id", needy.ID)
                };
            OracleManager.ExecuteNonQuery(DatabaseQuerys.Query["AddRFIDToNeedy"], userParameter);
        }

        public List<HelpRequest> GetHelpRequests(string querie, OracleParameter[] parameters)
        {
            List<HelpRequest> helpRequests = new List<HelpRequest>();
            
            DataTable dt = OracleManager.ExecuteReadQuery(DatabaseQuerys.Query[querie], parameters);

            foreach (DataRow dr in dt.Rows)
            {
                //int volunteersNumbers, bool interview, bool completed, List<Skill> skills
                helpRequests.Add(
                    new HelpRequest(
                        Convert.ToInt32(dr["ID"]),
                        dr["Title"].ToString(),
                        dr["Description"].ToString(),
                        dr["Location"].ToString(),
                        Convert.ToInt32(dr["TravelTime"]),
                        Convert.ToBoolean(dr["Urgent"]),
                        (TransportationType)Enum.Parse(typeof(TransportationType), dr["TransportType"].ToString()),
                        Convert.ToDateTime(dr["StartDate"]),
                        Convert.ToDateTime(dr["EndDate"]),
                        Convert.ToInt32(dr["VolunteerNumbers"]),
                        Convert.ToBoolean(dr["Interview"]),
                        Convert.ToBoolean(dr["completed"]),
                        GetAllSkills("GetSkills", new OracleParameter[] { (new OracleParameter("VolunteerID", Convert.ToInt32(dr["ID"]))) })
                        
                        )
                    );
            }

            return helpRequests;
        }


        public List<Volunteer> GetAllVolunteers(string queryName)
        {
            List<Volunteer> volunteers = new List<Volunteer>();

            DataTable dt = OracleManager.ExecuteReadQuery(DatabaseQuerys.Query[queryName], null);
            foreach (DataRow dr in dt.Rows)
            {
                volunteers.Add(
                    new Volunteer(
                        Convert.ToInt32(dr["ID"]),
                        dr["Username"].ToString(),
                        dr["Email"].ToString(),
                        dr["Name"].ToString(),
                        dr["Adress"].ToString(),
                        dr["City"].ToString(),
                        dr["Phonenumber"].ToString(),
                        Convert.ToBoolean(dr["HasDrivingLicence"]),
                        Convert.ToBoolean(dr["HasCar"]),
                        Convert.ToDateTime(dr["DateOfBirth"]),
                        dr["Photo"].ToString(),
                        dr["VOG"].ToString(),
                        Convert.ToBoolean(dr["ISWARNED"]),
                        Convert.ToBoolean(dr["ISBLOCKED"]))
                    );

            }
            return volunteers;
        }

        public List<Skill> GetAllSkills(string queryName, OracleParameter[] parameters)
        {
            List<Skill> skills = new List<Skill>();

            DataTable dt = OracleManager.ExecuteReadQuery(DatabaseQuerys.Query[queryName], parameters);
            foreach (DataRow dr in dt.Rows)
            {
                skills.Add(
                    new Skill(
                        dr["Naam"].ToString()));
            }
            return skills;
        }
    }
}
