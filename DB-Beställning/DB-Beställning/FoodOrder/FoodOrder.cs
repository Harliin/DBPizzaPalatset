using System;
using System.Threading.Tasks;
using Food;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DB_Beställning
{
    public class FoodOrder
    {
        public  int totalPrice;
        private char key;
        public  OrderRepository repo { get; set; }
        private Dictionary<int, MenuItem> menuList { get; set; }
        private Order order { get; set; }
        public Menus menus;
        public FoodOrder()
        {
            //repo = new OrderRepository();
            menuList = new Dictionary<int, MenuItem>();
            //menus = new Menus();
            //order = repo.ShowOrderByID(menus.orderID).Result.First();
            //int index = 1;
            //order.pizza.ForEach(pizza => { menuList.Add(index, new MenuItem { id = pizza.ID, type = "pizza" }); index++; });
            //order.pasta.ForEach(pasta => { menuList.Add(index, new MenuItem { id = pasta.ID, type = "pasta" }); index++; });
            //order.sallad.ForEach(sallad => { menuList.Add(index, new MenuItem { id = sallad.ID, type = "sallad" }); index++; });
            //order.extra.ForEach(extra => { menuList.Add(index, new MenuItem { id = extra.ID, type = "extra" }); index++; });
            //order.drink.ForEach(drink => { menuList.Add(index, new MenuItem { id = drink.ID, type = "drink" }); index++; });
        }

        public void Diction()
        {
            int index = 1;
            order.pizza.ForEach(pizza => { menuList.Add(index, new MenuItem { id = pizza.ID, type = "pizza" }); index++; });
            order.pasta.ForEach(pasta => { menuList.Add(index, new MenuItem { id = pasta.ID, type = "pasta" }); index++; });
            order.sallad.ForEach(sallad => { menuList.Add(index, new MenuItem { id = sallad.ID, type = "sallad" }); index++; });
            order.extra.ForEach(extra => { menuList.Add(index, new MenuItem { id = extra.ID, type = "extra" }); index++; });
            order.drink.ForEach(drink => { menuList.Add(index, new MenuItem { id = drink.ID, type = "drink" }); index++; });
        }
        // Metod som printar ut innehållet i nuvarande order
        public void ShowOrder()
        {
            //menus = new Menus();
            order = repo.ShowOrderByID(Menus.orderID).Result.First();
            totalPrice = 0;
            Console.Clear();
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
        public async Task ShowPizzas()
        {
           // Menus menus = new Menus();
            var pizzas = await repo.ShowPizzasAsync();
            List<Pizza> listOfPizza = pizzas.ToList();
            Console.Clear();
            foreach (Pizza pizza in pizzas)
            {
                Console.WriteLine($"{pizza.ID}. {pizza.Name}: {pizza.Price}kr");
            }
            Console.Write($"\n9.Gå tillbaka");
            Console.Write("\n\nVal: ");

            if (int.TryParse(Console.ReadLine(), out menus.userChoice))
            {
                if (menus.userChoice == 9)
                {
                    await menus.PrintOrderMenu();
                }
                else if (listOfPizza.Exists(x => x.ID == menus.userChoice))
                {
                    await repo.AddPizzaToOrder(Menus.orderID, menus.userChoice);
                    foreach (Pizza pizza in await repo.ShowPizzaByID(menus.userChoice))
                    {
                        Console.WriteLine($"{pizza.Name} tillagd.");
                    }
                    Thread.Sleep(600);
                    await menus.PrintOrderMenu();
                }
            }
        }
        public async Task ShowPastas()
        {
           // menus = new Menus();
            var pastas = await repo.ShowPastasAsync();
            List<Pasta> listOfPasta = pastas.ToList();
            Console.Clear();
            foreach (Pasta pasta in pastas)
            {
                Console.WriteLine($"{pasta.ID}. {pasta.Name} {pasta.Price} kr");
            }
            Console.Write($"\n9. Gå tillbaka");
            Console.Write("\n\nVal: ");
            if (int.TryParse(Console.ReadLine(), out menus.userChoice))
            {
                if (menus.userChoice == 9)
                {
                    await menus.PrintOrderMenu();
                }
                else if(listOfPasta.Exists(x => x.ID == menus.userChoice))
                {
                    await repo.AddPastaToOrder(Menus.orderID, menus.userChoice);
                    foreach (Pasta pasta in await repo.ShowPastaByID(menus.userChoice))
                    {
                        Console.WriteLine($"{pasta.Name} tillagd.");
                    }
                    Thread.Sleep(600);
                    await menus.PrintOrderMenu();
                }
            }
        }
        public async Task ShowSallads()
        {
            //menus = new Menus();
            var sallads = await repo.ShowSalladsAsync();
            List<Sallad> listOfSallads = sallads.ToList();
            Console.Clear();
            foreach (Sallad sallad in sallads)
            {
                Console.WriteLine($"{sallad.ID}. {sallad.Name} {sallad.Price} kr");
            }
            Console.Write($"\n9. Gå tillbaka");
            Console.Write("\n\nVal: ");
            int.TryParse(Console.ReadLine(), out menus.userChoice);
            if (menus.userChoice == 9)
            {
                await menus.PrintOrderMenu();
            }
            else if (listOfSallads.Exists(x => x.ID == menus.userChoice))
            {
                await repo.AddSalladToOrder(Menus.orderID, menus.userChoice);
                foreach (Sallad sallad in await repo.ShowSalladByID(menus.userChoice))
                {
                    Console.WriteLine($"{sallad.Name} tillagd.");
                }
                Thread.Sleep(600);
                await menus.PrintOrderMenu();
            }
        }
        public async Task ShowDrinks()
        {
           // menus = new Menus();
            var drinks = await repo.ShowDrinksAsync();
            List<Drink> listOfDrinks = drinks.ToList();
            Console.Clear();
            foreach (Drink drink in drinks)
            {
                Console.WriteLine($"{drink.ID}. {drink.Name} {drink.Price} kr");
            }
            Console.Write($"\n9. Gå tillbaka");
            Console.Write("\n\nVal: ");
            int.TryParse(Console.ReadLine(), out menus.userChoice);
            if (menus.userChoice == 9)
            {
                await menus.PrintOrderMenu();
            }
            else if (listOfDrinks.Exists(x => x.ID == menus.userChoice))
            {
                await repo.AddDrinkToOrder(Menus.orderID, menus.userChoice);
                foreach (Drink drink in await repo.ShowDrinkByID(menus.userChoice))
                {
                    Console.WriteLine($"{drink.Name} tillagd.");
                }
                Thread.Sleep(600);
                await menus.PrintOrderMenu();
            }
        }
        public async Task ShowExtras()
        {
           // menus = new Menus();
            var extras = await repo.ShowExtraAsync();
            List<Extra> listOfExtras = extras.ToList();
            Console.Clear();
            foreach (Extra extra in await repo.ShowExtraAsync())
            {
                Console.WriteLine($"{extra.ID}. {extra.Name} {extra.Price} kr");
            }
            Console.Write($"\n9. Gå tillbaka");
            Console.Write("\n\nVal: ");
            int.TryParse(Console.ReadLine(), out menus.userChoice);
            if (menus.userChoice == 9)
            {
                await menus.PrintOrderMenu();
            }
            else if (listOfExtras.Exists(x => x.ID == menus.userChoice))
            {
                await repo.AddExtraToOrder(Menus.orderID, menus.userChoice);
                foreach (Extra extra in await repo.ShowExtraByID(menus.userChoice))
                {
                    Console.WriteLine($"{extra.Name} tillagd.");
                }
                Thread.Sleep(600);
                await menus.PrintOrderMenu();
            }
        }
        public async Task FinishOrder()
        {
            if (order.pizza.Count > 0 || order.sallad.Count > 0 || order.pasta.Count > 0
                || order.drink.Count > 0 || order.extra.Count > 0)
            {
                Console.WriteLine($"\nSumma: {totalPrice}kr");
                Console.WriteLine("\n\n1.Bekräfta \n2.Gå tillbaka");
            }
            else
            {
                Console.WriteLine("Ingen order lagd ännu");
                Thread.Sleep(600);
                await menus.PrintMenu();
            }
            key = Console.ReadKey(true).KeyChar;
            switch (key)
            {
                case '1':
                    await repo.UpdateOrderStatus(Menus.orderID);
                    Console.WriteLine("Tack för din beställning\nVälkommen åter!");
                    Thread.Sleep(600);
                    await menus.PrintMenu();
                    break;
                case '2':
                    await menus.PrintOrderMenu();
                    break;
                default:
                    break;
            }
        }
        
    }
}
