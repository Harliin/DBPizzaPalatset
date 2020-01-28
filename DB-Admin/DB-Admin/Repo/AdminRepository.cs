using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Food;

namespace DB_Admin
{
    public class AdminRepository : IRepository
    {
        private string ConnectionString { get; }
        private SqlConnection connection { get; }
        public AdminRepository()
        {
            ConnectionString = "Data Source=SQL6009.site4now.net;Initial Catalog=DB_A53DDD_Grupp1;User Id=DB_A53DDD_Grupp1_admin;Password=Password123;";
            connection = new SqlConnection(ConnectionString);
            connection.Open();
        }
        //Admin specifik

            //Add procedures
                public async Task AddPizzaAsync(string name, int price)
                {
                    await connection.QueryAsync<Pizza>("AddPizza",
                        new { Name = name, Price = price }, commandType: CommandType.StoredProcedure);
                }
                public async Task AddPastaAsync(string name, int price)
                {
                    await connection.QueryAsync<Pasta>("AddPasta",
                        new { Name = name, Price = price }, commandType: CommandType.StoredProcedure);
                }
                public async Task AddSalladAsync(string name, int price)
                {
                    await connection.QueryAsync<Sallad>("AddSallad",
                        new { Name = name, Price = price }, commandType: CommandType.StoredProcedure);
                }
                public async Task AddDrinkAsync(string name, int price)
                {
                    await connection.QueryAsync<Drink>("AddDrink",
                        new { Name = name, Price = price }, commandType: CommandType.StoredProcedure);
                }
                public async Task AddExtraAsync(string name, int price)
                {
                    await connection.QueryAsync<Extra>("AddExtra",
                        new { Name = name, Price = price }, commandType: CommandType.StoredProcedure);
                }
                public async Task AddEmployee(string name, string password, int eType)
                {
                    await connection.QueryAsync<Employee>("AddEmployee",
                        new { Name = name, Password = password, EmployeeType = eType }, commandType: CommandType.StoredProcedure);
                }
            //Slut Add Procedures

            //Delete procedures
                public async Task DeletePizzaAsync(int pizzaID)
                {
                    await connection.QueryAsync<Pizza>("DeletePizza",
                        new { ID = pizzaID }, commandType: CommandType.StoredProcedure);
                }
                public async Task DeletePastaAsync(int pastaID)
                {
                    await connection.QueryAsync<Pasta>("DeletePasta",
                        new { ID = pastaID }, commandType: CommandType.StoredProcedure);
                }
                public async Task DeleteSalladAsync(int salladID)
                {
                    await connection.QueryAsync<Sallad>("DeleteSallad",
                        new { ID = salladID }, commandType: CommandType.StoredProcedure);
                }
                public async Task DeleteDrinkAsync(int drinkID)
                {
                    await connection.QueryAsync<Drink>("DeleteDrink",
                        new { ID = drinkID }, commandType: CommandType.StoredProcedure);
                }
                public async Task DeleteExtraAsync(int ExtraID)
                {
                    await connection.QueryAsync<Extra>("DeleteSallad",
                        new { ID = ExtraID }, commandType: CommandType.StoredProcedure);
                }
                public async Task DeleteEmployee(int employeeID)
                {
                    await connection.QueryAsync<Employee>("DeleteEmployee",
                        new { ID = employeeID }, commandType: CommandType.StoredProcedure);
                }
            //Slut Delete procedures

            public async Task<IEnumerable<Employee>> ShowEmployees()
        {
            IEnumerable<Employee> employees = await connection.QueryAsync<Employee>("ShowEmployees", commandType: CommandType.StoredProcedure);
            return employees;
        }

        //Slut admin specifik



        //Från interface

            //Show Procedures
                public async Task<IEnumerable<OrderFood>> ShowOrderFood()
                {
                    IEnumerable<OrderFood> orderFoods = await connection.QueryAsync<OrderFood>("ShowOrders", commandType: CommandType.StoredProcedure);
                    return orderFoods;
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
            //Slut Show Procedures

            public async Task AddIngredientToPizzaAsync(int pizzaID, int[] ingridients)
            {
                foreach (var ingredient in ingridients)
                {
                    await connection.QueryAsync<Pizza>("INSERT INTO PizzaIngredients(PizzaID, IngredientsID) VALUES (@PizzaID, @IngredientID)", new { PizzaID = pizzaID, IngredientID = ingredient });
                }
            }

        //Slut Interface specifik
    }
}
