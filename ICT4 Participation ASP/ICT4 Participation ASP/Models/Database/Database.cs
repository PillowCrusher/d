using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ICT4_Participation_ASP.Models.Administrations;
using Oracle.ManagedDataAccess.Client;

namespace ICT4_Participation_ASP.Models.Database
{
    public class Database
    {
        private Administration _administration;
        
        public Database(Administration administration)
        {
            _administration = administration;
        }

        //public Account Login(string username, string password)
        //{
        //    try
        //    {
        //        //de parameters voor de query
        //        OracleParameter[] loginParameter =
        //        {
        //            new OracleParameter("username", username),
        //            new OracleParameter("password", password)
        //        };
        //        //Voer de query uit
        //        DataTable dt = OracleDatabase.ExecuteReadQuery(DatabaseQueries.Query["GetUserLogin"],
        //            loginParameter);
        //        Account account = null;
        //        //lees de gevonden data uit
        //        foreach (DataRow dr in dt.Rows)
        //        {

        //            int id = Convert.ToInt32(dr["ID"]);
        //            string userName = dr["USERNAME"].ToString();
        //            string email = dr["EMAIL"].ToString();
        //            string name = dr["NAME"].ToString();
        //            string phonenumber = dr["PHONENUMBER"].ToString();
        //            string adres = dr["ADRESS"].ToString();
        //            string city = dr["CITY"].ToString();
        //            bool drivingLicence = Convert.ToBoolean(dr["HASDRIVINGLICENCE"]);
        //            bool car = Convert.ToBoolean(dr["HASCAR"]);
        //            bool isWarned = Convert.ToBoolean(dr["ISWARNED"]);

        //            //als de verjaardag, foto, vog, adress en woonplaats niet leeg zijn wordt een volunteer aangemaakt 
        //            if (dr["DATEOFBIRTH"] != DBNull.Value && dr["PHOTO"] != DBNull.Value && dr["VOG"] != DBNull.Value)
        //            {
        //                DateTime birthdate = Convert.ToDateTime(dr["DATEOFBIRTH"]);
        //                string photo = dr["PHOTO"].ToString();
        //                string vog = dr["VOG"].ToString();
        //                bool blocked = Convert.ToBoolean(dr["ISBLOCKED"]);
        //                bool accpeted = Convert.ToBoolean(dr["ACCEPTED"]);
        //                if (blocked == false)
        //                {
        //                    if (accpeted)
        //                    {
                               
        //                        account =  new Volunteer(id, userName, email, name, adres, city, phonenumber, drivingLicence, car,
        //                            birthdate, photo, vog, isWarned, blocked);
        //                    }
        //                    else
        //                    {
        //                        throw new WarningException(
        //                            "Je kunt nog niet inloggen, de administrator moet eerst je aanvraag goedkeuren");
        //                    }
        //                }
        //                else
        //                {
        //                    throw new WarningException("Sorry, je account is geblokkeerd je kunt niet meer inloggen");
        //                }
        //            }
        //            else if (dr["RFID"] != DBNull.Value && dr["LOCATION"] != DBNull.Value)
        //            {
        //                //als de rfid en locatie niet leeg zijn wordt een needy aangemaakt 
        //                bool ovPossible = Convert.ToBoolean(dr["OVPOSSIBLE"]);
        //                string barcode = dr["BARCODE"].ToString();

        //                account =  new Needy(id, userName, email, name, adres, city, phonenumber, ovPossible, drivingLicence, car, barcode, isWarned);

        //            }
        //        }
        //        // return het gevonden
        //        return account;
        //    }
        //    catch (Exception exception)
        //    {
        //        throw exception;
        //    }
        //}

