using DB_OrderInfo.Food;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DB_OrderInfo
{
    class Program
    {
        static async Task Main(string[] args)
        {

            do
            {
                Console.WriteLine("Välkommen till PIZZERIA PALATSET !\n");
                await Run();
                Thread.Sleep(1500);
                Console.Clear();
            } while (true);
        }
        static async Task Run()
        {
            OrderInfoRepository repository = new OrderInfoRepository();

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

    }
}
