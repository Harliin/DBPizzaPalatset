using System;
using System.Collections.Generic;
using System.Text;

namespace DB_OrderInfo
{
    /*Subklass till Person. Skapar en kund och tilldelar kunden ett kredit/banksaldo.*/
    public class Customer 
    {
        public int ID { get; set; }
        private static int IDCounter = 1;
        public Customer() /*Customer klassen i version @1.0 har funktionaliteten för att använda kredit,
                            men det kan implementeras i senare versioner om nödvändigt*/
        {
            ID = IDCounter;
            IDCounter++;
        }
    }
}
