using System;
using System.Threading.Tasks;
using System.Threading;
using Food;
using System.Collections.Generic;
using System.Linq;


namespace DB_Beställning
{
    class Menus
    {
        
        bool correctKey { get; set; }
        char key;
        int userChoice;
        public static int orderID { get; set; }
        public static OrderRepository repo = new OrderRepository();
        public async Task PrintMenu()
        {
            while (correctKey == false)
            {
                Console.Clear();
                Console.WriteLine("Hej och välkomna till Pizza Palatset \nKlicka på Enter för att påbörja beställningen");
                key = Console.ReadKey(true).KeyChar;
                if (key == 13)
                {   
                    IEnumerable<Order> order = await repo.CreateNewOrder();
                    List<Order> orders = order.ToList();
                    orderID = orders[0].ID;
                    
                    await PrintOrderMenu();
                    correctKey = true;
                }
            }
        }
        // FIXA ORDER ID
        public async Task PrintOrderMenu()
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
                    var pizzas = await repo.ShowPizzasAsync();
                    List<Pizza> listOfPizza = pizzas.ToList();
                    Console.Clear();
                    foreach (Pizza pizza in pizzas)
                    {
                        Console.WriteLine($"{pizza.ID}. {pizza.Name}: {pizza.Price}kr");
                    }
                    Console.Write($"\n9. Avsluta");
                    Console.Write("\n\nVal: ");
                    
                    if (userChoice == 9)
                    {
                        await PrintOrderMenu();
                    }
                    else if (int.TryParse(Console.ReadLine(), out userChoice))
                    {
                        if (listOfPizza.Exists(x => x.ID == userChoice))
                        {
                            await repo.AddPizzaToOrder(orderID, userChoice); // 37 är test nr
                            foreach (Pizza pizza in await repo.ShowPizzaByID(userChoice))
                            {
                                Console.WriteLine($"{pizza.Name} tillagd.");
                            }
                            Thread.Sleep(600);
                            await PrintOrderMenu();  
                        }
                    }
                    break;
                case '2':
                    var pastas = await repo.ShowPastasAsync();
                    List<Pasta> listOfPasta = pastas.ToList();
                    Console.Clear();
                    foreach (Pasta pasta in pastas)
                    {
                        Console.WriteLine($"{pasta.ID}. {pasta.Name} {pasta.Price} kr");
                    }
                    Console.Write($"\n9. Avsluta");
                    Console.Write("\n\nVal: ");
                    if (int.TryParse(Console.ReadLine(), out userChoice))
                    {
                        if (userChoice == 9)
                        {
                            await PrintOrderMenu();
                        }
                        else if(listOfPasta.Exists(x => x.ID == userChoice))
                        {
                            await repo.AddPastaToOrder(2, userChoice); // 2 är test nr
                        }
                    }
                    break;
                case '3':
                    Console.Clear();
                    foreach (Sallad sallad in await repo.ShowSalladsAsync())
                    {
                        Console.WriteLine($"En {sallad.ID}. {sallad.Name} {sallad.Price} kr");
                    }
                    Console.Write($"\n9. Avsluta");
                    Console.Write("\n\nVal: ");
                    int.TryParse(Console.ReadLine(), out userChoice);
                    if (userChoice == 9)
                    {
                        await PrintOrderMenu();
                    }
                    else
                    {
                        await repo.AddSalladToOrder(2, userChoice);
                    }
                    break;
                case '4':
                    Console.Clear();
                    foreach (Drink drink in await repo.ShowDrinksAsync())
                    {
                        Console.WriteLine($"{drink.ID}. {drink.Name} {drink.Price} kr");
                    }
                    Console.Write($"\n9. Avsluta");
                    Console.Write("\n\nVal: ");
                    int.TryParse(Console.ReadLine(), out userChoice);
                    if (userChoice == 9)
                    {
                        await PrintOrderMenu();
                    }
                    else
                    {
                        await repo.AddDrinkToOrder(2, userChoice); // 2 är test nr
                    }
                    break;
                case '5':
                    Console.Clear();
                    foreach (Extra extra in await repo.ShowExtraAsync())
                    {
                        Console.WriteLine($"{extra.ID}. {extra.Name} {extra.Price} kr");
                    }
                    Console.Write($"\n9. Avsluta");
                    Console.Write("\n\nVal: ");
                    int.TryParse(Console.ReadLine(), out userChoice);
                    if (userChoice == 9)
                    {
                        await PrintOrderMenu();
                    }
                    else
                    {
                        await repo.AddExtraToOrder(2, userChoice); // 2 är test nr
                    }
                    break;
                case '6':
                    {
                        var customerOrder = await repo.ShowOrderByID(orderID);
                        List<Order> listCustomerOrder = customerOrder.ToList();
                        Console.WriteLine($"Ordernummer :{listCustomerOrder[0].ID}");
                    foreach (Pizza pizzaItem in listCustomerOrder[0].pizza)
                    {

                        Console.Write($"\t{pizzaItem.Name}\n");
                    }
                    foreach (Pasta pastaItem in listCustomerOrder[0].pasta)
                    {
                        Console.Write($"\t{pastaItem.Name}\n");
                    }
                    foreach (Sallad salladItem in listCustomerOrder[0].sallad)
                    {
                        Console.Write($"\t{salladItem.Name}\n");
                    }
                    foreach (Drink drinkItem in listCustomerOrder[0].drink)
                    {
                        Console.Write($"\t{drinkItem.Name}\n");
                    }
                    foreach (Extra extraItem in listCustomerOrder[0].extra)
                    {
                        Console.Write($"\t{extraItem.Name}\n");
                    }
                }
                    break;
                default:
                    break;
            }
        }
    }
}
