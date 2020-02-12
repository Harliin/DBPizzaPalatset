using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Food;
using Npgsql;

namespace DB_Admin
{
    public class AdminRepository : IRepository, IDisposable
    {
        private string ConnectionString { get; }
        private IDbConnection connection { get; }
        public static int Backend { get; set; }

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

        public AdminRepository()
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
        //Admin specifik

            //Add procedures
                public async Task AddPizzaAsync(string name, int Price)
                {
                    using (IDbConnection con = Connection)
                    {
                        await connection.QueryAsync<Pizza>("\"AddPizza\"",
                        new { name1 = name, price = Price }, commandType: CommandType.StoredProcedure);
                    }
                }
                public async Task AddPastaAsync(string name, int Price)
                {
                    using (IDbConnection con = Connection)
                    {
                        await connection.QueryAsync<Pasta>("\"AddPasta\"",
                        new { name1 = name, price = Price }, commandType: CommandType.StoredProcedure);
                    }
                }
                public async Task AddSalladAsync(string name, int Price)
                {
                    using (IDbConnection con = Connection)
                    {
                        await connection.QueryAsync<Sallad>("\"AddSallad\"",
                        new { name1 = name, price = Price }, commandType: CommandType.StoredProcedure);
                    }
                }
                public async Task AddDrinkAsync(string name, int Price)
                {
                    using (IDbConnection con = Connection)
                    {
                        await connection.QueryAsync<Drink>("\"AddDrink\"",
                        new { name1 = name, price = Price }, commandType: CommandType.StoredProcedure);
                    }
                }
                public async Task AddExtraAsync(string name, int Price)
                {
                    using (IDbConnection con = Connection)
                    {
                        await connection.QueryAsync<Extra>("\"AddExtra\"",
                        new { name1 = name, price = Price }, commandType: CommandType.StoredProcedure);
                    }
                }
                public async Task AddEmployee(string name, string Password, int eType)
                {
                    using (IDbConnection con = Connection)
                    {
                        await connection.QueryAsync<Employee>("\"AddEmployee\"",
                        new { name1 = name, password = Password, employeetype = eType }, commandType: CommandType.StoredProcedure);
                    }
                }
            //Slut Add Procedures

            //Delete procedures
                public async Task DeletePizzaAsync(int pizzaID)
                {
                    using (IDbConnection con = Connection)
                    {
                        await connection.QueryAsync<Pizza>("\"DeletePizza\"",
                        new { inid = pizzaID }, commandType: CommandType.StoredProcedure);
                    }
                }
                public async Task DeletePastaAsync(int pastaID)
                {
                    using (IDbConnection con = Connection)
                    {
                        await connection.QueryAsync<Pasta>("\"DeletePasta\"",
                        new { inid = pastaID }, commandType: CommandType.StoredProcedure);
                    }
                }
                public async Task DeleteSalladAsync(int salladID)
                {
                    using (IDbConnection con = Connection)
                    {
                        await connection.QueryAsync<Sallad>("\"DeleteSallad\"",
                        new { inid = salladID }, commandType: CommandType.StoredProcedure);
                    }
                }
                public async Task DeleteDrinkAsync(int drinkID)
                {
                    using (IDbConnection con = Connection)
                    {
                        await connection.QueryAsync<Drink>("\"DeleteDrink\"",
                        new { inid = drinkID }, commandType: CommandType.StoredProcedure);
                    }
                }
                public async Task DeleteExtraAsync(int ExtraID)
                {
                    using (IDbConnection con = Connection)
                    {
                        await connection.QueryAsync<Extra>("\"DeleteSallad\"",
                        new { inid = ExtraID }, commandType: CommandType.StoredProcedure);
                    }
                }
                public async Task DeleteEmployee(int employeeID)
                {
                    using (IDbConnection con = Connection)
                    {
                        await connection.QueryAsync<Employee>("\"DeleteEmployee\"",
                        new { inid = employeeID }, commandType: CommandType.StoredProcedure);
                    }
                }
            //Slut Delete procedures

            public async Task<IEnumerable<Employee>> ShowEmployees()
            {
                using (IDbConnection con = Connection)
                {
                    IEnumerable<Employee> employees = await connection.QueryAsync<Employee>("\"ShowEmployees\"", commandType: CommandType.StoredProcedure);
                    return employees;
                }
            }

        public async Task<IEnumerable<Employee>> GetAdmins(string userName, string password)
        {
            using (IDbConnection con = Connection)
            {
                IEnumerable<Employee> admin = await connection.QueryAsync<Employee>("\"GetAdmins\"", new { username = userName, passcode = password }, commandType: CommandType.StoredProcedure);
                return admin;
            }
        }

        //Slut admin specifik



        //Från interface

            //Show Procedures
                public async Task<IEnumerable<OrderFood>> ShowOrderFood()
                {
                    using (IDbConnection con = Connection)
                    {
                        IEnumerable<OrderFood> orderFoods = await connection.QueryAsync<OrderFood>("\"ShowOrders\"", commandType: CommandType.StoredProcedure);
                        return orderFoods;
                    }
                }
                public async Task<Pizza> GetPizza(int id)
                {
                    using (IDbConnection con = Connection)
                    {
                        Pizza pizza = (await connection.QueryAsync<Pizza>("\"ShowPizzaByID\"", new { inid = id }, commandType: CommandType.StoredProcedure)).First();
                        pizza.Ingredients = (await connection.QueryAsync<Ingredient>("\"ShowPizzaIngredientsByID\"", new { inid = id }, commandType: CommandType.StoredProcedure)).ToList();
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
                            pizza.Ingredients = (await connection.QueryAsync<Ingredient>("\"ShowPizzaIngredientsByID\"", new { inid = pizza.ID }, commandType: CommandType.StoredProcedure)).ToList();
                        }
                        return pizzas;
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
        //Slut Show Procedures

        public async Task AddIngredientToPizzaAsync(int pizzaID, int[] ingridients)
        {
            using (IDbConnection con = Connection)
            {
                foreach (var ingredient in ingridients)
                {
                    await connection.QueryAsync<Pizza>("INSERT INTO \"PizzaIngredients\"(\"PizzaID\", \"IngredientsID\") VALUES (@pizzaid, @ingredientid)", new { pizzaid = pizzaID, ingredientid = ingredient });
                }
            }

        }
        public void Dispose()
        {
            connection.Dispose();
        }


        //Slut Interface specifik
    }
}
