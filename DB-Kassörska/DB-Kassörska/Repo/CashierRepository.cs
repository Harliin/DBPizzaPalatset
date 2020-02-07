using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Food;
using static DB_Kassörska.Order;
using Npgsql;

namespace DB_Kassörska
{
    public class CashierRepository : IRepository
    {
        private string ConnectionString { get; }
        private SqlConnection connection { get; }
        
        public static int Backend { get; set; }
        public CashierRepository()
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

        public async Task<IEnumerable<Order>> ShowOrderByStatusAsync(eStatus status)
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Order> orders = await connection.QueryAsync<Order>("ShowOrderByStatus", new { STATUS = (int)status }, commandType: CommandType.StoredProcedure);
                //foreach (Order order in orders)
                //{
                //    order.pizza = (await connection.QueryAsync<Pizza>("GetOrderPizzas", new { id = order.ID }, commandType: CommandType.StoredProcedure)).ToList();
                //    order.pasta = (await connection.QueryAsync<Pasta>("GetOrderPastas", new { id = order.ID }, commandType: CommandType.StoredProcedure)).ToList();
                //    order.sallad = (await connection.QueryAsync<Sallad>("GetOrderSallads", new { id = order.ID }, commandType: CommandType.StoredProcedure)).ToList();
                //    order.drink = (await connection.QueryAsync<Drink>("GetOrderDrinks", new { id = order.ID }, commandType: CommandType.StoredProcedure)).ToList();
                //    order.extra = (await connection.QueryAsync<Extra>("GetOrderExtras", new { id = order.ID }, commandType: CommandType.StoredProcedure)).ToList();
                //}
                return orders;
            }
        }
        public async Task UpdateOrderStatus(int orderNumber) //Uppdatera orderns status
        {
            using (IDbConnection con = Connection)
            {
                await connection.QueryAsync<Pizza>("UpdateOrderStatus",
                new { @ID = orderNumber }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteOrder(int orderNumber)
        {
            using (IDbConnection con = Connection)
            {
               await connection.QueryAsync<Pizza>("DeleteOrder",
               new { @ID = orderNumber }, commandType: CommandType.StoredProcedure);
            }    
        }
        public async Task<IEnumerable<Order>> ShowAllOrdersAsync()
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Order> allOrders = (await connection.QueryAsync<Order>("ShowOrders", commandType: CommandType.StoredProcedure));
                return allOrders;
            }
                
        } //Visa alla ordrar

        public async Task<IEnumerable<Order>> ShowOrderByIDAsync(int orderNumber) //Visa ordrar baserat på ID
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Order> ongoingOrders = (await connection.QueryAsync<Order>("ShowOrderByID", new { @ID = orderNumber }, commandType: CommandType.StoredProcedure));
                return ongoingOrders;
            }
        }

        public async Task AddPizzaAsync(string name, int price) //Lägg till pizza
        {
            using (IDbConnection con = Connection)
            {
                await connection.QueryAsync<Pizza>("AddPizza",
                new { Name = name, Price = price }, commandType: CommandType.StoredProcedure);
            }
                
        }
        public async Task AddIngredientToPizzaAsync(int pizzaID, int[] ingridients) //Lägg till ingrediens till pizza
        {
            using (IDbConnection con = Connection)
            {
                foreach (var ingredient in ingridients)
                {
                    await connection.QueryAsync<Pizza>("INSERT INTO PizzaIngredients(PizzaID, IngredientsID) VALUES (@PizzaID, @IngredientID)", new { PizzaID = pizzaID, IngredientID = ingredient });
                }
            }
        }
        public async Task<IEnumerable<PizzaIngredient>> ShowPizzaAndIngredients() //Visa pizzans ingredienser
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<PizzaIngredient> pizzaIngredients = await connection.QueryAsync<PizzaIngredient>("ShowPizzaIngredients", commandType: CommandType.StoredProcedure);
                return pizzaIngredients;
            }
                
        }
        public async Task<IEnumerable<Pizza>> ShowPizzasAsync() //Visa vilka pizzor som finns att köpa
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Pizza> pizzas = await connection.QueryAsync<Pizza>("GetPizzas", commandType: CommandType.StoredProcedure);
                return pizzas;
            }
                
        }
        public async Task<IEnumerable<Ingredient>> ShowIngredientsAsync() //Visa vilka ingredienser som finns att använda
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Ingredient> ingredients = await connection.QueryAsync<Ingredient>("GetIngredients", commandType: CommandType.StoredProcedure);
                return ingredients;
            }
                
        }
        public async Task<IEnumerable<Pasta>> ShowPastasAsync() //Visa vilka pastor som finns att köpa
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Pasta> pastas = await connection.QueryAsync<Pasta>("GetPastas", commandType: CommandType.StoredProcedure);
                return pastas;
            }
                
        }
        public async Task<IEnumerable<Sallad>> ShowSalladsAsync() //Visa vilka sallader som finns att köpa
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Sallad> sallads = await connection.QueryAsync<Sallad>("GetSallads", commandType: CommandType.StoredProcedure);
                return sallads;
            }
                
        }
        public async Task<IEnumerable<Drink>> ShowDrinksAsync() //Visa vilka drycker som finns att köpa
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Drink> drinks = await connection.QueryAsync<Drink>("GetDrinks", commandType: CommandType.StoredProcedure);
                return drinks;
            }
                
        }
        public async Task<IEnumerable<Extra>> ShowExtraAsync() //Visa vilka tillägg som finns att köpa
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Extra> drinks = await connection.QueryAsync<Extra>("GetExtras", commandType: CommandType.StoredProcedure);
                return drinks;
            }
                
        }
    } 
}
