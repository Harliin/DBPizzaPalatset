using System;
using System.Collections.Generic;
using System.Text;

namespace DB_Admin.Food
{
    public class Order
    {
        public int ID { get; set; }
        public enum Status { Pågående = 1, Klar = 2 }
    }
}
