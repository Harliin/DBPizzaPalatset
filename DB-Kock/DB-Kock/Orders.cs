using System;
using System.Collections.Generic;
using System.Text;

namespace DB_Kock
{
   public class Orders
    {
        public int OrderNummer { get; set; }
        List<Pizza> orders = new List<Pizza>();

        public Orders()
        {

        }

        public int CreateOrderNummer()
        {
            Random r = new Random();
            int OrderNummer = r.Next(1, 100);
            return OrderNummer;
        }

     
      

    }
}
