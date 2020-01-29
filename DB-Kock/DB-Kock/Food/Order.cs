using Food;
using System;
using System.Collections.Generic;
using System.Text;


namespace DB_Kock.Food
{
    public class Order
    {
        public int ID { get; set; }
        public eStatus Status { get; set; }
        public enum eStatus { UnderBeställning = 1, Tillagning = 2, Klar = 3, Avhämtat = 4}
        public List<Pizza> pizza { get; set; }
        public List<Pasta> pasta { get; set; }
        public List<Sallad> sallad { get; set; }
        public List<Drink> drink { get; set; }
        public List<Extra> extra { get; set; }
    }
}
