using Dapper;
using DB_OrderInfo.Food;
using Food;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DB_OrderInfo
{
    public class OrderInfoRepository : IRepository
    {
        private string ConnectionString { get; }
        private IDbConnection connection { get; }
        public static int Backend { get; set; }
        public OrderInfoRepository()
        {

            if (Backend == 1)//Backend == MSSQL
            {
                ConnectionString = "Data Source=SQL6009.site4now.net;Initial Catalog=DB_A53DDD_Grupp1;User Id=DB_A53DDD_Grupp1_admin;Password=Password123;";
                connection = new SqlConnection(ConnectionString);
                connection.Open();
            }
            else//Backend == PostgreSQL
            {
                ConnectionString = "Host=weboholics-demo.dyndns-ip.com;Port=5433;Username=grupp1;Password=grupp1;Database=grupp1";
                connection = new NpgsqlConnection(ConnectionString);
                connection.Open();
            }

        }
        private IDbConnection Connection
        {
            get
            {
                IDbConnection con;
                if (Backend == 1)
                {
                    con = new SqlConnection(ConnectionString);
                }
                else
                {
                    con = new NpgsqlConnection(ConnectionString);
                }
                con.Open();
                return con;
            }
        }


        public async Task<IEnumerable<Order>> OngoingOrder()
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Order> ongoingOrder = (await connection.QueryAsync<Order>("\"DisplayOngoingOrder\"", commandType: CommandType.StoredProcedure));
                return ongoingOrder;
            }
        }
        public async Task<IEnumerable<Order>> CompleteOrder()
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Order> completeOrder = (await connection.QueryAsync<Order>("\"DisplayCompleteOrder\"", commandType: CommandType.StoredProcedure));
                return completeOrder;
            }
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
