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
    public class AdminRepository
    {
        private string ConnectionString { get; }
        private SqlConnection connection { get; }
        public AdminRepository()
        {
            ConnectionString = "Data Source=SQL6009.site4now.net;Initial Catalog=DB_A53DDD_Grupp1;User Id=DB_A53DDD_Grupp1_admin;Password=Password123;";
            connection = new SqlConnection(ConnectionString);
            connection.Open();
        }

        public async Task AddPizzaAsync(string name, string price, string ingrediens1, string ingrediens2, string ingrediens3, string ingrediens4)
        {
            await connection.QueryAsync<Pizza>("AddCompletePizza",
                new { Name = name, Price = price, Ingredient1 = ingrediens1, Ingredient2 = ingrediens2, Ingredient3 = ingrediens3, Ingredient4 = ingrediens4 }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Pizza>> ShowPizzasAsync()
        {
            IEnumerable<Pizza> pizzas = await connection.QueryAsync<Pizza>("GetPizzas", commandType: CommandType.StoredProcedure);
            return pizzas;
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
    }
}
