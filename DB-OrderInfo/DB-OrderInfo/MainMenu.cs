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

        public void Run()/*Skriver ut menyn till consolen samt kallar på metoder för att skapa och ta bort ordrar*/
        {
            PrintLogo();
            Console.WriteLine($"Pågående ordrar\t\tKlara ordrar");
            int counterForCompleteOrder = 0; /*Räknare för att gå in i if-satserna och flytta över/ta bort ordrar*/
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
        public static void PrintLogo() /*Printar ut Logo för pizzaPalatset*/
        {
            string pizzalogo = "\tPIZZERIA PALATSET";
            Console.WriteLine("_____________________________________________");
            Console.WriteLine(pizzalogo);
            Console.WriteLine("_____________________________________________\n");
            Console.ResetColor();
        }
    }
}
