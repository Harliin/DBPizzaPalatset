﻿using System;
using System.Threading.Tasks;
using Food;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;

namespace DB_Beställning
{
    public class FoodOrder
    {
        public  int totalPrice;
        private char key;
        public static OrderRepository repo { get; set; }
        public static Dictionary<int, MenuItem> menuList { get; set; }
        private Order order { get; set; }
        public Menus menus;
        public int userChoice;
        public FoodOrder()
        {
            menuList = new Dictionary<int, MenuItem>();
            menus = new Menus();
        }
        // Skapar ett Dictionary som innehåller hela ordern, varje order får ett specifikt index
        public Dictionary<int, MenuItem> Diction()
        {
            int index = 1;
            order.pizza.ForEach(pizza => { menuList.Add(index, new MenuItem { id = pizza.ID, name = pizza.Name, type ="pizza" }); index++; });
            order.pasta.ForEach(pasta => { menuList.Add(index, new MenuItem { id = pasta.ID, name = pasta.Name, type ="pasta" }); index++; });
            order.sallad.ForEach(sallad => { menuList.Add(index, new MenuItem { id = sallad.ID, name = sallad.Name, type ="sallad" }); index++; });
            order.extra.ForEach(extra => { menuList.Add(index, new MenuItem { id = extra.ID, name = extra.Name, type ="extra" }); index++; });
            order.drink.ForEach(drink => { menuList.Add(index, new MenuItem { id = drink.ID, name = drink.Name, type="drink" }); index++; });
            return menuList;
            
        }
        // Metod som printar ut innehållet i nuvarande order
        public async Task ShowOrder()
        {
            order = repo.ShowOrderByID(Menus.orderID).Result.First();
            totalPrice = 0;
            Console.Clear();
            if (order.pizza.Count > 0 || order.sallad.Count > 0 || order.pasta.Count > 0
               || order.drink.Count > 0 || order.extra.Count > 0)
            {
                Console.WriteLine($"Ordernummer | {Menus.orderID}\n");
                foreach (Pizza pizzaItem in order.pizza)
                {
                    Console.Write($"{pizzaItem.Name} {pizzaItem.Price}kr\n");
                    totalPrice += pizzaItem.Price;
                }
                foreach (Pasta pastaItem in order.pasta)
                {
                    Console.Write($"{pastaItem.Name} {pastaItem.Price}kr\n");
                    totalPrice += pastaItem.Price;
                }
                foreach (Sallad salladItem in order.sallad)
                {
                    Console.Write($"{salladItem.Name} {salladItem.Price}kr\n");
                    totalPrice += salladItem.Price;
                }
                foreach (Drink drinkItem in order.drink)
                {
                    Console.Write($"{drinkItem.Name} {drinkItem.Price}kr\n");
                    totalPrice += drinkItem.Price;
                }
                foreach (Extra extraItem in order.extra)
                {
                    Console.Write($"{extraItem.Name} {extraItem.Price}kr\n");
                    totalPrice += extraItem.Price;
                }
            }
            else
            {
                Console.WriteLine("Ingen order lagd ännu");
                Thread.Sleep(600);
                await menus.PrintOrderMenu();
            }
        }
        // Metod som skriver ut Pizza och kollar så att userChoice passar med ett befintligt id
        public async Task ShowPizzas()
        {
            var pizzas = await repo.ShowPizzasAsync();
            List<Pizza> listOfPizza = pizzas.ToList();
            Console.Clear();
            Console.WriteLine("************Pizzameny***************");
            foreach (Pizza pizza in pizzas)
            {
                Console.WriteLine($"[{pizza.ID}] {pizza.Name}: {pizza.Price}kr");
            }
            Console.Write($"\n[9] Gå tillbaka");
            Console.Write("\n\nVal: ");

            if (int.TryParse(Console.ReadLine(), out userChoice))
            {
                if (userChoice == 9)
                {
                    await menus.PrintOrderMenu();
                }
                else if (listOfPizza.Exists(x => x.ID == userChoice))
                {
                    await repo.AddPizzaToOrder(Menus.orderID, userChoice);
                    foreach (Pizza pizza in await repo.ShowPizzaByID(userChoice))
                    {
                        Console.WriteLine($"{pizza.Name} tillagd.");
                    }
                    Thread.Sleep(600);
                    await menus.PrintOrderMenu();
                }
                else
                {
                    Console.WriteLine("Ogiltigt val.");
                    Thread.Sleep(600);
                    await ShowPizzas();
                }
            }
            else
            {
                Console.WriteLine("Felaktig inmatning");
                Thread.Sleep(600);
                await ShowPizzas();
            }
        }
        // Metod som skriver ut Pasta och kollar så att userChoice passar med ett befintligt id
        public async Task ShowPastas()
        {
            var pastas = await repo.ShowPastasAsync();
            List<Pasta> listOfPasta = pastas.ToList();
            Console.Clear();
            Console.WriteLine("************Pastameny***************");
            foreach (Pasta pasta in pastas)
            {
                Console.WriteLine($"[{pasta.ID}] {pasta.Name} {pasta.Price} kr");
            }
            Console.Write($"\n[9] Gå tillbaka");
            Console.Write("\n\nVal: ");
            if (int.TryParse(Console.ReadLine(), out userChoice))
            {
                if (userChoice == 9)
                {
                    await menus.PrintOrderMenu();
                }
                else if(listOfPasta.Exists(x => x.ID == userChoice))
                {
                    await repo.AddPastaToOrder(Menus.orderID, userChoice);
                    foreach (Pasta pasta in await repo.ShowPastaByID(userChoice))
                    {
                        Console.WriteLine($"{pasta.Name} tillagd.");
                    }
                    Thread.Sleep(600);
                    await menus.PrintOrderMenu();
                }
                else
                {
                    Console.WriteLine("Ogiltigt val.");
                    Thread.Sleep(600);
                    await ShowPastas();
                }
            }
            else
            {
                Console.WriteLine("Felaktig inmatning");
                Thread.Sleep(600);
                await ShowPastas();
            }
        }
        // Metod som skriver ut Sallad och kollar så att userChoice passar med ett befintligt id
        public async Task ShowSallads()
        {
            var sallads = await repo.ShowSalladsAsync();
            List<Sallad> listOfSallads = sallads.ToList();
            Console.Clear();
            Console.WriteLine("************Salladsmeny***************");
            foreach (Sallad sallad in sallads)
            {
                Console.WriteLine($"[{sallad.ID}] {sallad.Name} {sallad.Price} kr");
            }
            Console.Write($"\n[9] Gå tillbaka");
            Console.Write("\n\nVal: ");
            if (int.TryParse(Console.ReadLine(), out userChoice))
            {
                if (userChoice == 9)
                {
                    await menus.PrintOrderMenu();
                }
                else if (listOfSallads.Exists(x => x.ID == userChoice))
                {
                    await repo.AddSalladToOrder(Menus.orderID, userChoice);
                    foreach (Sallad sallad in await repo.ShowSalladByID(userChoice))
                    {
                        Console.WriteLine($"{sallad.Name} tillagd.");
                    }
                    Thread.Sleep(600);
                    await menus.PrintOrderMenu();
                }
                else
                {
                    Console.WriteLine("Ogiltigt val.");
                    Thread.Sleep(600);
                    await ShowSallads();
                }
            }
            else
            {
                Console.WriteLine("Felaktig inmatning");
                Thread.Sleep(600);
                await ShowSallads();
            }
        }
        // Metod som skriver ut Drinks och kollar så att userChoice passar med ett befintligt id
        public async Task ShowDrinks()
        {
            var drinks = await repo.ShowDrinksAsync();
            List<Drink> listOfDrinks = drinks.ToList();
            Console.Clear();
            Console.WriteLine("************Dryckesmeny***************");
            foreach (Drink drink in drinks)
            {
                Console.WriteLine($"[{drink.ID}] {drink.Name} {drink.Price} kr");
            }
            Console.Write($"\n[9] Gå tillbaka");
            Console.Write("\n\nVal: ");
            if (int.TryParse(Console.ReadLine(), out userChoice))
            {
                if (userChoice == 9)
                {
                    await menus.PrintOrderMenu();
                }
                else if (listOfDrinks.Exists(x => x.ID == userChoice))
                {
                    await repo.AddDrinkToOrder(Menus.orderID, userChoice);
                    foreach (Drink drink in await repo.ShowDrinkByID(userChoice))
                    {
                        Console.WriteLine($"{drink.Name} tillagd.");
                    }
                    Thread.Sleep(600);
                    await menus.PrintOrderMenu();
                }
                else
                {
                    Console.WriteLine("Ogiltigt val.");
                    Thread.Sleep(600);
                    await ShowDrinks();
                }
            }
            else
            {
                Console.WriteLine("Felaktig inmatning");
                Thread.Sleep(600);
                await ShowDrinks();
            }
        }
        // Metod som skriver ut Extras och kollar så att userChoice passar med ett befintligt id
        public async Task ShowExtras()
        {
            var extras = await repo.ShowExtraAsync();
            List<Extra> listOfExtras = extras.ToList();
            Console.Clear();
            Console.WriteLine("************Extrameny***************");
            foreach (Extra extra in await repo.ShowExtraAsync())
            {
                Console.WriteLine($"[{extra.ID}] {extra.Name} {extra.Price} kr");
            }
            Console.Write($"\n[9] Gå tillbaka");
            Console.Write("\n\nVal: ");
            if(int.TryParse(Console.ReadLine(), out userChoice))
            { 
            if (userChoice == 9)
            {
                await menus.PrintOrderMenu();
            }
            else if (listOfExtras.Exists(x => x.ID == userChoice))
            {
                await repo.AddExtraToOrder(Menus.orderID, userChoice);
                foreach (Extra extra in await repo.ShowExtraByID(userChoice))
                {
                    Console.WriteLine($"{extra.Name} tillagd.");
                }
                Thread.Sleep(600);
                await menus.PrintOrderMenu();
            }
                else
                {
                    Console.WriteLine("Ogiltigt val.");
                    Thread.Sleep(600);
                    await ShowExtras();
                }
            }
            else
            {
                Console.WriteLine("Felaktig inmatning");
                Thread.Sleep(600);
                await ShowExtras();
            }
        }
        // Metod som kollar om det finns varor i beställningen, och om det finns skickas man vidare till bekräftning
        public async Task FinishOrder()
        {
            await ShowOrder();
            if (order.pizza.Count > 0 || order.sallad.Count > 0 || order.pasta.Count > 0
                || order.drink.Count > 0 || order.extra.Count > 0)
            {
                Console.WriteLine($"\nSumma: {totalPrice}kr");
                Console.WriteLine("\n\n[1] Bekräfta \n[2] Gå tillbaka");
            }
            else
            {
                Console.WriteLine("\nIngen order lagd ännu");
                Thread.Sleep(600);
                await menus.PrintMenu();
            }
            key = Console.ReadKey(true).KeyChar;
            switch (key)
            {
                case '1':
                    Console.Clear();
                    await repo.UpdateOrderStatus(Menus.orderID);
                    await StoreReceipt();
                    Console.WriteLine("Tack för din beställning och välkommen åter!");
                    Console.WriteLine("Ditt kvitto skrivs ut.");
                    Thread.Sleep(1500);
                    await menus.PrintMenu();
                    break;
                case '2':
                    await menus.PrintOrderMenu();
                    break;
                default:
                    Console.WriteLine("Ogiltigt val!");
                    Console.ReadKey(true);
                    await FinishOrder();
                    break;
            }
        }
        // Metod som tar bort valt objekt från order
        public async Task RemoveOrder(MenuItem orderToRemove)
        {
            if(orderToRemove.type=="pizza")
            {
                await repo.RemovePizzaFromOrder(Menus.orderID, orderToRemove.id);
            }
            else if (orderToRemove.type == "pasta")
            {
                await repo.RemovePastaFromOrder(Menus.orderID, orderToRemove.id);
            }
            else if (orderToRemove.type == "sallad")
            {
                await repo.RemoveSalladFromOrder(Menus.orderID, orderToRemove.id);
            }
            else if (orderToRemove.type == "drink")
            {
                await repo.RemoveDrinkFromOrder(Menus.orderID, orderToRemove.id);
            }
            else if (orderToRemove.type == "extra")
            {
                await repo.RemoveExtraFromOrder(Menus.orderID, orderToRemove.id);
            }
        }
        // Metod som lägger till order till kvitto
        public async Task ChangeOrder()
        {
            await ShowOrder();
            Console.WriteLine($"\nSumma: {totalPrice} kr");
            Console.WriteLine("\n[1] Ta bort vara från beställning\n[2] Gå tillbaka");
            char key = Console.ReadKey(true).KeyChar;
            switch (key)
            {
                case '1':
                    {
                        bool check = true;
                        var orders = Diction();
                        do
                        {
                            Console.Clear();
                            foreach (var item in orders)
                            {
                                Console.WriteLine($"ID: [{item.Key}] namn: {item.Value.name} ");
                            }
                            Console.WriteLine("\nTryck [0] för att gå tillbaka");
                            Console.Write("\nVälj ID för att ta bort: ");
                            if (int.TryParse(Console.ReadLine(), out int deleteChoice))
                            {
                                if (deleteChoice == 0)
                                {
                                    check = false;
                                }
                                else if (orders.Keys.Count >= deleteChoice || orders.Keys.Count < 1)
                                {
                                    if (orders.TryGetValue(deleteChoice, out MenuItem orderToRemove))
                                    {
                                        await RemoveOrder(orderToRemove);
                                        Console.WriteLine("Varan borttagen.");
                                        Thread.Sleep(600);
                                        check = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ogiltigt ID");
                                        Thread.Sleep(600);
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Felaktig inmatning.");
                                Thread.Sleep(600);
                            }
                            break;

                        } while (check);
                        await menus.PrintOrderMenu();
                        break;
                    }
                case '2':
                    {
                        await menus.PrintOrderMenu();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("\nFelaktig inmatning");
                        Thread.Sleep(600);
                        await menus.PrintOrderMenu();
                        break;
                    }
            }
            
        }
        public async Task StoreReceipt()
        {
            List<string> menuItems = new List<string>();
            menuItems.Add($"OrderID : {Menus.orderID.ToString()}");
            order.pizza.ForEach(pizza => { menuItems.Add(pizza.Name); });
            order.pasta.ForEach(pasta => { menuItems.Add(pasta.Name); });
            order.sallad.ForEach(sallad => { menuItems.Add(sallad.Name); });
            order.drink.ForEach(drink => { menuItems.Add(drink.Name); });
            order.extra.ForEach(extra => { menuItems.Add(extra.Name); });
            string json = JsonConvert.SerializeObject(menuItems);
            await repo.AddOrderToReceipt(json, totalPrice, DateTime.Now);
        }
        
    }
}
