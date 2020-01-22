using DB_OrderInfo.Food;
using System;
using System.Threading.Tasks;

namespace DB_OrderInfo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Välkommen till PIZZERIA PALATSET !\n");
            Console.WriteLine("Pågående ordrar:\n");
            OrderInfoRepository repository = new OrderInfoRepository();

            //foreach (Pizza pizzas in await repository.Pizzas())
            //{
            //    Console.WriteLine($"{pizzas.Name}");
            //}

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
