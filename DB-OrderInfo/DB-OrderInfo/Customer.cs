using System;
using System.Collections.Generic;
using System.Text;

namespace DB_OrderInfo
{
    public class Customer
    {
        public int ID { get; set; }
        private static int IDCounter = 1;

        public Customer()
        {
            ID = IDCounter;
            IDCounter++;
        }
    }
}
