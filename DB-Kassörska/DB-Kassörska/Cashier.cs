using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Kassörska
{
    class Cashier
    {
        /*TODO
         * Felhantering om man skriver in fel nummer, bokstav osv. While (correctKey == false) osv
         */
        public int correctKey { get; set; }
        public async Task CashierManagement()
        {
            CashierRepository repo = new CashierRepository();

            Console.Clear();

            
            Console.WriteLine("--Kassörterminal--");

            Console.WriteLine("Alla ordrar:");
            Console.WriteLine("-----------------------------------");

            var orders = await repo.ShowAllOrdersAsync();
            List<Order> orderList = orders.ToList();

            foreach (var order in await repo.ShowAllOrdersAsync())
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

            Console.SetCursorPosition(67, 25);

            Console.WriteLine("Markera order som uthämtad (ange ordernummer och tryck enter)");

            if(int.TryParse(Console.ReadLine(), out int cashierOrderChoice))
            {
                if(orderList.Exists(x => x.ID == cashierOrderChoice))
                {
                    await repo.UpdateOrderStatus(cashierOrderChoice);
                }
                else
                {
                    Console.WriteLine("Ordernumret finns inte!");
                }
            }
        }
    }
}
