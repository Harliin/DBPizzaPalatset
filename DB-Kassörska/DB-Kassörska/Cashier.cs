using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DB_Kassörska
{
    class Cashier
    {
        /*TODO
         * Felhantering om man skriver in fel nummer, bokstav osv. While (correctKey == false) osv
         */

        CashierRepository repo = new CashierRepository();
        public int correctKey { get; set; }
        public async Task CashierManagement() //Kassörskans meny
        {
            var orders = await repo.ShowAllOrdersAsync();
            List<Order> orderList = orders.ToList();

            Console.Clear();

            Console.WriteLine("--Kassörterminal--");
            Console.WriteLine("Alla ordrar:");
            Console.WriteLine("-----------------------------------");

            foreach (var order in orders)
            {
                Console.WriteLine($"Order-ID: {order.ID} Orderstatus: {order.Status}");
            }

            Console.WriteLine();
            Console.WriteLine("Färdiga ordrar:");
            Console.WriteLine("-----------------------------------");

            foreach (var order in await repo.ShowOrderByIDAsync(2))
            {
                Console.WriteLine($"Order-ID: {order.ID} Orderstatus: {order.Status}");
            }

            Console.Write("Markera order som uthämtad (ange ordernummer och tryck enter): ");

            if (int.TryParse(Console.ReadLine(), out int cashierOrderChoice))
            {
                if (orderList.Exists(x => x.ID == cashierOrderChoice))
                {
                    await repo.UpdateOrderStatus(cashierOrderChoice);
                    Console.WriteLine($"Markerar order {cashierOrderChoice} som uthämtad");
                    Thread.Sleep(2000);
                    await CashierManagement();
                }
                else
                {
                    Console.WriteLine("Ordernumret finns inte!");
                    Thread.Sleep(2000);
                    await CashierManagement();
                }
            }
        }
    }
}
