using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Tutorial7ADO.DataAccess
{
    public class DBConnection
    {
        public static SqlConnection GetConnection()
        {
            try
            {
                string str = ConfigurationManager.ConnectionStrings["DBCnnString"].ToString();
                SqlConnection con = new SqlConnection(str);
                con.Open();
                return con;
            }
            catch (Exception ce)
            {
                throw new ApplicationException("Unable to get DB Connection string from Config File. Contact Administrator" + ce);
            }
        }

        public static void Dispose(SqlConnection con)
        {
            try
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
                con.Dispose();
            }
            catch (Exception ce)
            {
                throw new ApplicationException("Unable to close the connection" + ce);
            }
        }
    }
}