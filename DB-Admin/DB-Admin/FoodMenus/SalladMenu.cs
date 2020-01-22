using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DB_Admin
{
    public class SalladMenu
    {
        public static async Task SalladAsync()
        {
            var repo = new AdminRepository();
            Console.Clear();
            Console.WriteLine("\t*Sallad Meny*\n\n[1]Lägg till Sallad\n[2]Ta bort Sallad\n[3]Visa Sallader\n\n[5]Tillbaka");
            char adminChoice = Console.ReadKey(true).KeyChar;
            Console.Clear();
            switch (adminChoice)
            {
                case '1':
                    Console.WriteLine("*Lägger till sallad i DB*");
                    Console.ReadKey();
                    await SalladAsync();
                    break;
                case '2':
                    Console.WriteLine("*Tar bort sallad i DB*");
                    Console.ReadKey();
                    await SalladAsync();
                    break;
                case '3':
                    foreach (var sallad in await repo.ShowSalladsAsync())
                    {
                        Console.WriteLine($"Namn:{sallad.Name}  Pris:{sallad.Price}");
                    }
                    Console.ReadKey();
                    await SalladAsync();
                    break;
                case '5':
                {
                    await FoodMenu.ManageMenuAsync();
                    break;
                }
                default:
                    Console.WriteLine("Fel inmatning!");
                    Console.ReadKey(true);
                    await SalladAsync();
                    break;
            }
        }
    }
}
