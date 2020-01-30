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

        public static async Task DrawStartMenuAsync()
        {
            bool loop = true;

            do
            {
                Console.Clear();
                Console.WriteLine("---------------------");
                Console.WriteLine("Logga in");
                Console.WriteLine("---------------------");


                Console.Write("Pinkod:");

                string input = Console.ReadLine();

                if (input == "Bagare123")
                {
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Fel pinkod");
                    Console.ReadKey();

                }

            } while (loop == true);

        }

        public static async Task DrawMultipleChoiceMenu()
        {
            var repo = new ChefRepository();

            Console.Clear();
            Console.WriteLine("Välj den order som du vill tillaga");
            Console.WriteLine("-------------\n");

            IEnumerable<Order> orderByStatusList = await repo.ShowOrderByStatus(eStatus.Tillagning);
            foreach (Order orderByStatus in orderByStatusList)
            {
                Console.Write($"{orderByStatus.ID}" + ". ");
            }

            foreach (Order orderByStatus in orderByStatusList)
            {
                foreach (Pizza pizzaItem in orderByStatus.pizza)
                {
                    Console.Write($"{pizzaItem.Name}" + " ");
                    Console.WriteLine();
                }
            }

            foreach (Order orderByStatus in orderByStatusList)
            {
                foreach (Pasta pastaItem in orderByStatus.pasta)
                {
                    Console.Write($"{pastaItem.Name}" + " ");
                }
            }

            foreach (Order orderByStatus in orderByStatusList)
            {
                foreach (Sallad salladItem in orderByStatus.sallad)
                {
                    Console.Write($"{salladItem.Name}" + " ");
                    Console.WriteLine();
                }
            }

            foreach (Order orderByStatus in orderByStatusList)
            {
                foreach (Drink drinkItem in orderByStatus.drink)
                {
                    Console.Write($"{drinkItem.Name}" + " ");
                    Console.WriteLine();
                }
            }

            foreach (Order orderByStatus in orderByStatusList)
            {
                foreach (Extra extraItem in orderByStatus.extra)
                {
                    Console.Write($"{extraItem.Name}" + " ");
                }
            }
               

 
            Console.WriteLine();
            Console.Write("Välj ordernummer: ");

            List<Order> listOfOrders = orderByStatusList.ToList();

            if (int.TryParse(Console.ReadLine(), out int opt))
            {
                if (listOfOrders.Exists(x => x.ID == opt))
                {
                    await repo.UpdateOrderStatus(opt);
                    foreach (var orderFood in await repo.ShowOrderByID(opt))
                    {
                        Console.Clear();
                        Console.WriteLine($"Du har valt order # {orderFood.ID}");
                        Console.WriteLine();
                        Console.WriteLine($"Denna order innehåller följande artiklar:");
                        Console.WriteLine("------------------------");
                        Console.WriteLine();
                        Console.WriteLine("*Order artiklar*"); //Gör detta
                        Console.WriteLine();
                        Console.WriteLine("------------------------");
                    }

                }
            }

            else
            {
                Console.WriteLine("Fel inmatning");
            }

            bool correctKey = true;

            do
            {

                Console.WriteLine("1. Tillaga");
                Console.WriteLine("2. Återgå");

                int userInput = Console.ReadKey(true).KeyChar - '0';

                if (userInput == 1)
                {
                    await DrawCookMenu();
                    correctKey = false;
                }

                if (userInput == 2)
                {
                    await DrawMultipleChoiceMenu();
                    correctKey = false;
                }

                else
                {
                    Console.Clear();
                    Console.WriteLine("Skriv 1 eller 2");
                }

            } while (correctKey == true);

        }
        public static async Task DrawCookMenu()
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
                // om kocken klickar på enter så skickas hen tillbaka till startsidan för att kunna ta nya ordrar
                if (key == 13)
                {
                    await DrawConfirmationScreen();
                    break;
                }
            }


        }


        public static async Task DrawConfirmationScreen()
        {
            var repo = new ChefRepository();

            Console.Clear();
            Console.WriteLine("Skriver ut ordernummer...");
            //Använd ShowORderByID men hur jag kan använda userInput/opt från annan method?

            System.Threading.Thread.Sleep(1500);
            await DrawMultipleChoiceMenu();
        }
    }

}
