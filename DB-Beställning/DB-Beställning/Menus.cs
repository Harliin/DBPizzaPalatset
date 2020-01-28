using System;
using System.Threading.Tasks;
using System.Threading;
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
            counter = 0;
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
                        await repo.AddPizzaToOrder(8,Convert.ToInt32(key-'0'));
                        Console.Clear();
                        foreach (Pizza pizza in await repo.ShowPizzaByID(Convert.ToInt32(key-'0')))
                        {
                            Console.WriteLine($"En {pizza.Name} tillagd");
                            Thread.Sleep(700);
                            await PrintOrderMenu();
                        }
                    }
                    break;
                case '2':
                    Console.Clear();
                    foreach (Pasta pasta in await repo.ShowPastasAsync())
                    {
                        Console.WriteLine($"{pasta.ID}. {pasta.Name} {pasta.Price} kr");
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
                        await repo.AddPastaToOrder(8, Convert.ToInt32(key - '0'));
                        Console.Clear();
                        foreach (Pasta pasta in await repo.ShowPastaByID(Convert.ToInt32(key - '0')))
                        {
                            Console.WriteLine($"En {pasta.Name} tillagd");
                            Thread.Sleep(700);
                            await PrintOrderMenu();
                        }
                    }
                    break;
                case '3':
                    Console.Clear();
                    foreach (Sallad sallad in await repo.ShowSalladsAsync())
                    {
                        Console.WriteLine($"En {sallad.ID}. {sallad.Name} {sallad.Price} kr");
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
                        await repo.AddSalladToOrder(8, Convert.ToInt32(key -'0'));
                        Console.Clear();
                        foreach (Sallad sallad in await repo.ShowSalladByID(Convert.ToInt32(key - '0')))
                        {
                            Console.WriteLine($"En {sallad.Name} tillagd");
                            Thread.Sleep(700);
                            await PrintOrderMenu();
                        }
                    }
                    break;
                case '4':
                    Console.Clear();
                    foreach (Drink drink in await repo.ShowDrinksAsync())
                    {
                        Console.WriteLine($"{drink.ID}. {drink.Name} {drink.Price} kr");
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
                        await repo.AddDrinkToOrder(8, Convert.ToInt32(key - '0'));
                        Console.Clear();
                        foreach (Drink drink in await repo.ShowDrinkByID(Convert.ToInt32(key - '0')))
                        {
                            Console.WriteLine($"En {drink.Name} tillagd");
                            Thread.Sleep(700);
                            await PrintOrderMenu();
                        }
                    }
                    break;
                case '5':
                    Console.Clear();
                    foreach (Extra extra in await repo.ShowExtraAsync())
                    {
                        Console.WriteLine($"{extra.ID}. {extra.Name} {extra.Price} kr");
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
                        await repo.AddExtraToOrder(8, Convert.ToInt32(key - '0'));
                        Console.Clear();
                        foreach (Extra extra in await repo.ShowExtraByID(Convert.ToInt32(key - '0')))
                        {
                            Console.WriteLine($"En {extra.Name} tillagd");
                            Thread.Sleep(700);
                            await PrintOrderMenu();
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
