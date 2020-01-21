using System;

namespace DB_Kassörska
{
    class Program
    {
        static void Main(string[] args)
        {
            CashierRepository cashier = new CashierRepository();

            cashier.CashierManagement();
        }
    }
}
