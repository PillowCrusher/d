using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

//using System.Configuration;

namespace ICT4_Participation_MVC.Models.Database
{
    public static class OracleManager
    {
        private static OracleConnection _connection;

        private static OracleConnection Connection
        {
            get
            {
                try
                {
                    // _connection = new OracleConnection(ConfigurationManager.ConnectionStrings["DBC"].ConnectionString);
                    _connection =
                        new OracleConnection(
                            "Data Source = 192.168.20.37; Persist Security Info = true; User Id = PTS37; Password = PTS37;");
                    _connection.Open();
                    return _connection;
                }
                catch (Exception)
                {
                    throw new ArgumentException(
                        "Het is niet mogelijk een verbinding te maken Controleer of de VPN verbinding open staat");
                }
            }
        }

        public static DataTable ExecuteReadQuery(string sqlquery, OracleParameter[] parameters)
        {
            using (Connection)
            using (OracleCommand command = new OracleCommand(sqlquery, _connection))
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                DataTable dt = new DataTable();
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    dt.Load(reader);
                }
                return dt;
            }
        }

        public static void ExecuteNonQuery(string sqlquery, OracleParameter[] parameters)
        {
            using (Connection)
            using (OracleTransaction ot = Connection.BeginTransaction())
            using (OracleCommand command = new OracleCommand(sqlquery, _connection))
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                try
                {
                    command.ExecuteNonQuery();
                    ot.Commit();
                }
                catch (OracleException oe)
                {
                    Console.WriteLine(oe.Message);
                }
            }
        }


        public static bool CheckConnection()
        {
            try
            {
                OracleConnection con = Connection;
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}