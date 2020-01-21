using Dapper;
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
    class Program
    {
        static async Task Main(string[] args)
        {
            Menus meny = new Menus();
            meny.PrintMenu();
            foreach (Pizza pizza in await repo.Pizzas())
            {
                Console.WriteLine($"{pizza.ID} {pizza.Name} {pizza.Price}");
            }
        }
    }
}
