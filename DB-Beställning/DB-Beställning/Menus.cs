using System;
using System.Threading.Tasks;
using System.Threading;
using Food;
using System.Collections.Generic;
using System.Linq;

namespace DB_Beställning
{
    public class Menus
    {
        bool correctKey { get; set; }
        char key;
        public static int orderID { get; set; }
        public Menus()
        {
            FoodOrder.repo = new OrderRepository();
        }
        public async Task PrintMenu()
        {
            while (correctKey == false)
            {
                FoodOrder foodOrder = new FoodOrder();
                foodOrder.totalPrice = 0;
                Console.Clear();
                Console.WriteLine("Hej och välkomna till Pizza Palatset \nKlicka på Enter för att påbörja beställningen");
                key = Console.ReadKey(true).KeyChar;
                if (key == 13)
                {
                    //IEnumerable<Order> order = await repo.CreateNewOrder();
                    //orderID = order.First().ID;

                    //TA BORT SEN?
                    //List<Order> orders = order.ToList();
                    //orderID = orders.First().ID;
                    orderID = 44;
                    await PrintOrderMenu();
                    correctKey = true;
                }
            }
        }
        // Metod som skriver ut Matmenyn
        public async Task PrintOrderMenu()
        {
            FoodOrder foodOrder = new FoodOrder();
            Console.Clear();
            foreach (string item in MenuList.FoodMenu)
            {
                Console.WriteLine(item);
            }

            key = Console.ReadKey(true).KeyChar;
            switch (key)
            {
                // TODO Möjlighet att göra egen pizza
                case '1':
                    {
                        await foodOrder.ShowPizzas();
                        break;
                    }
                case '2':
                    {
                        await foodOrder.ShowPastas();
                        break;
                    }
                case '3':
                    {
                        await foodOrder.ShowSallads();
                        break;
                    }
                case '4':
                    {
                        await foodOrder.ShowDrinks();
                        break;
                    }
                case '5':
                    {
                        await foodOrder.ShowExtras();
                        break;
                    }
                case '6':
                    // TODO Möjlighet att ta bort från order
                    {
                        foodOrder.ShowOrder();
                        Console.WriteLine($"\nSumma: {foodOrder.totalPrice} kr");
                        Console.WriteLine("\n1.Ta bort beställning\n2.Gå tillbaka");
                        key = Console.ReadKey(true).KeyChar;
                        switch (key)
                        {
                            case '1':
                                Console.Clear();
                                var orders = foodOrder.Diction();
                                foreach (var item in orders)
                                {
                                    Console.WriteLine($"ID: {item.Key}, namn : {item.Value.name} ");
                                }
                                Console.WriteLine("\nTryck 0 för att gå tillbaka");
                                Console.Write("\nVälj ID för att ta bort: ");
                                if (int.TryParse(Console.ReadLine(), out int deleteChoice))
                                {
                                    if (deleteChoice== 0)
                                    {
                                        await PrintOrderMenu();
                                    }
                                    else if (orders.Keys.Count >= deleteChoice || orders.Keys.Count < 1)
                                    {
                                        if (orders.TryGetValue(deleteChoice, out MenuItem orderToRemove))
                                        {
                                            await foodOrder.RemoveOrder(orderToRemove);
                                            Console.WriteLine("Varan borttagen.");
                                            Thread.Sleep(600);
                                            await PrintOrderMenu();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Ogiltigt ID");
                                            Thread.Sleep(600);
                                            await PrintOrderMenu();
                                        }
                                    }
                                }
                                break;
                            case '2':
                                await PrintOrderMenu();
                                break;
                        }
                        break;
                    }
                case '7':
                    {
                        foodOrder.ShowOrder();
                        await foodOrder.FinishOrder();
                        //key = Console.ReadKey(true).KeyChar;
                        //switch (key)
                        //{
                        //    case '1':
                        //        {
                        //            await foodOrder.AddOrderToReceipt(foodOrder.totalPrice, DateTime.Now);
                        //            break;
                        //        }
                        //    case '2':
                        //        {
                        //            break;
                        //        }
                        //}
                        break;
                    }
                case '9':
                    {
                        await PrintMenu();
                        break;
                    }
                default:
                    break;

            }
        }
    }
}
