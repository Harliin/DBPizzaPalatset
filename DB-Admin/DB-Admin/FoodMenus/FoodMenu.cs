using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DB_Admin
{
    public class FoodMenu//Hantera styrningen mellan alla mat menyer
    {
        public static async Task ManageMenuAsync()
        {
            Console.Clear();
            Console.WriteLine("\t*Matmeny*\n\n[1]Hantera Pizzor\n[2]Hantera Pastarätter\n[3]Hantera Sallader\n[4]Hantera Drycker\n[5]Hantera Tillbehör\n\n[6]Tillbaka till Huvudmeny");
            char adminChoice = Console.ReadKey(true).KeyChar;
            switch (adminChoice)
            {
                case '1':
                    await PizzaMenu.PizzaAsync();
                    break;
                case '2':
                    await PastaMenu.PastaAsync();
                    break;
                case '3':
                    await SalladMenu.SalladAsync();
                    break;
                case '4':
                    await DrinkMenu.DrinksAsync();
                    break;
                case '5':
                    await ExtraMenu.ExtrasAsync();
                    break;
                case '6':
                    await Program.AdminStartMenuAsync();
                    break;

                default:
                    Console.WriteLine("Fel inmatning!");
                    Console.ReadKey(true);
                    await ManageMenuAsync();
                    break;
            }
        }
    }
}
