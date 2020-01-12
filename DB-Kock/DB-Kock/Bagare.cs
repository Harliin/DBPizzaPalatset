using System;
using System.Collections.Generic;
using System.Text;

namespace DB_Kock
{
    class Bagare
    {
        public int Pin { get; set; }
        public string Name { get; set; }
        public Bagare(int pin, string name)
        {
            this.Pin = pin;
            this.Name = name;
        }


    }
}