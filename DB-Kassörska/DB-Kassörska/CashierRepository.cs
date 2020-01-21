using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food;

namespace DB_Kassörska
{
    class CashierRepository
    {
        private string ConnectionString { get; }
        private SqlConnection Connection { get; }
        public CashierRepository()
        {
            ConnectionString = "Data Source=SQL6009.site4now.net;Initial Catalog=DB_A53DDD_Grupp1;User Id=DB_A53DDD_Grupp1_admin;Password=Password123;";
            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
        }

        public async Task<IEnumerable<Food.Order>> getOngoingOrders()
        {
            IEnumerable<Food.Order> ongoingOrders = (await Connection.QueryAsync<Food.Order>("getOngoingOrders", commandType: System.Data.CommandType.StoredProcedure));

            return ongoingOrders;
        }

        public async Task<IEnumerable<Food.Order>> GetFinishedOrders()
        {
            IEnumerable<Food.Order> finishedOrders = (await Connection.QueryAsync<Food.Order>("getFinishedOrders", commandType: System.Data.CommandType.StoredProcedure));

            return finishedOrders;
        }

        //public static void MarkOrderAsCollected()
        //{
        //    Console.WriteLine("Markerar order som uthämtad i DB...");
        //}
    }
}
