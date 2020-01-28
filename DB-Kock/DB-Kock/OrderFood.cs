using Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB_Kock
{
    public class OrderFood
    {
        public int OrderID { get; set; }
        public int PizzaID { get; set; }
        public int PastaID { get; set; }
        public int SalladID { get; set; }
        public int DrinkID { get; set; }
        public int ExtraID { get; set; }
        public List<Pizza> Pizzas { get; set; }
        public List<Pasta> Pastas { get; set; }
        public List<Sallad> Sallad { get; set; }
        public List<Drink> Drinks { get; set; }
        public List<Extra> Extras { get; set; }

    }
}
