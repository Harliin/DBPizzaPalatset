using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food;
using DB_Kock.Food;

namespace DB_Kock
{
    public class ChefRepository
    {
        private string ConnectionString { get; }
        private SqlConnection connection { get; }
        public ChefRepository()
        {
            ConnectionString = "Data Source=SQL6009.site4now.net;Initial Catalog=DB_A53DDD_Grupp1;User Id=DB_A53DDD_Grupp1_admin;Password=Password123;";
            connection = new SqlConnection(ConnectionString);
            connection.Open();
        }

        public async Task<IEnumerable<Order>> ShowOngoingOrder()
        {
            IEnumerable<Order> onGoingOrders = await connection.QueryAsync<Order>("ShowOngoingOrders", commandType: CommandType.StoredProcedure);
            return onGoingOrders;
        }

        public async Task<IEnumerable<Order>> ShowProcessingOrder()
        {
            IEnumerable<Order> processingOrders = await connection.QueryAsync<Order>("ShowProcessingOrder", commandType: CommandType.StoredProcedure);

            return processingOrders;
        }

        public async Task<IEnumerable<Order>> ShowFinshedOrders()
        {
            IEnumerable<Order> finishedOrders = await connection.QueryAsync<Order>("ShowFinshedOrders", commandType: CommandType.StoredProcedure);
            return finishedOrders;
        }

        public async Task<IEnumerable<OrderFood>> ShowOrders()
        {
            IEnumerable<OrderFood> order = await connection.QueryAsync<OrderFood>("ShowOrders", commandType: CommandType.StoredProcedure);
            return order;
        }


        //public async Task<IEnumerable<Pizza>> ShowPizzas()
        //{
        //    IEnumerable<Pizza> pizza = await connection.QueryAsync<Pizza>("GetPizzas", commandType: CommandType.StoredProcedure);
        //    return pizza;
        //}

        //public async Task<IEnumerable<Pasta>> ShowPastas()
        //{
        //    IEnumerable<Pasta> pasta = await connection.QueryAsync<Pasta>("GetPastas", commandType: CommandType.StoredProcedure);
        //    return pasta;
        //}

        //public async Task<IEnumerable<Sallad>> ShowSallads()
        //{
        //   IEnumerable<Sallad> sallad = await connection.QueryAsync<Sallad>("GetSallads", commandType: CommandType.StoredProcedure);
        //    return sallad;
        //}






    }
}
