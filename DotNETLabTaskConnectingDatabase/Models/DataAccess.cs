using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DotNETLabTaskConnectingDatabase.Models
{
    public class DataAccess
    {
        SqlConnection connection;
        SqlCommand command;

        public DataAccess()
        {
            //this.connection = new SqlConnection("");
            //this.connection.Open();

            this.connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PDB"].ConnectionString);
            this.connection.Open();
        }

        public SqlDataReader GetData(string sql)
        {
            this.command = new SqlCommand(sql, connection);
            return this.command.ExecuteReader();
        }

        public int ExecuteQuery(string sql)
        {
            this.command = new SqlCommand(sql, connection);
            return this.command.ExecuteNonQuery();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
            this.connection.Close();
        }
    }
}