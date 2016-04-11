using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
//using System.Configuration;

namespace ICT4Participation.Classes.Database
{
    public static class DatabaseManager
    {
        private static OracleConnection _connection;

        private static OracleConnection Connection
        {
            get
            {
                try
                {
                    // _connection = new OracleConnection(ConfigurationManager.ConnectionStrings["DBC"].ConnectionString);
                    _connection = new OracleConnection("Data Source = 192.168.20.37; Persist Security Info = true; User Id = PTS37; Password = PTS37;");
                    _connection.Open();
                    return _connection;
                }
                catch (Exception ex)
                {
                    //TODO: implementeer functie voor als de database geen connectie kan maken.
                }
                return null;
            }
        }

        public static DataTable ExecuteReadQuery(string sqlquery, OracleParameter[] parameters)
        {
            using (Connection)
            using (OracleCommand command = new OracleCommand(sqlquery, Connection))
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

        public static void ExecuteInsertQuery(string sqlquery, OracleParameter[] parameters)
        {
            OracleConnection connection = Connection;
            OracleTransaction transaction = connection.BeginTransaction();
            OracleCommand command = new OracleCommand(sqlquery, connection);

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            try
            {
                command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (OracleException oe)
            {
                Console.WriteLine(oe.Message);
            }
            connection.Close();
        }

        public static void ExecuteDeleteQuery(string sqlquery, OracleParameter[] parameters)
        {
            using (Connection)
            using (OracleTransaction ot = Connection.BeginTransaction())
            {
                OracleCommand command = new OracleCommand(sqlquery, _connection);
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
