using System;
using System.Collections.Generic;
using System.Text;

namespace DB_Beställning.Food
{
    class Order
    {
        public int ID { get; set; }
        public eStatus Status { get; set; }
        public enum eStatus { Pågående = 1, Tillagning = 2, Klar = 3}
    }
}
