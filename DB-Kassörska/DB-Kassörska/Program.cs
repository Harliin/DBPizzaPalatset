using System;

namespace DB_Kassörska
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kassörterminal");
            getCurrentOrders();
            getCompleteOrders();
            Console.WriteLine("Tryck 1 för att markera order som uthämtad");

        }

        public static void getCurrentOrders()
        {
            Console.WriteLine("Hämtar pågående ordrar från databasen...");
        }

        public static void getCompleteOrders()
        {
            Console.WriteLine("Hämtar klara ordrar från databasen...");
        }

        public static void markOrderAsComplete()
        {
            Console.WriteLine("Flyttar order till listan över klara ordrar");
        }
    }
}
