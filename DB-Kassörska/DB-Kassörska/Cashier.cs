using System;
using System.Collections.Generic;
using System.Text;

namespace DB_Kassörska
{
    class Cashier
    {
        public void CashierManagement()
        {
            
            Console.Clear();
            Console.WriteLine("--Kassörterminal--");

            Console.SetCursorPosition(17, 5);
            Console.WriteLine("Pågående ordrar"); 
            Console.SetCursorPosition(17, 6);
            Console.WriteLine("-----------------------------------");
            Console.SetCursorPosition(17, 7);
            getCurrentOrders();

            Console.SetCursorPosition(67, 5);
            Console.WriteLine("Färdiga ordrar");
            Console.SetCursorPosition(67, 6);
            Console.WriteLine("-----------------------------------");
            Console.SetCursorPosition(67, 7);
            getCompleteOrders();

            Console.SetCursorPosition(67, 25);
            Console.WriteLine("[1] Markera order som uthämtad");

            char cashierChoice = Console.ReadKey(true).KeyChar;

            switch (cashierChoice)
            {
                case '1':
                    Console.SetCursorPosition(67, 25);
                    markOrderAsCollected();
                    Console.ReadKey();
                    CashierManagement();
                    break;

                default:
                    Console.WriteLine("Fel inmatning!");
                    Console.ReadKey(true);
                    CashierManagement();
                    break;
            }
        }

        public static void getCurrentOrders()
        {
            Console.WriteLine("Hämtar från databasen...");
        }

        public static void getCompleteOrders()
        {
            Console.WriteLine("Hämtar från databasen...");
        }

        public static void markOrderAsCollected()
        {
            Console.WriteLine("Markerar order som uthämtad i DB...");
        }
    }
}
