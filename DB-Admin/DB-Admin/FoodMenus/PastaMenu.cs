using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DB_Admin
{
    public class PastaMenu
    {
        public static async Task PastaAsync()
        {
            var repo = new AdminRepository();
            Console.Clear();
            Console.WriteLine("\t*Pasta Meny*\n\n[1]Lägg till Pasta\n[2]Ta bort Pasta\n[3]Visa Pastor\n\n[5]Tillbaka");
            char adminChoice = Console.ReadKey(true).KeyChar;
            Console.Clear();
            switch (adminChoice)
            {
                case '1':
                    Console.WriteLine("*Lägger till pasta i DB*");
                    Console.ReadKey();
                    await PastaAsync();
                    break;
                case '2':
                    Console.WriteLine("*Tar bort pasta i DB*");
                    Console.ReadKey();
                    await PastaAsync();
                    break;
                case '3':
                    foreach (var pasta in await repo.ShowPastasAsync())
                    {
                        Console.WriteLine($"Namn:{pasta.Name}  Pris:{pasta.Price}");
                    }
                    Console.ReadKey();
                    await PastaAsync();
                    break;
                case '5':
                {
                    await FoodMenu.ManageMenuAsync();
                    break;
                }
                default:
                    Console.WriteLine("Fel inmatning!");
                    Console.ReadKey(true);
                    await PastaAsync();
                    break;
            }
        }
    }
}
