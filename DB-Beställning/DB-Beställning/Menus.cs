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
    class Menus
    {
        
        bool correctKey { get; set; }
        char key;

        public async Task PrintMenu()
        {
            while (correctKey == false)
            {
                Console.Clear();
                Console.WriteLine("Hej och välkomna till Pizza Palatset \nKlicka på Enter för att påbörja beställningen");
                key = Console.ReadKey(true).KeyChar;
                if (key == 13)
                {
                    await PrintOrderMenu();
                    correctKey = true;
                }
            }
        }
        public async Task PrintOrderMenu()
        {
            var repo = new OrderRepository();
            Console.Clear();
            foreach (string item in MenuList.FoodMenu)
            {
                Console.WriteLine(item);
            }

            key = Console.ReadKey(true).KeyChar;
            switch (key)
            {
                case '1':
                    Console.Clear();
                    foreach (Pizza pizza in await repo.Pizzas())
                    {
                        Console.WriteLine($"{pizza.ID}. {pizza.Name} {pizza.Price}");
                    }
                    break;
                case '2':
                    Console.Clear();
                    foreach (Pasta pasta in await repo.Pastas())
                    {
                        Console.WriteLine($"{pasta.ID}. {pasta.Name} {pasta.Price} kr");
                    }
                    break;
                case '3':
                    Console.Clear();
                    foreach (Sallad sallad in await repo.Salads())
                    {
                        Console.WriteLine($"{sallad.ID}. {sallad.Name} {sallad.Price} kr");
                    }
                    break;
                case '4':
                    Console.Clear();
                    foreach (Drink drink in await repo.Drinks())
                    {
                        Console.WriteLine($"{drink.ID}. {drink.Name} {drink.Price} kr");
                    }
                    break;
                default:
                    break;
            }
        }
        //public async Task PrintPizzasAsync()
        //{
        //    Console.Clear();
        //    var repo = new OrderRepository();
        //    foreach (Pizza pizza in await repo.Pizzas())
        //    {
        //        Console.WriteLine($"{pizza.ID} {pizza.Name} {pizza.Price}");
        //    }
            
        //}
        //public async Task PrintPastasAsync()
        //{
        //    Console.Clear();
        //    var repo = new OrderRepository();
        //    foreach (Pasta pasta in await repo.Pastas())
        //    {
        //        Console.WriteLine($"{pasta.ID} {pasta.Name} {pasta.Price}");
        //    }
        //}
        //public async Task PrintSaladsAsync()
        //{
        //    Console.Clear();
        //    var repo = new OrderRepository();
        //    foreach (Sallad sallad in await repo.Salads())
        //    {
        //        Console.WriteLine($"{sallad.ID} {sallad.Name} {sallad.Price}");
        //    }
        //}
        //public async Task PrintDrinksAsync()
        //{
        //    Console.Clear();
        //    var repo = new OrderRepository();
        //    foreach (Drink drink in await repo.Drinks())
        //    {
        //        Console.WriteLine($"{drink.ID} {drink.Name} {drink.Price}");
        //    }
        //}
    }
}
