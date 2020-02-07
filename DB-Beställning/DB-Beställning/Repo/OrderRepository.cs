using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Food;
using System;
using Npgsql;
using Newtonsoft.Json;


namespace DB_Beställning
{ 
    public class OrderRepository : IRepository
    {
        private string ConnectionString { get; }
        private IDbConnection connection { get; }
        public static int Backend { get; set; }
        public OrderRepository()
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
        // Beställnings Repositorys
        public async Task RemovePizzaFromOrder(int orderID, int pizzaID)
        {
            using (IDbConnection con = Connection)
            {
                await connection.QueryAsync<Pizza>("\"RemovePizzaFromOrder\"", new { orderid = orderID, pizzaid = pizzaID }, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task RemovePastaFromOrder(int orderID, int pastaID)
        {
            using (IDbConnection con = Connection)
            {
                await connection.QueryAsync<Pasta>("\"RemovePastaFromOrder\"", new { orderid = orderID, pastaid = pastaID }, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task RemoveSalladFromOrder(int orderID, int salladID)
        {
            using (IDbConnection con = Connection)
            {
                await connection.QueryAsync<Sallad>("\"RemoveSalladFromOrder\"", new { orderid = orderID, salladid = salladID }, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task RemoveDrinkFromOrder(int orderID, int drinkID)
        {
            using (IDbConnection con = Connection)
            {
                await connection.QueryAsync<Drink>("\"RemoveDrinkFromOrder\"", new { orderid = orderID, drinkid = drinkID }, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task RemoveExtraFromOrder(int orderID, int extraID)
        {
            using (IDbConnection con = Connection)
            {
                await connection.QueryAsync<Extra>("\"RemoveExtraFromOrder\"", new { orderid = orderID, extraid = extraID }, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<Order>> CreateNewOrder()
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Order> order = (await connection.QueryAsync<Order>("\"CreateNewOrder\"", commandType: CommandType.StoredProcedure));
                return order;
            }
        }
        public async Task AddPizzaToOrder(int orderID, int pizzaID)
        {
            using (IDbConnection con = Connection)
            {
                await connection.QueryAsync<Pizza>("\"sp_OrderPizza\"", new { orderid = orderID, pizzaid = pizzaID }, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task UpdateOrderStatus(int orderID)
        {
            using (IDbConnection con = Connection)
            {
                await connection.QueryAsync<Order>("\"UpdateOrderStatus\"", new { inid = orderID }, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task AddPastaToOrder(int orderID, int pastaID)
        {
            using (IDbConnection con = Connection)
            {
                await connection.QueryAsync<Pasta>("\"sp_OrderPasta\"", new { orderid = orderID, pastaid = pastaID }, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task AddSalladToOrder(int orderID, int salladID)
        {
            using (IDbConnection con = Connection)
            {
                await connection.QueryAsync<Sallad>("\"sp_OrderSallad\"", new { orderid = orderID, salladid = salladID }, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task AddDrinkToOrder(int orderID, int drinkID)
        {
            using (IDbConnection con = Connection)
            {
                await connection.QueryAsync<Drink>("\"sp_OrderDrink\"", new { orderid = orderID, drinkid = drinkID }, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task AddExtraToOrder(int orderID, int extraID)
        {
            using (IDbConnection con = Connection)
            {
                await connection.QueryAsync<Extra>("\"sp_OrderExtra\"", new { orderid = orderID, extraid = extraID }, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task AddOrderToReceipt( string Json, int totalPrice, DateTime Date)
        {
            using (IDbConnection con = Connection)
            {
                await connection.QueryAsync<Order>("\"AddOrderToReceipt\"", new { json = Json, totalprice = totalPrice, date = Date }, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<Pizza> GetPizza(int ID)
        {
            using (IDbConnection con = Connection)
            {
                Pizza pizza = (await connection.QueryAsync<Pizza>("\"ShowPizzaByID\"", new { id = ID }, commandType: CommandType.StoredProcedure)).First();
                pizza.Ingredients = (await connection.QueryAsync<Ingredient>("\"ShowPizzaIngredientsByID\"", new { id = ID }, commandType: CommandType.StoredProcedure)).ToList();
                return pizza;
            }
        }
        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Pizza> pizzas = await connection.QueryAsync<Pizza>("\"ShowPizzas\"", commandType: CommandType.StoredProcedure);
                foreach (Pizza pizza in pizzas)
                {
                    pizza.Ingredients = (await connection.QueryAsync<Ingredient>("\"ShowPizzaIngredientsByID\"", new { id = pizza.ID }, commandType: CommandType.StoredProcedure)).ToList();
                }
                return pizzas;
            }
        }
        public async Task<IEnumerable<Pizza>> ShowPizzaByID(int pizzaID)
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Pizza> pizza = await connection.QueryAsync<Pizza>("\"ShowPizzaByID\"", new { inid = pizzaID }, commandType: CommandType.StoredProcedure);
                return pizza;
            }
        }
        public async Task<IEnumerable<Pasta>> ShowPastaByID(int pastaID)
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Pasta> pasta = await connection.QueryAsync<Pasta>("\"ShowPastaByID\"", new { inid = pastaID }, commandType: CommandType.StoredProcedure);
                return pasta;
            }
        }
        public async Task<IEnumerable<Sallad>> ShowSalladByID(int salladID)
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Sallad> sallad = await connection.QueryAsync<Sallad>("\"ShowSalladByID\"", new { inid = salladID }, commandType: CommandType.StoredProcedure);
                return sallad;
            }
        }
        public async Task<IEnumerable<Drink>> ShowDrinkByID(int drinkID)
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Drink> drink = await connection.QueryAsync<Drink>("\"ShowDrinkByID\"", new { inid = drinkID }, commandType: CommandType.StoredProcedure);
                return drink;
            }
        }
        public async Task<IEnumerable<Extra>> ShowExtraByID(int extraID)
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Extra> extra = await connection.QueryAsync<Extra>("\"ShowExtraByID\"", new { inid = extraID }, commandType: CommandType.StoredProcedure);
                return extra;
            }
        }
        public async Task<IEnumerable<Order>> ShowOrderByID(int orderID)
        {
            using (IDbConnection con = Connection)
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
        }
        // Slut Beställning

        // Interface
        public async Task AddPizzaAsync(string Name, int Price)
        {
            using (IDbConnection con = Connection)
            {
                await connection.QueryAsync<Pizza>("\"AddPizza\"", new { name = Name, price = Price }, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task AddIngredientToPizzaAsync(int pizzaID, int[] ingridients)
        {
            using (IDbConnection con = Connection)
            {
                foreach (var ingredient in ingridients)
                {
                    await connection.QueryAsync<Pizza>("INSERT INTO \"PizzaIngredients\"(\"PizzaID\", \"IngredientsID\") VALUES (\"PizzaID\", \"IngredientID\")", new { pizzaid = pizzaID, ingredientid = ingredient });
                }
            }
        }
        public async Task<IEnumerable<PizzaIngredient>> ShowPizzaAndIngredients()
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<PizzaIngredient> pizzaIngredients = await connection.QueryAsync<PizzaIngredient>("\"ShowPizzaIngredients\"", commandType: CommandType.StoredProcedure);
                return pizzaIngredients;
            }
        }
        public async Task<IEnumerable<Pizza>> ShowPizzasAsync()
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Pizza> pizzas = await connection.QueryAsync<Pizza>("\"ShowPizzas\"", commandType: CommandType.StoredProcedure);
                return pizzas;
            }
        }
        public async Task<IEnumerable<Ingredient>> ShowIngredientsAsync()
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Ingredient> ingredients = await connection.QueryAsync<Ingredient>("\"ShowIngredients\"", commandType: CommandType.StoredProcedure);
                return ingredients;
            }
        }
        public async Task<IEnumerable<Pasta>> ShowPastasAsync()
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Pasta> pastas = await connection.QueryAsync<Pasta>("\"ShowPastas\"", commandType: CommandType.StoredProcedure);
                return pastas;
            }
        }
        public async Task<IEnumerable<Sallad>> ShowSalladsAsync()
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Sallad> sallads = await connection.QueryAsync<Sallad>("\"ShowSallads\"", commandType: CommandType.StoredProcedure);
                return sallads;
            }
        }
        public async Task<IEnumerable<Drink>> ShowDrinksAsync()
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Drink> drinks = await connection.QueryAsync<Drink>("\"ShowDrinks\"", commandType: CommandType.StoredProcedure);
                return drinks;
            }
        }
        public async Task<IEnumerable<Extra>> ShowExtraAsync()
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Extra> drinks = await connection.QueryAsync<Extra>("\"ShowExtras\"", commandType: CommandType.StoredProcedure);
                return drinks;
            }
        }
    }
}
