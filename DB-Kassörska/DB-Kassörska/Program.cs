using System;
using System.Threading.Tasks;
using Food;

namespace DB_Kassörska
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Cashier cashier = new Cashier();

            int height = Console.WindowHeight;
            int width = Console.WindowWidth;

            await cashier.CashierManagement();

            
        }
    }
}
