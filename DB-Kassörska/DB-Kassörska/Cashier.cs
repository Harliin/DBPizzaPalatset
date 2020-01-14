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

            Console.WriteLine("----------------------------------");
            getCurrentOrders();
            getCompleteOrders();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("[1] Markera order som uthämtad");

            char cashierChoice = Console.ReadKey(true).KeyChar;

            switch (cashierChoice)
            {
                case '1':
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
            Console.WriteLine("Pågående ordrar: Hämtar från DB...");
        }

        public static void getCompleteOrders()
        {
            Console.WriteLine("Färdiga ordrar: Hämtar från DB...");
        }

        public static void markOrderAsCollected()
        {
            Console.WriteLine("Markerar order som uthämtad i DB...");
        }

    }


}
