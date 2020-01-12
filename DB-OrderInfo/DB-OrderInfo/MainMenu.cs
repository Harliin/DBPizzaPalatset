using System;
using System.Threading;

namespace DB_OrderInfo
{
    class MainMenu
    {
        OrdersOngoing onGoingOrders;
        OrdersComplete completeOrders;
        public MainMenu()
        {
            this.onGoingOrders = new OrdersOngoing();
            this.completeOrders = new OrdersComplete();
        }

        public void Run()
        {
            string pizzalogo = "\tPIZZERIA PALATSET";
            Console.WriteLine("_____________________________________________");
            Console.WriteLine(pizzalogo);
            Console.WriteLine("_____________________________________________");

            Console.WriteLine($"\nPågående ordrar\t\t\tKlara ordrar");
            Console.WriteLine($"");
            int counterForCompleteOrder = 0;
            int counterForRemoveCompleteOrder = 0;
            do
            {
                GenerateNewOrder();

                if (counterForCompleteOrder == 1) /*Orderlistorna fortsätter att öka och detta är inget vi hanterar i 
                                                    denna version 1.0 av programmet. Detta åtgärdas i nästa version*/
                {
                    completeOrders.GetCompletedOrders(onGoingOrders);
                    counterForCompleteOrder = -1;

                    if (counterForRemoveCompleteOrder == 2)
                    {
                        completeOrders.RemoveCompleteOrders();
                        counterForRemoveCompleteOrder = 0;
                    }
                    counterForRemoveCompleteOrder++;
                }
                PrintOrders();
                counterForCompleteOrder++;

            } while (true);
        }

        public void GenerateNewOrder()/*Simulerar att nya ordrar kommer in genom att söva tråden och sedan skapa nya ordrar.*/
        {
            Thread.Sleep(1000);
            onGoingOrders.NewOrder();
        }

        public void PrintOrders()/*Skriver ut pågående och klara ordrar till consolen.*/
        {
            onGoingOrders.ShowOngoingOrders();
            completeOrders.ShowCompletedOrders();
        }
    }
}
