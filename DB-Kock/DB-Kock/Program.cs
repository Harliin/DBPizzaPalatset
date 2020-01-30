using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Food;

namespace DB_Kock
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var repo = new ChefRepository();
            if (await Display.DrawStartMenuAsync())
            {
                await Display.DrawMultipleChoiceMenu();
            }
            else
            {
                Console.WriteLine();
            }
          
            

          
        }
          
    }
}
