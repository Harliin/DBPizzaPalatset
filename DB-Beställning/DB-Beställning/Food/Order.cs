using Food;
using System.Collections.Generic;

namespace DB_Beställning
{
    public class Order
    {
        public int ID { get; set; }
        public eStatus Status { get; set; }
        public enum eStatus { UnderBeställning = 1, Tillagning = 2, Klar = 3, Avhämtad = 4}
        public List<Pizza> pizza { get; set; }
        public List<Pasta> pasta { get; set; }
        public List<Sallad> sallad { get; set; }
        public List<Drink> drink { get; set; }
        public List<Extra> extra { get; set; }
    }
}
