using System;
using Food;

namespace DB_Kassörska
{
    class Program
    {
        static void Main(string[] args)
        {
            Cashier cashier = new Cashier();

            await cashier.CashierManagement();

            
        }
    }
}
