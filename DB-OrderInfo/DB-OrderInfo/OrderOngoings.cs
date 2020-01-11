using System;
using System.Collections.Generic;
using System.Threading;

namespace DB_OrderInfo
{
    /*Denna klass hanterar de pågående ordrarna,
      den kan lägga till, ta bort samt skriva ut pågående ordrar*/
    public class OrdersOngoing
    {
        public List<Customer> OngoingOrderID;


        public OrdersOngoing()
        {
            this.OngoingOrderID = new List<Customer>();
        }

        public void ShowOngoingOrders()/*Skriver ut pågående ordrar*/
        {

            foreach (Customer customer in OngoingOrderID)
            {
                Console.WriteLine($"#ID: {customer.ID}");
            }
        }

        public void NewOrder() /*Skapar en ny order och lägger till den i Listan för ordrar*/
        {
            Customer customer = new Customer();
            if (customer.ID % 2 == 0)
                Thread.Sleep(1000);
            OngoingOrderID.Add(customer);
        }

        public Customer FinishedOrder()/*Flyttar över en pågående order till färdig order.
                                        Samt tar bort den pågående ordern*/
        {
            Customer customer = OngoingOrderID[0];
            OngoingOrderID.Remove(OngoingOrderID[0]);
            return customer;
        }


    }
}
