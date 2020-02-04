using System;
using System.Threading.Tasks;
using Food;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
//using DB_Beställning.Menus;

namespace DB_Beställning
{
    public class FoodOrder
    {
        public  int totalPrice;
        private char key;
        public  OrderRepository repo { get; set; }
        private Dictionary<int, MenuItem> menuList { get; set; }
        private Order order { get; set; }
        public Menus Menus;
        public FoodOrder()
        {
            repo = new OrderRepository();
            menuList = new Dictionary<int, MenuItem>();
            order = repo.ShowOrderByID(Menus.orderID).Result.First();
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
                await Menus.PrintMenu();
            }
            key = Console.ReadKey(true).KeyChar;
            switch (key)
            {
                case '1':
                    await repo.UpdateOrderStatus(Menus.orderID);
                    Console.WriteLine("Tack för din beställning\nVälkommen åter!");
                    Thread.Sleep(600);
                    await Menus.PrintMenu();
                    break;
                case '2':
                    await Menus.PrintOrderMenu();
                    break;
                default:
                    break;
            }
        }
    }
}
