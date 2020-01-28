using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DB_Kassörska
{
    class Cashier
    {
        public async Task CashierManagement()
        {
            CashierRepository repo = new CashierRepository();

            Console.Clear();
            Console.WriteLine("--Kassörterminal--");

            //Console.SetCursorPosition(17, 5);
            Console.WriteLine("Pågående ordrar:");
            //Console.SetCursorPosition(17, 6);
            Console.WriteLine("-----------------------------------");
            //Console.SetCursorPosition(17, 7);
            foreach (var order in await repo.ShowOngoingOrdersAsync())
            {
                Console.WriteLine($"Order-ID: {order.ID} Orderstatus: {order.Status}");
            }

            Console.WriteLine();
            //Console.SetCursorPosition(67, 5);
            Console.WriteLine("Färdiga ordrar:");
            //Console.SetCursorPosition(67, 6);
            Console.WriteLine("-----------------------------------");
            //Console.SetCursorPosition(67, 7);
            foreach (var order in await repo.ShowFinishedOrdersAsync())
            {
                Console.WriteLine($"Order-ID: {order.ID} Orderstatus: {order.Status}");
            }

            Console.SetCursorPosition(67, 25);
            Console.WriteLine("[1] Markera order som uthämtad");

            char cashierChoice = Console.ReadKey(true).KeyChar;

            switch (cashierChoice)
            {
                case '1':
                    Console.SetCursorPosition(67, 25);
                    await repo.DeleteOrderAsync(1);
                    Console.ReadKey();
                    await CashierManagement();
                    break;

                default:
                    Console.WriteLine("Fel inmatning!");
                    Console.ReadKey(true);
                    await CashierManagement();
                    break;
            }
        }
    }
}
