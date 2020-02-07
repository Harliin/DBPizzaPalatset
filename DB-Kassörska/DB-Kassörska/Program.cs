using System;
using System.Threading.Tasks;
using Food;
using Npgsql;

namespace DB_Kassörska
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Cashier cashier = new Cashier();

            await cashier.CashierManagement();
        }

        private static async Task ChooseBackend()//Väljer backend mellan MSSQL och PostgreSQL
        {
            CashierRepository repo;
            Console.Clear();
            Console.WriteLine("[1]MSSQL\n[2]PostgreSQL");
            Console.Write("Välj Backend: ");
            if (int.TryParse(Console.ReadLine(), out int backend))
            {
                if (backend == 1)//MSSQL
                {
                    CashierRepository.Backend = backend;
                    repo = new CashierRepository();
                    return;
                }
                else if (backend == 2)//PostgreSQL
                {
                    CashierRepository.Backend = backend;
                    repo = new CashierRepository();
                    return;
                }
                else
                {
                    Console.WriteLine("Ange en korrekt siffra!");
                    Console.ReadKey(true);
                    await ChooseBackend();
                }
            }
            else
            {
                Console.WriteLine("Fel inmatat!");
                Console.ReadKey(true);
                await ChooseBackend();
            }
        }
    }
}
