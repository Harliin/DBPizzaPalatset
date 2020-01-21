using System;
using System.Collections.Generic;
using System.Text;

namespace DB_Kock
{
    public class ChefFood
    {
        //denna kan möjligen tas bort om pizza är kopplad till order
        public static void GetPizza()
        {
            Console.WriteLine("*Hänta pizzas från databasen*");
        }

        public static void GetSalad()
        {
            Console.WriteLine("*Hänta sallad från databasen*");
        }

        public static void GetPasta()
        {
            Console.WriteLine("*Hänta pasta från databasen*");
        }

        public static void GetIngredients()
        {
            Console.WriteLine("*Hänta ingredienser från databasen*");
        }

    }
}

  