using System;
using System.Collections.Generic;
using System.Text;

namespace DB_Admin
{
    public class Order
    {
        public int ID { get; set; }

        public eStatus Status { get; set; }
        public enum eStatus { UnderBeställning = 1, Tillagning = 2, Klar = 3, Avhämtad = 4 }

    }
}
