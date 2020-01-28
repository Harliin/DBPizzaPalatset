using System;
using System.Threading.Tasks;
using Food;
namespace DB_Beställning
{
    class Menus
    {
        
        bool correctKey { get; set; }
        char key;
        int counter;

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
                    foreach (Pizza pizza in await repo.ShowPizzasAsync())
                    {
                        Console.WriteLine($"{pizza.ID}. {pizza.Name}: {pizza.Price}kr");
                        counter++;
                    }
                    Console.Write($"\n{counter + 1}. Avsluta");
                    Console.Write("\n\nVal:");
                    key = Console.ReadKey(true).KeyChar;
                    if ((key - '0') == (counter + 1))
                    {
                        await PrintOrderMenu();
                    }
                    else
                    {
                       
                    }
                    break;
                case '2':
                    Console.Clear();
                    foreach (Pasta pasta in await repo.ShowPastasAsync())
                    {
                        Console.WriteLine($"{pasta.ID}. {pasta.Name} {pasta.Price} kr");
                    }
                    key = Console.ReadKey(true).KeyChar;
                    break;
                case '3':
                    Console.Clear();
                    foreach (Sallad sallad in await repo.ShowSalladsAsync())
                    {
                        Console.WriteLine($"{sallad.ID}. {sallad.Name} {sallad.Price} kr");
                    }
                    key = Console.ReadKey(true).KeyChar;
                    break;
                case '4':
                    Console.Clear();
                    foreach (Drink drink in await repo.ShowDrinksAsync())
                    {
                        Console.WriteLine($"{drink.ID}. {drink.Name} {drink.Price} kr");
                    }
                    key = Console.ReadKey(true).KeyChar;
                    break;
                default:
                    break;
            }
        }
    }
}