        ///// <summary>
        ///// methode waarmee een admin kan inloggen doormddel van een username, password en barcode
        ///// </summary>
        ///// <param name="username"></param>
        ///// <param name="password"></param>
        ///// <param name="barcode"></param>
        //public Admin Login(string username, string password, string barcode)
        //{
        //    Admin admin = null;
        //    //de parameters voor de query
        //    OracleParameter[] parameters =
        //    {
        //        new OracleParameter("username", username),
        //        new OracleParameter("password", password),
        //        new OracleParameter("barcode", barcode)
        //    };
        //    //Voer de query uit
        //    DataTable dt = OracleDatabase.ExecuteReadQuery(DatabaseQueries.Query["GetAdminLogin"], parameters);

        //    //lees de gevonden data uit
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        int id = Convert.ToInt32(dr["ID"]);
        //        string userName = Convert.ToString(dr["USERNAME"]);
        //        string email = Convert.ToString(dr["EMAIL"]);
        //        string Barcode = Convert.ToString(dr["BARCODE"]);
        //        //zet de gevonden user in het Field user
        //        admin = new Admin(id, userName, email, Barcode);
        //    }
        //    return admin;
        //}

        ///// <summary>
        ///// methode waarmee een needy kan inloggen doormddel van een rfid
        ///// </summary>
        ///// <param name="Barcode"></param>
        //public Needy LoginWithBarcode(string Barcode)
        //{
        //    Needy needy = null;
        //    try
        //    {
        //        //de parameters voor de query
        //        OracleParameter[] loginParameter =
        //        {
        //            new OracleParameter("barcode", Barcode),
        //        };

        //        //Voer de query uit
        //        DataTable dt = OracleDatabase.ExecuteReadQuery(DatabaseQueries.Query["GetUserLoginByBarcode"],
        //            loginParameter);


        //        //lees de gevonden data uit
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            int id = Convert.ToInt32(dr["ID"]);
        //            string userName = dr["USERNAME"].ToString();
        //            string email = dr["EMAIL"].ToString();
        //            string name = dr["NAME"].ToString();
        //            string adres = dr["ADRESS"].ToString();
        //            string city = dr["CITY"].ToString();
        //            string phonenumber = dr["PHONENUMBER"].ToString();
        //            bool drivingLicence = Convert.ToBoolean(dr["HASDRIVINGLICENCE"]);
        //            bool car = Convert.ToBoolean(dr["HASCAR"]);
        //            bool ovPossible = Convert.ToBoolean(dr["OVPOSSIBLE"]);
        //            bool isWarned = Convert.ToBoolean(dr["ISWARNED"]);
        //            string barcode = dr["BARCODE"].ToString();
                   
        //            //zet de gevonden user in het Field user
        //            needy = new Needy(id, userName, email, name, adres, city, phonenumber, ovPossible, drivingLicence, car, barcode, isWarned);
        //        }
        //        return needy;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        ///// <summary>
        ///// Een methode om het account id op te halen door de zoeken naar de username van de account
        ///// </summary>
        ///// <param name="username"></param>
        ///// <returns></returns>
        //public int GetAccountId(string username)
        //{
        //    int id = 0;

        //    //de parameters voor de query
        //    OracleParameter[] idParameter =
        //    {
        //        new OracleParameter("username", username)
        //    };
        //    //Voer de query uit om het id op te halen
        //    DataTable d = OracleDatabase.ExecuteReadQuery(DatabaseQueries.Query["GetAccountID"], idParameter);

        //    //lees de gevonden data uit
        //    foreach (DataRow dr in d.Rows)
        //    {
        //        id = Convert.ToInt32(dr["ID"]);
        //    }
        //    //geef het gevonden ID terug
        //    return id;
        //}

        ///// <summary>
        ///// Methode waarmee een nieuwe vrijwilliger toegevoegd in de database
        ///// </summary>
        ///// <param name="volunteer"></param>
        //public bool AddVolunteer(Volunteer volunteer, string password)
        //{
        //    try
        //    {
        //        //voeg een acount toe
        //        InsertAccount(volunteer, password);

        //        //haal het id op van het account wat net is toegevoegd
        //        int volunteerId = GetAccountId(volunteer.Username);

        //        //voeg een user toe gekoppeld aan het account doormiddel van het ID
        //        InsertUser(volunteer);

