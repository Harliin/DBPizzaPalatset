using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Food;
using Repo;

namespace DB_Kassörska
{
    public class CashierRepository : IRepository
    {
        private string ConnectionString { get; }
        private SqlConnection connection { get; }
        public CashierRepository()
        {
            ConnectionString = "Data Source=SQL6009.site4now.net;Initial Catalog=DB_A53DDD_Grupp1;User Id=DB_A53DDD_Grupp1_admin;Password=Password123;";
            connection = new SqlConnection(ConnectionString);
            connection.Open();
        }

        public async Task<IEnumerable<Order>> ShowOngoingOrdersAsync()
        {
            IEnumerable<Order> ongoingOrders = (await Connection.QueryAsync<Order>("showOrders", commandType: CommandType.StoredProcedure));

            return ongoingOrders;
        }

        public async Task<IEnumerable<Order>> ShowFinishedOrdersAsync()
        {
            IEnumerable<Order> finishedOrders = (await Connection.QueryAsync<Order>("showFinishedOrders", commandType: CommandType.StoredProcedure));

            return finishedOrders;
        }

        public async Task DeleteOrder(int orderNumber)
        {
            var deleteOrder = (await Connection.QueryAsync<Order>("deleteOrder", new { @ID = orderNumber }, commandType: CommandType.StoredProcedure));
        }
    }

    public async Task AddPizzaAsync(string name, int price)
        {
            await connection.QueryAsync<Pizza>("AddPizza",
                new { Name = name, Price = price }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<OrderFood>> ShowOrderFood()
        {
            IEnumerable<OrderFood> orderFoods = await connection.QueryAsync<OrderFood>("ShowOrders", commandType: CommandType.StoredProcedure);
            return orderFoods;
        }

        public async Task AddIngredientToPizzaAsync(int pizzaID, int[] ingridients)
        {
            foreach (var ingredient in ingridients)
            {
                await connection.QueryAsync<Pizza>("INSERT INTO PizzaIngredients(PizzaID, IngredientsID) VALUES (@PizzaID, @IngredientID)", new { PizzaID = pizzaID, IngredientID = ingredient });
            }
        }
        public async Task<IEnumerable<PizzaIngredient>> ShowPizzaAndIngredients()
        {
            IEnumerable<PizzaIngredient> pizzaIngredients = await connection.QueryAsync<PizzaIngredient>("ShowPizzaIngredients", commandType: CommandType.StoredProcedure);
            return pizzaIngredients;
        }
        public async Task<IEnumerable<Pizza>> ShowPizzasAsync()
        {
            IEnumerable<Pizza> pizzas = await connection.QueryAsync<Pizza>("GetPizzas", commandType: CommandType.StoredProcedure);
            return pizzas;
        }
        public async Task<IEnumerable<Ingredient>> ShowIngredientsAsync()
        {
            IEnumerable<Ingredient> ingredients = await connection.QueryAsync<Ingredient>("GetIngredients", commandType: CommandType.StoredProcedure);
            return ingredients;
        }

        public async Task<IEnumerable<Pasta>> ShowPastasAsync()
        {
            IEnumerable<Pasta> pastas = await connection.QueryAsync<Pasta>("GetPastas", commandType: CommandType.StoredProcedure);
            return pastas;
        }

        public async Task<IEnumerable<Sallad>> ShowSalladsAsync()
        {
            IEnumerable<Sallad> sallads = await connection.QueryAsync<Sallad>("GetSallads", commandType: CommandType.StoredProcedure);
            return sallads;
        }

        public async Task<IEnumerable<Drink>> ShowDrinksAsync()
        {
            IEnumerable<Drink> drinks = await connection.QueryAsync<Drink>("GetDrinks", commandType: CommandType.StoredProcedure);
            return drinks;
        }
        public async Task<IEnumerable<Extra>> ShowExtraAsync()
        {
            IEnumerable<Extra> drinks = await connection.QueryAsync<Extra>("GetExtras", commandType: CommandType.StoredProcedure);
            return drinks;
        }

    }
}
