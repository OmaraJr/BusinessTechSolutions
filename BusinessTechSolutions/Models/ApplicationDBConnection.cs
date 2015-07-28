using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BusinessTechSolutions.Models
{
    public class ApplicationDBConnection
    {
        private string _connectionString;
        public ApplicationDBConnection()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            Connection = new System.Data.SqlClient.SqlConnection(_connectionString);
        }
        public ApplicationDBConnection(string connectionString)
        {
            if (connectionString == null) throw new ArgumentNullException("connectionString");
            _connectionString = connectionString;
            Connection = new SqlConnection(_connectionString);

        }
        public SqlConnection Connection { get; set; }
    }
}