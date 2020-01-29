using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.WriteLine("Alla ordrar:");
            //Console.SetCursorPosition(17, 6);
            Console.WriteLine("-----------------------------------");
            //Console.SetCursorPosition(17, 7);

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

                }
            }
            
            
            

            //char cashierChoice = Console.ReadKey(true).KeyChar;

            //switch (cashierChoice)
            //{
            //    case '1':
            //        Console.SetCursorPosition(67, 25);
            //        await repo.MarkOrderAsCollectedAsync(1);
            //        Console.ReadKey();
            //        await CashierManagement();
            //        break;

            //    default:
            //        Console.WriteLine("Fel inmatning!");
            //        Console.ReadKey(true);
            //        await CashierManagement();
            //        break;
            //}
        }
    }
}
