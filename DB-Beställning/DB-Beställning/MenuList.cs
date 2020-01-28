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
            "Välj den typ av mat som du vill beställa:",
            "-------------\n",
            "1. Pizza",
            "2. Pasta",
            "3. Sallad",
            "4. Dryck",
            "5. Visa pågående order\n",

            "-------------",
            "6. Avsluta"
        };

    }
}
