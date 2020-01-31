using System;
using System.Threading.Tasks;
using Food;
using System.Collections.Generic;
using System.Linq;
using DB_Beställning;


namespace Menu
{
    public class MenuOrder
    {
        int totalPrice;
        public static OrderRepository repo = new OrderRepository();

        // Metod som printar ut innehållet i nuvarande order
        public async Task ShowOrder()
        {
            var customerOrder = await repo.ShowOrderByID(Menus.orderID);
            List<Order> listOfCustomerOrder = customerOrder.ToList();
            Console.Clear();

            Console.WriteLine($"Ordernummer : {Menus.orderID}");
            foreach (Pizza pizzaItem in listOfCustomerOrder[0].pizza)
            {
                Console.Write($"{pizzaItem.Name} {pizzaItem.Price}kr\n");
                totalPrice += pizzaItem.Price;
            }
            foreach (Pasta pastaItem in listOfCustomerOrder[0].pasta)
            {
                Console.Write($"{pastaItem.Name} {pastaItem.Price}kr\n");
                totalPrice += pastaItem.Price;
            }
            foreach (Sallad salladItem in listOfCustomerOrder[0].sallad)
            {
                Console.Write($"{salladItem.Name} {salladItem.Price}kr\n");
                totalPrice += salladItem.Price;
            }
            foreach (Drink drinkItem in listOfCustomerOrder[0].drink)
            {
                Console.Write($"{drinkItem.Name} {drinkItem.Price}kr\n");
                totalPrice += drinkItem.Price;
            }
            foreach (Extra extraItem in listOfCustomerOrder[0].extra)
            {
                Console.Write($"{extraItem.Name} {extraItem.Price}kr\n");
                totalPrice += extraItem.Price;
            }
        }
    }
}
