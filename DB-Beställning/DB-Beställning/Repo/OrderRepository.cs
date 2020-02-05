using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Food;
using System;


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
        public async Task RemovePizzaFromOrder(int orderID, int pizzaID)
        {
            await connection.QueryAsync<Pizza>("\"RemovePizzaFromOrder\"", new { orderid = orderID, pizzaid = pizzaID }, commandType: CommandType.StoredProcedure);
        }
        public async Task RemovePastaFromOrder(int orderID, int pastaID)
        {
            await connection.QueryAsync<Pasta>("\"RemovePastaFromOrder\"", new { orderid = orderID, pastaid = pastaID }, commandType: CommandType.StoredProcedure);
        }
        public async Task RemoveSalladFromOrder(int orderID, int salladID)
        {
            await connection.QueryAsync<Sallad>("\"RemoveSalladFromOrder\"", new { orderid = orderID, salladid = salladID }, commandType: CommandType.StoredProcedure);
        }
        public async Task RemoveDrinkFromOrder(int orderID, int drinkID)
        {
            await connection.QueryAsync<Drink>("\"RemoveDrinkFromOrder\"", new { orderid = orderID, drinkid = drinkID }, commandType: CommandType.StoredProcedure);
        }
        public async Task RemoveExtraFromOrder(int orderID, int extraID)
        {
            await connection.QueryAsync<Extra>("\"RemoveExtraFromOrder\"", new { orderid = orderID, extraid = extraID }, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<Order>> CreateNewOrder()
        {
            IEnumerable<Order> order = (await connection.QueryAsync<Order>("\"CreateNewOrder\"", commandType: CommandType.StoredProcedure));
            return order;
        }
        public async Task AddPizzaToOrder(int orderID, int pizzaID)
        {
            await connection.QueryAsync<Pizza>("\"sp_OrderPizza\"", new { orderid = orderID, pizzaid = pizzaID }, commandType: CommandType.StoredProcedure);
        }
        public async Task UpdateOrderStatus(int orderID)
        {
            await connection.QueryAsync<Order>("\"UpdateOrderStatus\"", new { id = orderID }, commandType: CommandType.StoredProcedure);
        }
        public async Task AddPastaToOrder(int orderID, int pastaID)
        {
            await connection.QueryAsync<Pasta>("\"sp_OrderPasta\"", new { orderid = orderID, pastaid = pastaID }, commandType: CommandType.StoredProcedure);
        }
        public async Task AddSalladToOrder(int orderID, int salladID)
        {
            await connection.QueryAsync<Sallad>("\"sp_OrderSallad\"", new { orderid = orderID, salladid = salladID }, commandType: CommandType.StoredProcedure);
        }
        public async Task AddDrinkToOrder(int orderID, int drinkID)
        {
            await connection.QueryAsync<Drink>("\"sp_OrderDrink\"", new { orderid = orderID, drinkid = drinkID }, commandType: CommandType.StoredProcedure);
        }
        public async Task AddExtraToOrder(int orderID, int extraID)
        {
            await connection.QueryAsync<Extra>("\"sp_OrderExtra\"", new { orderid = orderID, extraid = extraID }, commandType: CommandType.StoredProcedure);
        }
        public async Task AddOrderToReceipt(int totalPrice, DateTime Date)
        {
            await connection.QueryAsync<Order>("\"AddOrderToReceipt\"", new { totalprice = totalPrice, date = Date }, commandType: CommandType.StoredProcedure);
        }
        public async Task<Pizza> GetPizza(int ID)
        {
            Pizza pizza = (await connection.QueryAsync<Pizza>("\"ShowPizzaByID\"", new { id = ID }, commandType: CommandType.StoredProcedure)).First();
            pizza.Ingredients = (await connection.QueryAsync<Ingredient>("\"ShowPizzaIngredientsByID\"", new { id = ID }, commandType: CommandType.StoredProcedure)).ToList();
            return pizza;
        }
        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            IEnumerable<Pizza> pizzas = await connection.QueryAsync<Pizza>("\"ShowPizzas\"", commandType: CommandType.StoredProcedure);
            foreach (Pizza pizza in pizzas)
            {
                pizza.Ingredients = (await connection.QueryAsync<Ingredient>("\"ShowPizzaIngredientsByID\"", new { id = pizza.ID }, commandType: CommandType.StoredProcedure)).ToList();
            }
            return pizzas;
        }
        public async Task<IEnumerable<Pizza>> ShowPizzaByID(int pizzaID)
        {
            IEnumerable<Pizza> pizza = await connection.QueryAsync<Pizza>("\"ShowPizzaByID\"", new { id = pizzaID }, commandType: CommandType.StoredProcedure);
            return pizza;
        }
        public async Task<IEnumerable<Pasta>> ShowPastaByID(int pastaID)
        {
            IEnumerable<Pasta> pasta = await connection.QueryAsync<Pasta>("\"ShowPastaByID\"", new { id = pastaID }, commandType: CommandType.StoredProcedure);
            return pasta;
        }
        public async Task<IEnumerable<Sallad>> ShowSalladByID(int salladID)
        {
            IEnumerable<Sallad> sallad = await connection.QueryAsync<Sallad>("\"ShowSalladByID\"", new { id = salladID }, commandType: CommandType.StoredProcedure);
            return sallad;
        }
        public async Task<IEnumerable<Drink>> ShowDrinkByID(int drinkID)
        {
            IEnumerable<Drink> drink = await connection.QueryAsync<Drink>("\"ShowDrinkByID\"", new { id = drinkID }, commandType: CommandType.StoredProcedure);
            return drink;
        }
        public async Task<IEnumerable<Extra>> ShowExtraByID(int extraID)
        {
            IEnumerable<Extra> extra = await connection.QueryAsync<Extra>("\"ShowExtraByID\"", new { id = extraID }, commandType: CommandType.StoredProcedure);
            return extra;
        }
        public async Task<IEnumerable<Order>> ShowOrderByID(int orderID)
        {
            IEnumerable<Order> orders = (await connection.QueryAsync<Order>("\"ShowOrderByID\"", new { inid = orderID }, commandType: CommandType.StoredProcedure)).ToList();
            foreach (Order order in orders)
            {
                order.pizza = (await connection.QueryAsync<Pizza>("\"GetOrderPizzas\"", new { inid = order.ID }, commandType: CommandType.StoredProcedure)).ToList();
                order.pasta = (await connection.QueryAsync<Pasta>("\"GetOrderPastas\"", new { inid = order.ID }, commandType: CommandType.StoredProcedure)).ToList();
                order.sallad = (await connection.QueryAsync<Sallad>("\"GetOrderSallads\"", new { inid = order.ID }, commandType: CommandType.StoredProcedure)).ToList();
                order.drink = (await connection.QueryAsync<Drink>("\"GetOrderDrinks\"", new { inid = order.ID }, commandType: CommandType.StoredProcedure)).ToList();
                order.extra = (await connection.QueryAsync<Extra>("\"GetOrderExtras\"", new { inid = order.ID }, commandType: CommandType.StoredProcedure)).ToList();
            }
            return orders;
        }
        // Slut Beställning

        // Interface
        public async Task AddPizzaAsync(string Name, int Price)
        {
            await connection.QueryAsync<Pizza>("\"AddPizza\"", new { name = Name, price = Price }, commandType: CommandType.StoredProcedure);
        }
        public async Task AddIngredientToPizzaAsync(int pizzaID, int[] ingridients)
        {
            foreach (var ingredient in ingridients)
            {
                await connection.QueryAsync<Pizza>("INSERT INTO \"PizzaIngredients\"(\"PizzaID\", \"IngredientsID\") VALUES (\"PizzaID\", \"IngredientID\")", new { pizzaid = pizzaID, ingredientid = ingredient });
            }
        }
        public async Task<IEnumerable<PizzaIngredient>> ShowPizzaAndIngredients()
        {
            IEnumerable<PizzaIngredient> pizzaIngredients = await connection.QueryAsync<PizzaIngredient>("\"ShowPizzaIngredients\"", commandType: CommandType.StoredProcedure);
            return pizzaIngredients;
        }
        public async Task<IEnumerable<Pizza>> ShowPizzasAsync()
        {
            IEnumerable<Pizza> pizzas = await connection.QueryAsync<Pizza>("\"ShowPizzas\"", commandType: CommandType.StoredProcedure);
            return pizzas;
        }
        public async Task<IEnumerable<Ingredient>> ShowIngredientsAsync()
        {
            IEnumerable<Ingredient> ingredients = await connection.QueryAsync<Ingredient>("\"ShowIngredients\"", commandType: CommandType.StoredProcedure);
            return ingredients;
        }
        public async Task<IEnumerable<Pasta>> ShowPastasAsync()
        {
            IEnumerable<Pasta> pastas = await connection.QueryAsync<Pasta>("\"ShowPastas\"", commandType: CommandType.StoredProcedure);
            return pastas;
        }
        public async Task<IEnumerable<Sallad>> ShowSalladsAsync()
        {
            IEnumerable<Sallad> sallads = await connection.QueryAsync<Sallad>("\"ShowSallads\"", commandType: CommandType.StoredProcedure);
            return sallads;
        }
        public async Task<IEnumerable<Drink>> ShowDrinksAsync()
        {
            IEnumerable<Drink> drinks = await connection.QueryAsync<Drink>("\"ShowDrinks\"", commandType: CommandType.StoredProcedure);
            return drinks;
        }
        public async Task<IEnumerable<Extra>> ShowExtraAsync()
        {
            IEnumerable<Extra> drinks = await connection.QueryAsync<Extra>("\"ShowExtras\"", commandType: CommandType.StoredProcedure);
            return drinks;
        }
    }
}
