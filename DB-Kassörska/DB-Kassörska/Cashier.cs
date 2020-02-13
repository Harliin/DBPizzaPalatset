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
        public async Task CashierManagement() //Kassörskans meny
        {
            do
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
                    if (order.Status != eStatus.Avhämtat && order.Status != eStatus.Klar)
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

                //Markera order som uthämtad
                IEnumerable<Order> ordersByStatus = await repo.ShowOrderByStatusAsync(eStatus.Klar);

                List<Order> listOfOrders = ordersByStatus.ToList();

                int orderid = GetValidOrderID(listOfOrders);
                await repo.UpdateOrderStatus(orderid);
                Console.WriteLine($"Markerar order {orderid} som uthämtad");
                Thread.Sleep(2000);
                await CashierManagement();
            }
            while (true);
        }

        //Syftet med funktionen är att returnera ett giltigt orderID.
        //Giltigt orderID är ett nummer som finns i listan över färdiga ordrar
        private int GetValidOrderID(List<Order> listOfOrders)
        {
            bool isValid;
            int orderID = -1;
            do
            {
                isValid = int.TryParse(Console.ReadLine(), out int cashierOrderChoice);
                if (isValid)
                {
                    if ((listOfOrders.Exists(x => x.ID == cashierOrderChoice)))
                    {
                        orderID = cashierOrderChoice;
                    }
                    else
                    {
                        isValid = false;
                    }
                }
                
                if(isValid==false)
                {
                    Console.Write("Ordernumret är ogiltigt! Ange nytt ordernummer: ");
                }
            }
            while (isValid == false);
            return orderID;
        }
    }
}