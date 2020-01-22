using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DB_Admin
{
    public class DrinkMenu
    {
        public static async Task DrinksAsync()
        {
            var repo = new AdminRepository();
            Console.Clear();
            Console.WriteLine("\t*Dryckes Meny*\n\n[1]Lägg till Dryck\n[2]Ta bort Dryck\n[3]Visa Drycker\n\n[5]Tillbaka");
            char adminChoice = Console.ReadKey(true).KeyChar;
            Console.Clear();
            switch (adminChoice)
            {
                case '1':
                    Console.WriteLine("*Lägger till dryck i DB*");
                    Console.ReadKey();
                    await DrinksAsync();
                    break;
                case '2':
                    Console.WriteLine("*Tar bort dryck i DB*");
                    Console.ReadKey();
                    await DrinksAsync();
                    break;
                case '3':
                    foreach (var drink in await repo.ShowDrinksAsync())
                    {
                        Console.WriteLine($"Namn:{drink.Name}  Pris:{drink.Price}");
                    }
                    Console.ReadKey();
                    await DrinksAsync();
                    break;
                case '5':
                {
                    await FoodMenu.ManageMenuAsync();
                    break;
                }
                default:
                    Console.WriteLine("Fel inmatning!");
                    Console.ReadKey(true);
                    await DrinksAsync();
                    break;
            }
        }
    }
}
