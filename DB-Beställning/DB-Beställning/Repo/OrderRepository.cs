using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Food;

namespace DB_Beställning
{
    public class OrderRepository : IRepository
    {
        private string ConnectionString { get; }
        private SqlConnection connection { get; }
        public OrderRepository()
        {
            ConnectionString = "Data Source=SQL6009.site4now.net;Initial Catalog=DB_A53DDD_Grupp1;User Id=DB_A53DDD_Grupp1_admin;Password=Password123;";
            connection = new SqlConnection(ConnectionString);
            connection.Open();
        }

        public async Task AddPizzaToOrder(int order, int id)
        {
            await connection.QueryAsync("AddPizzaToOrder", new {OrderID = order, PizzaID = id}, commandType: CommandType.StoredProcedure);
        }
        public async Task AddPastaToOrder(int order, int id)
        {
            await connection.QueryAsync("AddPastaToOrder", new { OrderID = order, PastaID = id }, commandType: CommandType.StoredProcedure);
        }
        public async Task AddSalladToOrder(int order, int id)
        {
            await connection.QueryAsync("AddSalladToOrder", new { OrderID = order, PastaID = id }, commandType: CommandType.StoredProcedure);
        }
        public async Task AddDrinkToOrder(int order, int id)
        {
            await connection.QueryAsync("AddDrinkToOrder", new { OrderID = order, DrinkID = id }, commandType: CommandType.StoredProcedure);
        }
        public async Task AddExtraToOrder(int order, int id)
        {
            await connection.QueryAsync("AddExtraToOrder", new { OrderID = order, ExtraID = id }, commandType: CommandType.StoredProcedure);
        }
        public async Task AddPizzaAsync(string name, int price)
        {
            await connection.QueryAsync<Pizza>("AddPizza",new { Name = name, Price = price }, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<Pizza>> ShowPizzaByID(int pizzaID)
        {
            IEnumerable<Pizza> pizza = await connection.QueryAsync<Pizza>("ShowPizzaByID", new { @ID = pizzaID }, commandType: CommandType.StoredProcedure);
            return pizza;
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
            IEnumerable<Pizza> pizzas = await connection.QueryAsync<Pizza>("ShowPizzas", commandType: CommandType.StoredProcedure);
            return pizzas;
        }
        public async Task<IEnumerable<Ingredient>> ShowIngredientsAsync()
        {
            IEnumerable<Ingredient> ingredients = await connection.QueryAsync<Ingredient>("ShowIngredients", commandType: CommandType.StoredProcedure);
            return ingredients;
        }

        public async Task<IEnumerable<Pasta>> ShowPastasAsync()
        {
            IEnumerable<Pasta> pastas = await connection.QueryAsync<Pasta>("ShowPastas", commandType: CommandType.StoredProcedure);
            return pastas;
        }

        public async Task<IEnumerable<Sallad>> ShowSalladsAsync()
        {
            IEnumerable<Sallad> sallads = await connection.QueryAsync<Sallad>("ShowSallads", commandType: CommandType.StoredProcedure);
            return sallads;
        }

        public async Task<IEnumerable<Drink>> ShowDrinksAsync()
        {
            IEnumerable<Drink> drinks = await connection.QueryAsync<Drink>("ShowDrinks", commandType: CommandType.StoredProcedure);
            return drinks;
        }
        public async Task<IEnumerable<Extra>> ShowExtraAsync()
        {
            IEnumerable<Extra> drinks = await connection.QueryAsync<Extra>("ShowExtras", commandType: CommandType.StoredProcedure);
            return drinks;
        }

    }
}
