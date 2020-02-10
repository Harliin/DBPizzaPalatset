using System;
using System.Threading.Tasks;
using Food;
using Npgsql;

namespace DB_Kassörska
{
    public class Program
    {
        public static CashierRepository repo;
        static public async Task Main()
        {
            await ChooseBackend();
            Cashier cashier = new Cashier();
            await cashier.CashierManagement();
        }

        public static async Task ChooseBackend()//Väljer backend mellan MSSQL och PostgreSQL
        {
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
