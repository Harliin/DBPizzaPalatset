using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DB_Kock.Food;

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

            foreach (var processingOrder in await repo.ShowProcessingOrder())
            {
                Console.WriteLine($"{processingOrder}");
            }
                
                Console.WriteLine();

                Console.Write("Välj ordernummer: ");
                int opt = Console.ReadKey(true).KeyChar - '0';

                switch (opt)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Du har valt order # 1");
                        Console.WriteLine();
                        Console.WriteLine("Hämta order item (pizza)");
                        Console.WriteLine("Denna rätt innehåller följande ingredienser:");
                        Console.WriteLine("------------------------");
                        Console.WriteLine();

                    foreach (var pizzaIngred in await repo.ShowPizzas())
                    {
                        Console.WriteLine($"{pizzaIngred.Ingredient1}\n{pizzaIngred.Ingredient2}");
                    }
                        Console.WriteLine();
                        Console.WriteLine("------------------------");
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Du har valt order # 2");
                        Console.WriteLine();
                        Console.WriteLine("Hämta order item (pizza)");
                        Console.WriteLine("Denna rätt innehåller följande ingredienser:");
                        Console.WriteLine("------------------------");
                        Console.WriteLine();

                    foreach (var pizzaIngred in await repo.ShowPizzas())
                    {
                        Console.WriteLine($"{pizzaIngred.Ingredient1}\n{pizzaIngred.Ingredient2}\n{pizzaIngred.Ingredient3}\n{pizzaIngred.Ingredient4}");
                    }

                        Console.WriteLine();
                        Console.WriteLine("------------------------");
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Du har valt order # 3");
                        Console.WriteLine();
                        Console.WriteLine("Hämta order item (pizza)");
                        Console.WriteLine("Denna rätt innehåller följande ingredienser:");
                        Console.WriteLine("------------------------");
                        Console.WriteLine();

                    foreach (var pizzaIngred in await repo.ShowPizzas())
                    {
                        Console.WriteLine($"{pizzaIngred.Ingredient1}\n{pizzaIngred.Ingredient2}\n{pizzaIngred.Ingredient3}\n{pizzaIngred.Ingredient4}");
                    }

                    Console.WriteLine();
                        Console.WriteLine("------------------------");
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("Du har valt order # 4");
                        Console.WriteLine();
                        Console.WriteLine("Hämta order item (pizza)");
                        Console.WriteLine("Denna rätt innehåller följande ingredienser:");
                        Console.WriteLine("------------------------");
                        Console.WriteLine();

                    foreach (var pizzaIngred in await repo.ShowPizzas())
                    {
                        Console.WriteLine($"{pizzaIngred.Ingredient1}\n{pizzaIngred.Ingredient2}\n{pizzaIngred.Ingredient3}\n{pizzaIngred.Ingredient4}");
                    }

                    Console.WriteLine();
                        Console.WriteLine("------------------------");
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("Du har valt order # 4");
                        Console.WriteLine();
                        Console.WriteLine("Hämta order item (sallad/pasta)");
                        Console.WriteLine("------------------------");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("------------------------");
                        break;

                    case 6:
                        Console.Clear();
                        Console.WriteLine("Du har valt order # 5");
                        Console.WriteLine();
                        Console.WriteLine("Hämta order item (sallad/pasta)");
                        Console.WriteLine("------------------------");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("------------------------");
                        break;

                    case 7:
                        Console.Clear();
                        Console.WriteLine("Du har valt order # 5");
                        Console.WriteLine();
                        Console.WriteLine("Hämta order item (sallad/pasta)");
                        Console.WriteLine("------------------------");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("------------------------");
                        break;

                    default:
                    await DrawMultipleChoiceMenu();
                        break;

                }

            bool correctKey = true;

            do
            {

                if (opt < 5 && opt > 0)
                {
                    Console.WriteLine("1. Stoppa in i ugn");
                }

                else if (opt > 4)
                {
                    Console.WriteLine("1. Tillaga");
                }


                Console.WriteLine("2. Återgå");

                int userInput = Console.ReadKey(true).KeyChar - '0';

                if (userInput == 1 && opt < 5 && opt > 0)
                {
                    await DrawCookPizzaMenu();
                    correctKey = false;
                }

                else if (userInput == 1 && opt > 4)
                {
                    await DrawCookSaladOrPastaMenu();
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
        public static async Task DrawCookPizzaMenu()
        {
            // pizzan ligger i ugnen
            Console.Clear();
            Console.WriteLine("Pizzan tillagas");
            Console.WriteLine("-------------\n");

            // simulering av att pizzan tillagas
            System.Threading.Thread.Sleep(1500);

            // pizzan klar
            Console.Clear();
            Console.WriteLine("Pizzan färdig");
            Console.WriteLine("-------------\n");
            Console.Beep(500, 2000);

            Console.WriteLine("Klicka Enter för att skicka pizzan till servering");

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

        public static async Task DrawCookSaladOrPastaMenu()
        {
            Console.Clear();
            Console.WriteLine("Maten tillagas");
            Console.WriteLine("-------------\n");

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
            Console.Clear();
            Console.WriteLine("Skriver ut ordernummer...");
            Orders.GetOrdernumber();
            System.Threading.Thread.Sleep(1500);
            await DrawMultipleChoiceMenu();
        }
    }

}
