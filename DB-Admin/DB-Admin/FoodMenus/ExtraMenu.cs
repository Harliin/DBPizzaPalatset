using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Food;
using System.Linq;

namespace DB_Admin
{
    public class ExtraMenu//Extra menyn hanterar menyn och dess funktioner
    {
        public static AdminRepository repo = new AdminRepository();
        public static async Task ExtrasAsync()//Meny för att hantera extra val
        {
            Console.Clear();
            Console.WriteLine("\t*Tillbehörs Meny*\n\n[1]Lägg till Tillbehör\n[2]Ta bort Tillbehör\n[3]Visa Tillbehör\n\n[5]Tillbaka");
            char adminChoice = Console.ReadKey(true).KeyChar;
            Console.Clear();
            switch (adminChoice)
            {
                case '1':
                    await CreateExtra();
                    break;
                case '2':
                    await DeleteExtra();
                    break;
                case '3':
                    foreach (var extra in await repo.ShowExtraAsync())
                    {
                        Console.WriteLine($"Namn:{extra.Name}  Pris:{extra.Price}");
                    }
                    Console.ReadKey();
                    await ExtrasAsync();
                    break;
                case '5':
                {
                    await FoodMenu.ManageMenuAsync();
                    break;
                }
                default:
                    Console.WriteLine("Fel inmatning!");
                    Console.ReadKey(true);
                    await ExtrasAsync();
                    break;
            }
        }
        private static async Task CreateExtra()//Lägger till tillbehör i DB
        {
            Console.Write("Namn: ");
            string FoodName = Console.ReadLine();
            Console.Write("Pris: ");
            int FoodPrice = Convert.ToInt32(Console.ReadLine());
            await repo.AddExtraAsync(FoodName, FoodPrice);

            Console.WriteLine("Tillbehör tillagd!");
            Console.ReadKey();
            await ExtrasAsync();
        }

        private static async Task DeleteExtra()//Tar bort ett tillbehör från DB
        {
            var extras = await repo.ShowExtraAsync();
            List<Extra> listOfExtras = extras.ToList();
            foreach (var extra in listOfExtras)
            {
                Console.WriteLine($"ID:{extra.ID}  Tillbehör:{extra.Name}");
            }

            Console.Write("Ange tillbehörets ID för att ta bort: ");
            if (int.TryParse(Console.ReadLine(), out int userChoice))
            {
                if (listOfExtras.Exists(x => x.ID == userChoice))//Kollar om id finns
                {
                    await repo.DeleteDrinkAsync(userChoice);
                    Console.WriteLine("Tillbehöret togs bort!");
                }
                else
                {
                    Console.WriteLine("Finns ingen tillbehör med det IDet!");
                }
            }
            else
            {
                Console.WriteLine("Fel inmatning!");
            }
            Console.ReadKey();
            await ExtrasAsync();
        }
    }
}
