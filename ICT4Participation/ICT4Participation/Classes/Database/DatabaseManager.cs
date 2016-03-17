using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Windows.Forms;

namespace ICT4Participation.Classes.Database
{
    public static class DatabaseManager
    {
        private static OracleConnection _connection;
        public static OracleConnection Connection
        {
            get
            {
                try
                {
                    _connection = new OracleConnection(ConfigurationManager.ConnectionStrings["DBC"].ConnectionString);
                    _connection.Open();
                    return _connection;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("De applicatie kan geen verbinding maken met de database.Neem contact op met een systeembeheerder." + Environment.NewLine + Environment.NewLine + ex.Message);
                    Environment.Exit(0);
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
                DataTable DT = new DataTable();
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    DT.Load(reader);
                }
                return DT;
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
            catch (OracleException OE)
            {
                Console.WriteLine(OE.Message);
            }
            connection.Close();
        }

        public static void ExecuteDeleteQuery(string sqlquery, OracleParameter[] parameters)
        {
            using (Connection)
            using (OracleTransaction OT = Connection.BeginTransaction())
            {
                OracleCommand command = new OracleCommand(sqlquery, _connection);
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                try
                {
                    command.ExecuteNonQuery();
                    OT.Commit();
                }
                catch (OracleException OE)
                {
                    Console.WriteLine(OE.Message);
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
