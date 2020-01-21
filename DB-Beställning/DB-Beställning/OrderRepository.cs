﻿using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food;

namespace DB_Beställning
{
    class OrderRepository
    {
        private string connectionString { get; }
        private SqlConnection connection { get; }

        public OrderRepository()
        {
            connectionString = "Data Source = SQL6009.site4now.net; Initial Catalog = DB_A53DDD_Grupp1; User Id = DB_A53DDD_Grupp1_admin; Password = Password123;";
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public async Task <IEnumerable<Pizza>> Pizzas()
        {
            IEnumerable<Pizza> pizzas = (await connection.QueryAsync<Pizza>("GetPizzas", commandType: CommandType.StoredProcedure));
            return pizzas;
        }
        public async Task<IEnumerable<Pasta>> Pastas()
        {
            IEnumerable<Pasta> pastas = (await connection.QueryAsync<Pasta>("GetPastas", commandType: CommandType.StoredProcedure));
            return pastas;
        }
        public async Task<IEnumerable<Sallad>> Salads()
        {
            IEnumerable<Sallad> salads = (await connection.QueryAsync<Sallad>("GetSalads", commandType: CommandType.StoredProcedure));
            return salads;
        }
        public async Task<IEnumerable<Drink>> Drinks()
        {
            IEnumerable<Drink> drinks = (await connection.QueryAsync<Drink>("GetDrinks", commandType: CommandType.StoredProcedure));
            return drinks;
        }

    }
}
