using System;
using System.Collections.Generic;
using System.Text;

namespace DB_Beställning
{
    class Menus
    {
        bool correctKey { get; set; }
        char key;

        public void PrintMenu()
        {
            while (correctKey == false)
            {
                Console.Clear();
                Console.WriteLine("Hej och välkomna till Pizza Palatset \nKlicka på Enter för att påbörja beställningen");
                key = Console.ReadKey(true).KeyChar;
                if (key == 13)
                {
                    PrintOrderMenu();
                    correctKey = true;
                }
            }
        }
        public void PrintOrderMenu()
        {
            Console.Clear();
            Console.WriteLine("[1] Pizza\n[2] Pasta\n[3] Sallad\n[4] Tillbehör [6] Avsluta");

            key = Console.ReadKey(true).KeyChar;
            switch (key)
            {
                case '1':
                    //LÄNK TILL PIZZOR
                    Console.WriteLine("Pizza");
                    break;
                case '2':
                    // LÄNK TILL PASTA
                    Console.WriteLine("Pasta");
                    break;
                default:
                    break;
            }
        }
    }
}
