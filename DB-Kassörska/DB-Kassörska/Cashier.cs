using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static DB_Kassörska.Order;

namespace DB_Kassörska
{
    class Cashier
    {
        /*TODO
         * Gör så att kassörskan bara kan markera ordrar som står som "Klar"
         */

        CashierRepository repo = new CashierRepository();
        public int correctKey { get; set; }
        public async Task CashierManagement() //Kassörskans meny
        {
            var orders = await repo.ShowAllOrdersAsync();
            List<Order> orderList = orders.ToList();

            Console.Clear();

            Console.WriteLine("--Kassörterminal--");
            Console.WriteLine();
            Console.WriteLine("Alla ordrar:");
            Console.WriteLine("-----------------------------------");

            foreach (var order in orders)
            {
                if(order.Status!=eStatus.Avhämtat)
                {
                    Console.WriteLine($"Order-ID: {order.ID} Orderstatus: {order.Status}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Färdiga ordrar:");
            Console.WriteLine("-----------------------------------");

            foreach (var order in await repo.ShowOrderByStatusAsync(eStatus.Klar))
            {
                Console.WriteLine($"Order-ID: {order.ID} Orderstatus: {order.Status}");
            }

            Console.WriteLine();
            Console.Write("Markera order som uthämtad (ange ordernummer och tryck enter): ");

            IEnumerable<Order> ordersByStatus = await repo.ShowOrderByStatusAsync(eStatus.Klar);

            List<Order> listOfOrders = ordersByStatus.ToList();

            if (int.TryParse(Console.ReadLine(), out int cashierOrderChoice))
            {
                if ((listOfOrders.Exists(x => x.ID == cashierOrderChoice)))
                {
                    await repo.UpdateOrderStatus(cashierOrderChoice);
                    Console.WriteLine($"Markerar order {cashierOrderChoice} som uthämtad");
                    Thread.Sleep(2000);
                    await CashierManagement();
                }
                else
                {
                    Console.WriteLine("Ordernumret är ogiltigt!");
                    Thread.Sleep(2000);
                    await CashierManagement();
                }
            }
            else
            {
                Console.WriteLine("Skriv endast siffror!");
                Thread.Sleep(2000);
                await CashierManagement();
            }
        }
    }
}
