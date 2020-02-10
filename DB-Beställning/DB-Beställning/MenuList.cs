using System;
using System.Collections.Generic;
using System.Text;

namespace DB_Beställning
{
    class MenuList
    {

        // Lista som visar maträttsmenyn
        public static List<string> FoodMenu = new List<string>
        {
            "************Matmeny***************\n",
            "Välj den typ av mat som du vill beställa:",
            "-------------",
            "1. Pizza",
            "2. Pasta",
            "3. Sallad",
            "4. Dryck",
            "5. Extra\n",
            "6. Ändra order",
            "7. Betala",

            "-------------",
            "9. Avsluta"
        };

    }
}
