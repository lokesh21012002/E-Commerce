using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace MVC.Data
{
    public interface ISqlConnectionFactory
    {

        SqlConnection GetSqlConnection();


    }
}