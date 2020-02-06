using DB_OrderInfo.Food;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DB_OrderInfo
{
    class Program
    {
        public static OrderInfoRepository repo;
        static async Task Main(string[] args)
        {
            await ChooseBackend();

            do
            {
                string pizzalogo = "\t|\tPIZZERIA PALATSET\t    |";
                Console.WriteLine("\t ___________________________________");
                Console.WriteLine("\t|                                   |");
                Console.WriteLine(pizzalogo);
                Console.WriteLine("\t|___________________________________|\n");
                await Run();
                Thread.Sleep(1550);  // Sidan uppdateras varje 1,5 sekunder
                Console.Clear();
            } while (true);
        }
        static async Task Run()
        {
            OrderInfoRepository repository = new OrderInfoRepository();

            // Printar ut pågående och färdiga ordrar
            Console.WriteLine("Pågående ordrar:\n");
            foreach (Order ongoingOrder in await repository.OngoingOrder())
            {
                Console.WriteLine(ongoingOrder.ID);
            }

            Console.WriteLine("\nFärdiga ordrar:\n");
            foreach (Order completeOrder in await repository.CompleteOrder())
            {
                Console.WriteLine(completeOrder.ID);
            }
        }
        private static async Task ChooseBackend()//Väljer backend mellan MSSQL och PostgreSQL
        {
            Console.Clear();
            Console.WriteLine("[1]MSSQL\n[2]PostgreSQL");
            Console.Write("Välj Backend: ");
            if (int.TryParse(Console.ReadLine(), out int backend))
            {
                if (backend == 1)//MSSQL
                {
                    OrderInfoRepository.Backend = backend;
                    repo = new OrderInfoRepository();
                    return;
                }
                else if (backend == 2)//PostgreSQL
                {
                    OrderInfoRepository.Backend = backend;
                    repo = new OrderInfoRepository();
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
