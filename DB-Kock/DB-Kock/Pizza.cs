using System;
using System.Collections.Generic;
using System.Text;

namespace DB_Kock
{
    public class Pizza
    {
        //denna kan möjligen tas bort om pizza är kopplad till order
        public static void GetPizza()
        {
            Console.WriteLine("*Hänta pizzas från databasen*");
        }

        public static void GetIngredients()
        {
            Console.WriteLine("*Hänta ingredienser från databasen*");
        }

    }
}

  