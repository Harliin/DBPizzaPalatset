using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Food;
using System.Linq;
using static Food.Order;

namespace DB_Kock
{
    public class ChefRepository : IRepository
    {
        private string ConnectionString { get; }
        private SqlConnection connection { get; }
        //private SqlDataReader rdr { get; set; }
        //private SqlCommand cmd { get; set; }

        public ChefRepository()
        {
            ConnectionString = "Data Source=SQL6009.site4now.net;Initial Catalog=DB_A53DDD_Grupp1;User Id=DB_A53DDD_Grupp1_admin;Password=Password123;";
            connection = new SqlConnection(ConnectionString);
            connection.Open();
        }


        public async Task<IEnumerable<Order>> ShowOrderByStatus(eStatus status)
        {

            IEnumerable<Order> orders = await connection.QueryAsync<Order>("ShowOrderByStatus", new { STATUS = (int)status }, commandType: CommandType.StoredProcedure);
            foreach (Order order in orders)
            {
                order.pizza= (await connection.QueryAsync<Pizza>("GetOrderPizzas", new {id = order.ID }, commandType: CommandType.StoredProcedure)).ToList();
                order.pasta= (await connection.QueryAsync<Pasta>("GetOrderPastas", new { id = order.ID }, commandType: CommandType.StoredProcedure)).ToList();
                order.sallad = (await connection.QueryAsync<Sallad>("GetOrderSallads", new { id = order.ID }, commandType: CommandType.StoredProcedure)).ToList();
                order.drink = (await connection.QueryAsync<Drink>("GetOrderDrinks", new { id = order.ID }, commandType: CommandType.StoredProcedure)).ToList();
                order.extra = (await connection.QueryAsync<Extra>("GetOrderExtras", new { id = order.ID }, commandType: CommandType.StoredProcedure)).ToList();
            }
            return orders;
        }


        public async Task<IEnumerable<Order>> ShowOrderByID(int id)
        {

            IEnumerable<Order> orders = await connection.QueryAsync<Order>("ShowOrderByID", new { ID = id }, commandType: CommandType.StoredProcedure);
            foreach (Order order in orders)
            {
                order.pizza = (await connection.QueryAsync<Pizza>("GetOrderPizzas", new { id = order.ID }, commandType: CommandType.StoredProcedure)).ToList();
                order.pasta = (await connection.QueryAsync<Pasta>("GetOrderPastas", new { id = order.ID }, commandType: CommandType.StoredProcedure)).ToList();
                order.sallad = (await connection.QueryAsync<Sallad>("GetOrderSallads", new { id = order.ID }, commandType: CommandType.StoredProcedure)).ToList();
                order.drink = (await connection.QueryAsync<Drink>("GetOrderDrinks", new { id = order.ID }, commandType: CommandType.StoredProcedure)).ToList();
                order.extra = (await connection.QueryAsync<Extra>("GetOrderExtras", new { id = order.ID }, commandType: CommandType.StoredProcedure)).ToList();
            }
            return orders;
        }

        public async Task<IEnumerable<Order>> ShowFinishedOrderID()
        {
            IEnumerable<Order> orders = (await connection.QueryAsync<Order>("ShowFinishedOrderID", commandType: CommandType.StoredProcedure)).ToList();
            return orders;
        }


        public async Task UpdateOrderStatus(int id)
        {
            await connection.QueryAsync<Order>("UpdateOrderStatus", new { ID = id }, commandType: CommandType.StoredProcedure);
        }


        public async Task AddPizzaAsync(string name, int price)
        {
            await connection.QueryAsync<Pizza>("AddPizza",
                new { Name = name, Price = price }, commandType: CommandType.StoredProcedure);
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
