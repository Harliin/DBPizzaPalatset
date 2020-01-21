using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DB_Kock
{
    class Program
    {
        static void Main(string[] args)
        {
            Display.DrawStartMenu();
            Display.DrawMultipleChoiceMenu();
        }
          
    }
}
