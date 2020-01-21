using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Beställning
{
    class OrderRepository
    {
        private string connectionString { get; }
        private SqlConnection connection { get; }

        public OrderRepository()
        {
            connectionString = "Data Source = SQL6009.site4now.net; Initial Catalog = DB_A53DDD_Grupp1; User Id = DB_A53DDD_Grupp1_admin; Password = Password123;";
            connection = new SqlConnection(connectionString);
            connection.Open();
        }
    }
}
