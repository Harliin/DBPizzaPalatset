using System;
using System.Collections.Generic;
using System.Text;

namespace DB_Beställning
{
    public class OrderFood
    {
        public int OrderID { get; set; }
        public int PizzaID { get; set; }
        public int PastaID { get; set; }
        public int SalladID { get; set; }
        public int DrinkID { get; set; }
        public int ExtraID { get; set; }

    }
}