        //        //de parameters voor de query
        //        OracleParameter[] volunteerParameter =
        //        {
        //            new OracleParameter("id", volunteerId),
        //            new OracleParameter("dateofbirth", volunteer.BirthDate),
        //            new OracleParameter("photo", volunteer.Photo),
        //            new OracleParameter("vog", volunteer.VOG)
        //        };
        //        //Voer de query uit om een vrijwilleger toe te voegen
        //        OracleDatabase.ExecuteNonQuery(DatabaseQueries.Query["InsertVolunteer"], volunteerParameter);
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public bool AddNeedy(Needy needy, string password)
        //{
        //    try
        //    {
        //        //voeg een acount toe
        //        InsertAccount(needy, password);

        //        //haal het id op van het account wat net is toegevoegd
        //        int needyId = GetAccountId(needy.Username);

        //        //voeg een user toe gekoppeld aan het account doormiddel van het ID
        //        InsertUser(needy);

        //        //de parameters voor de query
        //        OracleParameter[] needyParameter =
        //        {
        //            new OracleParameter("id", needyId),
        //            new OracleParameter("barcode", needy.Barcode), 
        //            new OracleParameter("ovPossible", needy.OVPosible)
        //        };
        //        //Voer de query uit om een hulpbehoevende toe te voegen
        //        OracleDatabase.ExecuteNonQuery(DatabaseQueries.Query["InsertNeedy"], needyParameter);
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}



        ///// <summary>
        ///// methode om een user in de database toe te voegen
        ///// </summary>
        ///// <param name="username"></param>
        ///// <param name="password"></param>
        ///// <param name="email"></param>
        //public void InsertAccount(Account account, string password)
        //{
        //    try
        //    {
        //        //de parameters voor de query
        //        OracleParameter[] accountParameter =
        //        {
        //            new OracleParameter("username", account.Username),
        //            new OracleParameter("password", password),
        //            new OracleParameter("email", account.Email)
        //        };
        //        //Voer de query uit om een account toe te voegen
        //        OracleDatabase.ExecuteNonQuery(DatabaseQueries.Query["InsertAccount"], accountParameter);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public void InsertUser(User user)
        //{
        //    try
        //    {
        //        //de parameters voor de query
        //        OracleParameter[] userParameter =
        //        {
        //            new OracleParameter("id", user.ID),
        //            new OracleParameter("name", user.Name),
        //            new OracleParameter("adres", user.Adres),
        //            new OracleParameter("city", user.City),  
        //            new OracleParameter("phonenumber", user.Phonenumber),
        //            new OracleParameter("hasdrivinglicence", Convert.ToInt32(user.HasDrivingLincense)),
        //            new OracleParameter("hascar", Convert.ToInt32(user.HasCar)),
        //        };
        //        //Voer de query uit om een user toe te voegen
        //        OracleDatabase.ExecuteNonQuery(DatabaseQueries.Query["InsertUser"], userParameter);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}




        //public List<Review> GetAllReviews()
        //{
        //    List<Review> riviews = new List<Review>();

