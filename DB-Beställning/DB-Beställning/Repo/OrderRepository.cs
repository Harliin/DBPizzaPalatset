using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
        // Beställnings Repositorys

        public async Task<IEnumerable<Order>> CreateNewOrder()
        {
            IEnumerable<Order> order = (await connection.QueryAsync<Order>("CreateNewOrder", commandType: CommandType.StoredProcedure));
            return order;
        }
        public async Task AddPizzaToOrder(int orderID, int pizzaID)
        {
            await connection.QueryAsync<Pizza>("sp_OrderPizza", new { OrderID = orderID, PizzaID = pizzaID }, commandType: CommandType.StoredProcedure);
        }
        public async Task AddPastaToOrder(int orderID, int pastaID)
        {
            await connection.QueryAsync<Pasta>("sp_OrderPasta", new { OrderID = orderID, PastaID = pastaID }, commandType: CommandType.StoredProcedure);
        }
        public async Task AddSalladToOrder(int orderID, int salladID)
        {
            await connection.QueryAsync<Sallad>("sp_OrderSallad", new { OrderID = orderID, SalladID = salladID }, commandType: CommandType.StoredProcedure);
        }
        public async Task AddDrinkToOrder(int orderID, int drinkID)
        {
            await connection.QueryAsync<Drink>("sp_OrderDrink", new { OrderID = orderID, DrinkID = drinkID }, commandType: CommandType.StoredProcedure);
        }
        public async Task AddExtraToOrder(int orderID, int extraID)
        {
            await connection.QueryAsync<Extra>("sp_OrderExtra", new { OrderID = orderID, ExtraID = extraID }, commandType: CommandType.StoredProcedure);
        }
        public async Task<Pizza> GetPizza(int id)
        {
            Pizza pizza = (await connection.QueryAsync<Pizza>("ShowPizzaByID", new { ID = id }, commandType: CommandType.StoredProcedure)).First();
            pizza.Ingredients = (await connection.QueryAsync<Ingredient>("ShowPizzaIngredientsByID", new { ID = id }, commandType: CommandType.StoredProcedure)).ToList();
            return pizza;
        }
        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            IEnumerable<Pizza> pizzas = await connection.QueryAsync<Pizza>("ShowPizzas", commandType: CommandType.StoredProcedure);
            foreach (Pizza pizza in pizzas)
            {
                pizza.Ingredients = (await connection.QueryAsync<Ingredient>("ShowPizzaIngredientsByID", new { ID = pizza.ID }, commandType: CommandType.StoredProcedure)).ToList();
            }
            return pizzas;
        }
        public async Task<IEnumerable<Pizza>> ShowPizzaByID(int pizzaID)
        {
            IEnumerable<Pizza> pizza = await connection.QueryAsync<Pizza>("ShowPizzaByID", new { ID = pizzaID }, commandType: CommandType.StoredProcedure);
            return pizza;
        }
        public async Task<IEnumerable<Pasta>> ShowPastaByID(int pastaID)
        {
            IEnumerable<Pasta> pasta = await connection.QueryAsync<Pasta>("ShowPastaByID", new { ID = pastaID }, commandType: CommandType.StoredProcedure);
            return pasta;
        }
        public async Task<IEnumerable<Sallad>> ShowSalladByID(int salladID)
        {
            IEnumerable<Sallad> sallad = await connection.QueryAsync<Sallad>("ShowSalladByID", new { ID = salladID }, commandType: CommandType.StoredProcedure);
            return sallad;
        }
        public async Task<IEnumerable<Drink>> ShowDrinkByID(int drinkID)
        {
            IEnumerable<Drink> drink = await connection.QueryAsync<Drink>("ShowDrinkByID", new { ID = drinkID }, commandType: CommandType.StoredProcedure);
            return drink;
        }
        public async Task<IEnumerable<Extra>> ShowExtraByID(int extraID)
        {
            IEnumerable<Extra> extra = await connection.QueryAsync<Extra>("ShowExtraByID", new { ID = extraID }, commandType: CommandType.StoredProcedure);
            return extra;
        }
        // Slut Beställning

        // Interface
        public async Task AddPizzaAsync(string name, int price)
        {
            await connection.QueryAsync<Pizza>("AddPizza", new { Name = name, Price = price }, commandType: CommandType.StoredProcedure);
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
