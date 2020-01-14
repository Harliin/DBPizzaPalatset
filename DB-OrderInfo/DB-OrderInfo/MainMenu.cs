using System;

namespace DB_OrderInfo
{
    class MainMenu
    {
        public void Run()
        {
            string pizzalogo = "\t|\tPIZZERIA PALATSET\t    |";
            Console.WriteLine("\t ___________________________________");
            Console.WriteLine("\t|                                   |");
            Console.WriteLine(pizzalogo);
            Console.WriteLine("\t|___________________________________|");

            Console.WriteLine($"\nPågående ordrar\t\t\tKlara ordrar");
            Console.WriteLine($"");

            do
            {
                GenerateNewOrder();
            } while (true);
        }

        public void GenerateNewOrder()
        {
            // här ska genereras nykommande ordrar
        }
        public void CompleteOrder()
        {
            // här ska färdiga ordrar
        }
    }
}
