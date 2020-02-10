using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food;
using static Food.Order;

namespace DB_Kock
{
    public class Display
    {
        public static ChefRepository repo = new ChefRepository();

        public async Task DrawMultipleChoiceMenu()
        {
            var repo = new ChefRepository();

            Console.Clear();
            Console.WriteLine("Välj den order som du vill tillaga");
            Console.WriteLine("-------------\n");

            await ShowOrders();//skriver ut ordarna som är under tillagning

            Console.WriteLine("\n~ Välj ordernummer för att tillaga\n~ Tryck [0] för att logga ut");
            Console.Write("\nDitt val: ");

            IEnumerable<Order> orderByStatusIEnumerable = await repo.ShowOrderByStatus(eStatus.Tillagning);
            List<Order> listOfOrders = orderByStatusIEnumerable.ToList();

            if (int.TryParse(Console.ReadLine(), out int userInput))//Kollar om orderIDt finns
            {
                if (userInput == 0)
                {
                    await Program.Main();
                }
                else if (listOfOrders.Exists(x => x.ID == userInput))
                {
                    Order orderFood = await repo.ShowOrderByID(userInput);
                    bool correctKey = true;

                    do//Hanterar val för att tillaga en order eller gå tillbaka
                    {
                        Console.Clear();
                        Console.WriteLine($"Du har valt order # {orderFood.ID}");
                        Console.WriteLine($"\nDenna order innehåller följande artiklar:");
                        Console.WriteLine("------------------------\n");
                        await ShowFoodInOrder(orderFood.ID);//Skriver ut en orders innehåll
                        Console.WriteLine("\n------------------------");

                        Console.WriteLine("1. Tillaga");
                        Console.WriteLine("2. Återgå");
                        Console.WriteLine("3. Logga ut");

                        int userInput2 = Console.ReadKey(true).KeyChar - '0';

                        if (userInput2 == 1)
                        {
                            await repo.UpdateOrderStatus(userInput);
                            await DrawCookMenu(orderFood.ID);
                            correctKey = false;
                        }
                        if (userInput2 == 2)
                        {
                            await DrawMultipleChoiceMenu();
                            correctKey = false;
                        }
                        if (userInput2 == 3)
                        {
                           await Program.Main();
                           
                           
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Skriv 1, 2 eller 3");
                        }
                    } while (correctKey == true);
                }
                else
                {
                    Console.WriteLine("Finns ingen order med det IDt.");
                }
            }
            else
            {
                Console.WriteLine("Fel inmatning");
            }
            Console.ReadKey();
            await DrawMultipleChoiceMenu();
        }
        public async Task DrawCookMenu(int orderID)//Simulerar att pizzan tillagas
        {
            var repo = new ChefRepository();


            Console.Clear();
            Console.WriteLine("Maten tillagas");
            Console.WriteLine("-------------\n");

            // simulering av att pizzan tillagas
            System.Threading.Thread.Sleep(1500);

            // pizzan klar
            Console.Clear();
            Console.WriteLine("Pizzan färdig");
            Console.WriteLine("-------------\n");
            Console.Beep(500, 2000);

            Console.WriteLine("Klicka Enter när du är färdig och redo att skicka maten till servering");

            // väntar tills kocken bekräftat att maten är klar för servering
            while (true)
            {
                char key = Console.ReadKey(true).KeyChar;
                // om kocken klickar på enter så skickas den tillbaka till startsidan för att kunna ta nya ordrar
                if (key == 13)
                {
                    await DrawConfirmationScreen(orderID);
                    break;
                }
            }

        }


        public async Task DrawConfirmationScreen(int orderID) 
        {
            Console.Clear();
            var ordersIEnumerable = await repo.ShowFinishedOrderID();
            var firstOrder = ordersIEnumerable.First(x=> x.ID ==orderID);

              
            Console.WriteLine($"Skriver ut ordernummer { firstOrder.ID}...");
            Console.WriteLine();

            System.Threading.Thread.Sleep(2000);
            await DrawMultipleChoiceMenu();
        }


        private async Task ShowOrders()//Printar ut ordrar med status 2 == under tillagning
        {
            foreach (Order orderByStatus in await repo.ShowOrderByStatus(eStatus.Tillagning))//Printar ut alla ordrar under tillagning
            {
                int orderID = orderByStatus.ID;
                Console.Write($"Order #: {orderByStatus.ID} \n");


                foreach (Pizza pizzaItem in orderByStatus.pizza)
                {

                    Console.Write($"\t{pizzaItem.Name}\n");
                }
                foreach (Pasta pastaItem in orderByStatus.pasta)
                {
                    Console.Write($"\t{pastaItem.Name}\n");
                }
                foreach (Sallad salladItem in orderByStatus.sallad)
                {
                    Console.Write($"\t{salladItem.Name}\n");
                }
                foreach (Drink drinkItem in orderByStatus.drink)
                {
                    Console.Write($"\t{drinkItem.Name}\n");
                }
                foreach (Extra extraItem in orderByStatus.extra)
                {
                    Console.Write($"\t{extraItem.Name}\n");
                }
                Console.WriteLine();
            }
        }
        private async Task ShowFoodInOrder(int orderID)//Printar ut en specifik orders innehåll
        {
            Order order = await repo.ShowOrderByID(orderID);

            foreach (Pizza pizzaItem in order.pizza)//Skriver ut pizzan och dess ingredienser
            {
                Console.Write($"\t{pizzaItem.Name}:\n");
                Pizza pizza = await repo.GetPizzaByID(pizzaItem.ID);
                foreach (Ingredient ingredient in pizza.Ingredients)
                {
                    Console.WriteLine($"\t\tIngrediens:{ingredient.Name}");
                }
                Console.WriteLine();
            }
            foreach (Pasta pastaItem in order.pasta)
            {
                Console.Write($"\t{pastaItem.Name}\n\n");
            }
            foreach (Sallad salladItem in order.sallad)
            {
                Console.Write($"\t{salladItem.Name}\n\n");
            }
            foreach (Drink drinkItem in order.drink)
            {
                Console.Write($"\t{drinkItem.Name}\n\n");
            }
            foreach (Extra extraItem in order.extra)
            {
                Console.Write($"\t{extraItem.Name}\n\n");
            }
            Console.WriteLine();
        }

    }

}
