using Intercorp.CEFReports.Transversal.Common;
using System;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using MySqlConnector;

namespace Intercorp.CEFReports.Infrastructure.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetIBCefSqlConnection
        {
            get
            {
                var sqlconnection = new SqlConnection();
                if (sqlconnection == null) return null;

                sqlconnection.ConnectionString = _configuration.GetConnectionString("IBCefSqlConnection");
                sqlconnection.Open();
               
                return sqlconnection;
            }
        }
        public IDbConnection GetMysqlConnection
        {
            get
            {
                var mySqlConnection = new MySqlConnection();
                if (mySqlConnection == null) return null;
                mySqlConnection.ConnectionString = _configuration.GetConnectionString("MySqlConnection");
                mySqlConnection.Open();
               
                return mySqlConnection;
            }
        }
    }
}
