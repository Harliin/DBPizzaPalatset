﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DB_Kock
{
    class ChefRepository
    {
        private string ConnectionString { get; }
        private SqlConnection connection { get; }
        public ChefRepository()
        {
            ConnectionString = "Data Source=SQL6009.site4now.net;Initial Catalog=DB_A53DDD_Grupp1;User Id=DB_A53DDD_Grupp1_admin;Password=Password123;";
            connection = new SqlConnection(ConnectionString);
            connection.Open();
        }
    }
}
