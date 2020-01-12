using System;
using System.Collections.Generic;

namespace DB_Kock
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pizza> orders = new List<Pizza>();

            GetOrders(orders);
   

        }

        public static void GetOrders(List<Pizza> orders)
        {
            int orderCounter, userInput;
            bool clicked = false;

            Console.Clear();

            while (clicked == false)
            {
                Console.WriteLine ("Välj den order som du vill tillaga");
                Console.WriteLine("-------------\n");

                orderCounter = 0;

                for (int i = 0; i < 5; i++)
                {
                    orderCounter++;
                    orders.Add(new Pizza());
                    orders[orders.Count - 1].GeneratePizza();
                    Console.WriteLine(orderCounter + ". " + orders[orderCounter - 1].Name);
                    System.Threading.Thread.Sleep(500);
                }

                userInput = Console.ReadKey(true).KeyChar - '0';
                if (userInput > 0 && userInput < 6)
                {
                    orders[userInput - 1].ShowOrder(orders[userInput - 1].Name, orders, userInput - 1);
                    clicked = true;
                }

                Console.Clear();
            }
        }
    }
}
