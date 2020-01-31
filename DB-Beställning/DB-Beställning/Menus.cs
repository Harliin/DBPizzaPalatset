using System;
using System.Threading.Tasks;
using System.Threading;
using Food;
using System.Collections.Generic;
using System.Linq;
using Menu;


namespace DB_Beställning
{
    class Menus
    {
        
        bool correctKey { get; set; }
        char key;
        int userChoice;
        int totalPrice;
        public static int orderID { get; set; }
        public static OrderRepository repo = new OrderRepository();
        public async Task PrintMenu()
        {
            while (correctKey == false)
            {
                totalPrice = 0;
                Console.Clear();
                Console.WriteLine("Hej och välkomna till Pizza Palatset \nKlicka på Enter för att påbörja beställningen");
                key = Console.ReadKey(true).KeyChar;
                if (key == 13)
                {
                    //IEnumerable<Order> order = await repo.CreateNewOrder();
                    //List<Order> orders = order.ToList();
                    //orderID = orders[0].ID;
                    orderID = 44;
                    await PrintOrderMenu();
                    correctKey = true;
                }
            }
        }
        // Metod som skriver ut Matmenyn
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
                            await repo.AddPizzaToOrder(orderID, userChoice);
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
                            await repo.AddPastaToOrder(orderID, userChoice);
                            foreach (Pasta pasta in await repo.ShowPastaByID(userChoice))
                            {
                                Console.WriteLine($"{pasta.Name} tillagd.");
                            }
                            Thread.Sleep(600);
                            await PrintOrderMenu();
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
                        await repo.AddSalladToOrder(orderID, userChoice);
                        foreach (Sallad sallad in await repo.ShowSalladByID(userChoice))
                        {
                            Console.WriteLine($"{sallad.Name} tillagd.");
                        }
                        Thread.Sleep(600);
                        await PrintOrderMenu();
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
                        await repo.AddDrinkToOrder(orderID, userChoice);
                        foreach (Drink drink in await repo.ShowDrinkByID(userChoice))
                        {
                            Console.WriteLine($"{drink.Name} tillagd.");
                        }
                        Thread.Sleep(600);
                        await PrintOrderMenu();
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
                        await repo.AddExtraToOrder(orderID, userChoice);
                        foreach (Extra extra in await repo.ShowExtraByID(userChoice))
                        {
                            Console.WriteLine($"{extra.Name} tillagd.");
                        }
                        Thread.Sleep(600);
                        await PrintOrderMenu();
                    }
                    break;
                case '6':
                    Console.WriteLine("1.Ta bort beställning\2.Gå tillbaka");
                    break;
                case '7':
                    await 
                    // if sats som kollar om det finns något föremål i listofcustomer order
                    if (listOfCustomerOrder[0].pizza.Count > 0 || listOfCustomerOrder[0].sallad.Count > 0 || listOfCustomerOrder[0].pasta.Count > 0
                        || listOfCustomerOrder[0].drink.Count > 0 || listOfCustomerOrder[0].extra.Count > 0)
                    {
                        Console.WriteLine($"\nSumma: {totalPrice}kr");
                        Console.WriteLine("\n\n1.Bekräfta \n2.Gå tillbaka");
                    }
                    else
                    {
                        Console.WriteLine("Ingen order lagd ännu");
                        Thread.Sleep(600);
                        await PrintOrderMenu();
                    }
                    key = Console.ReadKey(true).KeyChar;
                    switch(key)
                    {
                        case '1':
                            await repo.UpdateOrderStatus(orderID);
                            Console.WriteLine("Tack för din beställning\nVälkommen åter!");
                            Thread.Sleep(600);
                            await PrintMenu();
                            break;
                        case '2':
                            await PrintOrderMenu();
                            break;
                        default:
                            break;        
                    }
                    break;
                default:
                    await PrintOrderMenu();
                    break;
            }
        }
    }
}
