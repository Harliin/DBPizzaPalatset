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
        public static CashierRepository repo = new CashierRepository();
        public int correctKey { get; set; }
        public async Task CashierManagement() //Kassörskans meny
        {
            var orders = await repo.ShowAllOrdersAsync();
            List<Order> orderList = orders.ToList();

            Console.Clear();

            Console.WriteLine("--Kassörterminal--");
            Console.WriteLine();
            Console.WriteLine("Pågående ordrar:");
            Console.WriteLine("-----------------------------------");

            foreach (var order in orders)
            {
                if(order.Status!=eStatus.Avhämtat && order.Status!=eStatus.Klar)
                {
                    Console.WriteLine($"Order-ID: {order.ID}\tStatus: {order.Status}");
                }
            } //Skriver ut pågående ordrar

            Console.WriteLine();
            Console.WriteLine("Ordrar färdiga att hämtas ut:");
            Console.WriteLine("-----------------------------------");

            foreach (var order in await repo.ShowOrderByStatusAsync(eStatus.Klar))
            {
                Console.WriteLine($"Order-ID: {order.ID}\tStatus: {order.Status}");
            } // Skriver ut färdiga ordrar

            Console.WriteLine();
            Console.Write("Välj Order-ID som har status \"Klar\", när kunden hämtat ut den: ");

            IEnumerable<Order> ordersByStatus = await repo.ShowOrderByStatusAsync(eStatus.Klar);

            List<Order> listOfOrders = ordersByStatus.ToList();

            do
            {

            }

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
