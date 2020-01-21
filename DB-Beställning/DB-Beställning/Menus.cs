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
        public OrderRepository repo = new OrderRepository();
        bool correctKey { get; set; }
        char key;

        public void PrintMenu()
        {
            while (correctKey == false)
            {
                Console.Clear();
                Console.WriteLine("Hej och välkomna till Pizza Palatset \nKlicka på Enter för att påbörja beställningen");
                key = Console.ReadKey(true).KeyChar;
                if (key == 13)
                {
                    PrintOrderMenu();
                    correctKey = true;
                }
            }
        }
        public async void PrintOrderMenu()
        {
            Console.Clear();
            foreach (string item in MenuList.FoodMenu)
            {
                Console.WriteLine(item);
            }

            key = Console.ReadKey(true).KeyChar;
            switch (key)
            {
                case '1':
                    await PrintPizzasAsync();
                    break;
                case '2':
                    await PrintPastas();
                    break;
                case '3':
                    await PrintSalads();
                    break;
                case '4':
                    await PrintDrinks();
                    break;
                default:
                    break;
            }
        }
        public async Task PrintPizzasAsync()
        {
            Console.Clear();
            foreach (Pizza pizza in await repo.Pizzas())
            {
                Console.WriteLine($"{pizza.ID} {pizza.Name} {pizza.Price}");
            }
            
        }
        public async Task PrintPastas()
        {
            Console.Clear();
            foreach (Pasta pasta in await repo.Pastas())
            {
                Console.WriteLine($"{pasta.ID} {pasta.Name} {pasta.Price}");
            }
            Console.ReadKey();
        }
        public async Task PrintSalads()
        {
            Console.Clear();
            foreach (Sallad sallad in await repo.Salads())
            {
                Console.WriteLine($"{sallad.ID} {sallad.Name} {sallad.Price}");
            }
            Console.ReadKey();
        }
        public async Task PrintDrinks()
        {
            Console.Clear();
            foreach (Drink drink in await repo.Drinks())
            {
                Console.WriteLine($"{drink.ID} {drink.Name} {drink.Price}");
            }
            Console.ReadKey();
        }
    }
}
