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
        //public OrderRepository repo;
        //public FoodOrder foodOrder;
        public Menus()
        {
            FoodOrder.repo = new OrderRepository();
            //foodOrder = new FoodOrder();
            orderID = 44;
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
                    //orderID = 44;
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
                                foodOrder.ShowOrder();
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
                        break;
                    }
                default:
                    break;

            }
        }
    }
}
