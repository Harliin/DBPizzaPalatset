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
        CashierRepository repo = new CashierRepository();
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
            }

            Console.WriteLine();
            Console.WriteLine("Ordrar färdiga att hämtas ut:");
            Console.WriteLine("-----------------------------------");

            foreach (var order in await repo.ShowOrderByStatusAsync(eStatus.Klar))
            {
                Console.WriteLine($"Order-ID: {order.ID}\tStatus: {order.Status}");
            }

            Console.WriteLine();
            Console.Write("Välj Order-ID som har status \"Klar\", när kunden hämtat ut den: ");

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

        public async Task ChooseBackend()//Väljer backend mellan MSSQL och PostgreSQL
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
