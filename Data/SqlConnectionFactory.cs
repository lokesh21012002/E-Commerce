using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace MVC.Data
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {

        private readonly IConfiguration _configuration;

        public SqlConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public SqlConnection GetSqlConnection()
        {


            return new SqlConnection(
                _configuration.GetConnectionString("DefaultConnection");
                
            );


        }
    }
}