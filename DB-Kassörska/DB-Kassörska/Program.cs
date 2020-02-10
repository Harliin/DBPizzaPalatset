using System;
using System.Threading.Tasks;
using Food;
using Npgsql;

namespace DB_Kassörska
{
    class Program
    {
        static public async Task Main(string[] args)
        {
            Cashier cashier = new Cashier();

            await cashier.ChooseBackend();
            await cashier.CashierManagement();
        
        }
    }
}
