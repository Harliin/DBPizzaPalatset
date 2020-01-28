using Dapper;
using DB_OrderInfo.Food;
using Food;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DB_OrderInfo
{
    class OrderInfoRepository
    {
        private string ConnectionString { get; }
        private SqlConnection Connection { get; }
        public OrderInfoRepository()
        {
            ConnectionString = "Data Source=SQL6009.site4now.net;Initial Catalog=DB_A53DDD_Grupp1;User Id=DB_A53DDD_Grupp1_admin;Password=Password123;";
            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
        }
        public async Task<IEnumerable<Pizza>> Pizzas()
        {
            IEnumerable<Pizza> pizzas = (await Connection.QueryAsync<Pizza>("GetPizzas", commandType: CommandType.StoredProcedure));
            return pizzas;
        }
        public async Task<IEnumerable<Order>> OngoingOrder()
        {
            IEnumerable<Order> ongoingOrder = (await Connection.QueryAsync<Order>("ShowOngoingOrders", commandType: CommandType.StoredProcedure));
            return ongoingOrder;
        }
        public async Task<IEnumerable<Order>> CompleteOrder()
        {
            IEnumerable<Order> completeOrder = (await Connection.QueryAsync<Order>("GetFinishedOrders", commandType: CommandType.StoredProcedure));
            return completeOrder;
        }
    }
}