        //    DataTable dt = OracleDatabase.ExecuteReadQuery(DatabaseQueries.Query["GetAllReviews"], null);
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        riviews.Add(
        //            new Review(
        //                Convert.ToInt32(dr["HELPREQUESTID"]),
        //                Convert.ToInt32(dr["VOLUNTEERID"]),
        //                dr["MESSAGE"].ToString(),
        //                dr["COMMENT"].ToString()
        //                ));
        //    }

        //    return riviews;
        //}


        //public bool UpdateVolunteer(Volunteer volunteer, string password)
        //{
        //    try
        //    {
        //        OracleParameter[] userParameter =
        //        {
        //            new OracleParameter("name", volunteer.Name),
        //            new OracleParameter("adres", volunteer.Adres),
        //            new OracleParameter("city", volunteer.City),
        //            new OracleParameter("phonenumber", volunteer.Phonenumber),
        //            new OracleParameter("hasdrivinglicence", Convert.ToInt32(volunteer.HasDrivingLincense)),
        //            new OracleParameter("hascar", Convert.ToInt32(volunteer.HasCar)),
        //            new OracleParameter("id", volunteer.ID)
        //        };
        //        OracleDatabase.ExecuteNonQuery(DatabaseQueries.Query["UpdateUser"], userParameter);

        //        int volunteerId = GetAccountId(volunteer.Username);

        //        OracleParameter[] volunteerParameter =
        //        {
        //            new OracleParameter("dateofbirth", volunteer.BirthDate),
        //            new OracleParameter("photo", volunteer.Photo),
        //            new OracleParameter("vog", volunteer.VOG),
        //            new OracleParameter("id", volunteerId)
        //        };
        //        OracleDatabase.ExecuteNonQuery(DatabaseQueries.Query["UpdateVolunteer"], volunteerParameter);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //public void DeleteHelprequest(int id)
        //{
        //    try
        //    {
        //        OracleParameter[] deleteParameter =
        //        {
        //            new OracleParameter("id", id)
        //        };
        //        OracleDatabase.ExecuteNonQuery(DatabaseQueries.Query["DeleteHelpRequest"], deleteParameter);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public void DeleteReview(int HelpRequestID, int VolunteerID, string message)
        //{
        //    try
        //    {
        //        OracleParameter[] deleteParameter =
        //        {
        //            new OracleParameter("helprequestid", HelpRequestID),
        //            new OracleParameter("volunteerid", VolunteerID),
        //            new OracleParameter("message", message)
        //        };
        //        OracleDatabase.ExecuteNonQuery(DatabaseQueries.Query["DeleteReview"], deleteParameter);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public void AcceptedVolunteer(int ID)
        //{
        //    try
        //    {
        //        OracleParameter[] updateParameter =
        //        {
        //            new OracleParameter("id", ID)
        //        };
        //        OracleDatabase.ExecuteNonQuery(DatabaseQueries.Query["AcceptedVolunteer"], updateParameter);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public void DenyVolunteer(int ID)
        //{
        //    try
        //    {
        //        OracleParameter[] deleteParameter =
        //        {
        //            new OracleParameter("id", ID)
        //        };
        //        OracleDatabase.ExecuteNonQuery(DatabaseQueries.Query["DenyVolunteer"], deleteParameter);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public List<int> GetAcceptedHelpRequests(OracleParameter[] parameter)
        //{
        //    List<int> helprequestIdList = new List<int>();

        //    try
        //    {
        //        DataTable dt = OracleDatabase.ExecuteReadQuery(DatabaseQueries.Query["GetAcceptedHelpRequests"],
        //            parameter);

        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            helprequestIdList.Add(Convert.ToInt32(dr["HELPREQUESTID"]));
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return helprequestIdList;
        //}


        //public void UnSubscribe(User user)
        //{
        //    try
        //    {
        //        DateTime deRegistrationDate = DateTime.Now;
        //        OracleParameter[] userParameter =
        //        {
        //        new OracleParameter("deregistrationdate", deRegistrationDate),
        //        new OracleParameter("id", user.ID)
        //        };
        //        OracleDatabase.ExecuteNonQuery(DatabaseQueries.Query["UnsubscribeUser"], userParameter);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public void BlockAccount(User user)
        //{
        //    try
        //    {
        //        OracleParameter[] userParameter =
        //        {
        //        new OracleParameter("id", user.ID)
        //        };
        //        OracleDatabase.ExecuteNonQuery(DatabaseQueries.Query["BlockUser"], userParameter);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public void SendWarning(string message, User user)
        //{
        //    try
        //    {
        //        OracleParameter[] userParameter =
        //        {
        //        new OracleParameter("id", user.ID)
        //        };
        //        OracleDatabase.ExecuteNonQuery(DatabaseQueries.Query["WarnUser"], userParameter);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}

        //public void AddRfidToUser(Needy needy, string rfid)
        //{
        //    OracleParameter[] userParameter =
        //        {
        //        new OracleParameter("rfid", rfid),
        //        new OracleParameter("id", needy.ID)
        //        };
        //    OracleDatabase.ExecuteNonQuery(DatabaseQueries.Query["AddRFIDToNeedy"], userParameter);
        //}

        //public List<HelpRequest> GetHelpRequests(string querie, OracleParameter[] parameters)
        //{
        //    List<HelpRequest> helpRequests = new List<HelpRequest>();
            
        //    DataTable dt = OracleDatabase.ExecuteReadQuery(DatabaseQueries.Query[querie], parameters);

        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        //int volunteersNumbers, bool interview, bool completed, List<Skill> skills
        //        helpRequests.Add(
        //            new HelpRequest(
        //                Convert.ToInt32(dr["ID"]),
        //                dr["Title"].ToString(),
        //                dr["Description"].ToString(),
        //                dr["Location"].ToString(),
        //                Convert.ToInt32(dr["TravelTime"]),
        //                Convert.ToBoolean(dr["Urgent"]),
        //                (TransportationType)Enum.Parse(typeof(TransportationType), dr["TransportType"].ToString()),
        //                Convert.ToDateTime(dr["StartDate"]),
        //                Convert.ToDateTime(dr["EndDate"]),
        //                Convert.ToInt32(dr["VolunteerNumbers"]),
        //                Convert.ToBoolean(dr["Interview"]),
        //                Convert.ToBoolean(dr["completed"]),
        //                GetAllSkills("GetSkills", new OracleParameter[] { (new OracleParameter("VolunteerID", Convert.ToInt32(dr["ID"]))) })
                        
        //                )
        //            );
        //    }

        //    return helpRequests;
        //}


        //public List<Volunteer> GetAllVolunteers(string queryName)
        //{
        //    List<Volunteer> volunteers = new List<Volunteer>();

        //    DataTable dt = OracleDatabase.ExecuteReadQuery(DatabaseQueries.Query[queryName], null);
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        volunteers.Add(
        //            new Volunteer(
        //                Convert.ToInt32(dr["ID"]),
        //                dr["Username"].ToString(),
        //                dr["Email"].ToString(),
        //                dr["Name"].ToString(),
        //                dr["Adress"].ToString(),
        //                dr["City"].ToString(),
        //                dr["Phonenumber"].ToString(),
        //                Convert.ToBoolean(dr["HasDrivingLicence"]),
        //                Convert.ToBoolean(dr["HasCar"]),
        //                Convert.ToDateTime(dr["DateOfBirth"]),
        //                dr["Photo"].ToString(),
        //                dr["VOG"].ToString(),
        //                Convert.ToBoolean(dr["ISWARNED"]),
        //                Convert.ToBoolean(dr["ISBLOCKED"]))
        //            );

        //    }
        //    return volunteers;
        //}

        //public List<Skill> GetAllSkills(string queryName, OracleParameter[] parameters)
        //{
        //    List<Skill> skills = new List<Skill>();

        //    DataTable dt = OracleDatabase.ExecuteReadQuery(DatabaseQueries.Query[queryName], parameters);
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        skills.Add(
        //            new Skill(
        //                dr["Naam"].ToString()));
        //    }
        //    return skills;
        //}






        //public static DataTable GetReadQuery(List<object> parameterlist, string query)
        //{
        //    if (OracleDatabase.CheckConnection())
        //    {
        //        return OracleDatabase.ExecuteReadQuery(DatabaseQueries.Query[query], parameterlist);
        //    }
        //    throw new NotImplementedException("InMemory nog aan te maken");
        //}

        //public static void ExecuteNonQuery(List<object> parameterlist, string query)
        //{
        //    if (OracleDatabase.CheckConnection())
        //    {
        //        OracleDatabase.ExecuteNonQuery(DatabaseQueries.Query[query], parameterlist);
        //    }
        //    throw new NotImplementedException("InMemory nog aan te maken");
        //}
    }
}