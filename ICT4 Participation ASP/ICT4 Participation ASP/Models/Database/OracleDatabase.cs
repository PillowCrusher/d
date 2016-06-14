using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;

//using System.Configuration;

namespace ICT4_Participation_ASP.Models.Database
{
    public class OracleDatabase : Repository
    {
        private OracleConnection _connection;

        private OracleConnection Connection
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

        private OracleParameter[] MakeParameters(List<object> parameterlist)
        {
            if (parameterlist != null)
            {
                OracleParameter[] parameters = new OracleParameter[parameterlist.Count];
                int i = 0;
                string index = "p";

                foreach (object o in parameterlist)
                {
                    parameters[i] = new OracleParameter(index, o);
                    index += "p";
                    i++;
                }
                return parameters;
            }
            return null;
        }

        /// <summary>
        /// Execute the query in the database and get the database table back
        /// </summary>
        /// <param name="sqlQuery"> Query string </param>
        /// <param name="parameterlist"> list of objects that will be converted into oracleparameters </param>
        /// <returns></returns>
        public DataTable ExecuteReadQuery(List<object> parameterlist, string sqlQuery)
        {
            OracleParameter[] parameters = MakeParameters(parameterlist);

            using (OracleConnection connection = Connection)
            {
                OracleCommand command = new OracleCommand(sqlQuery, connection);

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

        /// <summary>
        /// execute the non-query
        /// </summary>
        /// <param name="sqlQuery"> query string </param>
        /// <param name="parameters"> oracle parameters </param>
        public void ExecuteNonQuery(List<object> parameterlist, string sqlQuery)
        {
            OracleParameter[] parameters = MakeParameters(parameterlist);

            using (OracleConnection connection = Connection)
            {
                OracleCommand command = new OracleCommand(sqlQuery, connection);

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                command.ExecuteNonQuery();
            }
        }

        public object ExecuteSqlFunction(List<object> parameterlist, string function)
        {
            OracleParameter[] parameters = MakeParameters(parameterlist);

            using (OracleConnection connection = Connection)
            {
                OracleCommand command = new OracleCommand(function, connection);
                command.CommandType = CommandType.StoredProcedure;
                
                command.Parameters.Add("return", OracleDbType.NVarchar2, 32767);
                command.Parameters["return"].Direction = ParameterDirection.ReturnValue;

                /*
                command.Parameters.Add("p_Username", OracleDbType.NVarchar2);
                command.Parameters["p_Username"].Value = "Henkie";

                command.Parameters.Add("p_Password", OracleDbType.NVarchar2);
                command.Parameters["p_Password"].Value = "henkerd";
                */

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                command.ExecuteNonQuery();

                return command.Parameters["return"].Value;
            }
        }

        public bool CheckConnection()
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