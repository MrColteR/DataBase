using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;


namespace VRA.DataAccess
{
    public class BaseDao
    {
        protected static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }
        protected static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["sqlconfig"].ConnectionString;
        }
    }
}
