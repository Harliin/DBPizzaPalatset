using Dapper;
using DB_OrderInfo.Food;
using Food;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DB_OrderInfo
{
    public class OrderInfoRepository : IRepository
    {
        private string ConnectionString { get; }
        private SqlConnection connection { get; }
        public OrderInfoRepository()
        {
            ConnectionString = "Data Source=SQL6009.site4now.net;Initial Catalog=DB_A53DDD_Grupp1;User Id=DB_A53DDD_Grupp1_admin;Password=Password123;";
            connection = new SqlConnection(ConnectionString);
            connection.Open();
        }

        public async Task<IEnumerable<Order>> OngoingOrder()
        {
            IEnumerable<Order> ongoingOrder = (await connection.QueryAsync<Order>("DisplayOngoingOrder", commandType: CommandType.StoredProcedure));
            return ongoingOrder;
        }
        public async Task<IEnumerable<Order>> CompleteOrder()
        {
            IEnumerable<Order> completeOrder = (await connection.QueryAsync<Order>("DisplayCompleteOrder", commandType: CommandType.StoredProcedure));
            return completeOrder;
        }

        public Task AddIngredientToPizzaAsync(int pizzaID, int[] ingridients)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Drink>> ShowDrinksAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Extra>> ShowExtraAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Ingredient>> ShowIngredientsAsync()
        {
            throw new System.NotImplementedException();
        }

        //public Task<IEnumerable<OrderFood>> ShowOrderFood()
        //{
        //    throw new System.NotImplementedException();
        //}

        public Task<IEnumerable<Pasta>> ShowPastasAsync()
        {
            throw new System.NotImplementedException();
        }

        //public Task<IEnumerable<PizzaIngredient>> ShowPizzaAndIngredients()
        //{
        //    throw new System.NotImplementedException();
        //}

        public Task<IEnumerable<Pizza>> ShowPizzasAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Sallad>> ShowSalladsAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
