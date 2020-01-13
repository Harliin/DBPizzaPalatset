using System;
using System.Collections.Generic;
using System.Text;

namespace DB_Kock
{
    public class Display
    {
        public static object GlobalMethods { get; private set; }

        public static void DrawStartMenu()
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

        public static void DrawMultipleChoiceMenu()
        {
            Console.Clear();

            Console.WriteLine("Välj den order som du vill tillaga");
            Console.WriteLine("-------------\n");
            Orders.GetOrder();
            Console.WriteLine();

            Console.Write("Välj ordernummer: ");
            int opt = Convert.ToInt32(Console.ReadLine());
            //eller char opt = Console.ReadKey(true).KeyChar;


            switch (opt)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Du har valt order # 1");
                    Console.WriteLine();
                    Console.WriteLine("Denna rätt innehåller följande ingredienser:");
                    Console.WriteLine("------------------------");
                    Console.WriteLine();
                    Pizza.GetIngredients();
                    Console.WriteLine();
                    Console.WriteLine("------------------------");
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("Du har valt order # 2");
                    Console.WriteLine();
                    Console.WriteLine("Denna rätt innehåller följande ingredienser:");
                    Console.WriteLine("------------------------");
                    Console.WriteLine();
                    Pizza.GetIngredients();
                    Console.WriteLine();
                    Console.WriteLine("------------------------");
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("Du har valt order # 3");
                    Console.WriteLine();
                    Console.WriteLine("Denna rätt innehåller följande ingredienser:");
                    Console.WriteLine("------------------------");
                    Console.WriteLine();
                    Pizza.GetIngredients();
                    Console.WriteLine();
                    Console.WriteLine("------------------------");
                    break;

                case 4:
                    Console.Clear();
                    Console.WriteLine("Du har valt order # 4");
                    Console.WriteLine();
                    Console.WriteLine("Denna rätt innehåller följande ingredienser:");
                    Console.WriteLine("------------------------");
                    Console.WriteLine();
                    Pizza.GetIngredients();
                    Console.WriteLine();
                    Console.WriteLine("------------------------");
                    break;

                default:
                    DrawMultipleChoiceMenu();
                    break;

            }

            Console.WriteLine("1. Stoppa in i ugn");
            Console.WriteLine("2. Återgå");

            int userInput = Console.ReadKey(true).KeyChar - '0';

            if (userInput==1)
            {
                DrawCookPizzaMenu();
            }

            else if (userInput ==2)
            {
                DrawMultipleChoiceMenu();
            }

        }
        public static void DrawCookPizzaMenu()
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
                    DrawConfirmationScreen();
                    break;
                }
            }
        }

        public static void DrawConfirmationScreen()
        {
            Console.Clear();
            Console.WriteLine("Maten serverad!");
            System.Threading.Thread.Sleep(1500);
            DrawMultipleChoiceMenu();
        }
    }

}
