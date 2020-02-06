using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food;

namespace DB_Admin
{
    public class SalladMenu//Sallad menyn hanterar menyn och dess funktioner
    {
        public static AdminRepository repo = new AdminRepository();
        public async Task SalladAsync()//Huvud meny för sallad
        {
            
            Console.Clear();
            Console.WriteLine("\t*Sallad Meny*\n\n[1]Lägg till Sallad\n[2]Ta bort Sallad\n[3]Visa Sallader\n\n[5]Tillbaka");
            char adminChoice = Console.ReadKey(true).KeyChar;
            Console.Clear();
            switch (adminChoice)
            {
                case '1':
                    await CreateSallad();
                    break;


                case '2':
                    await DeleteSallad();
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
                    FoodMenu foodMenu = new FoodMenu();
                    await foodMenu.ManageMenuAsync();
                    break;
                }
                default:
                    Console.WriteLine("Fel inmatning!");
                    Console.ReadKey(true);
                    await SalladAsync();
                    break;
            }
        }

        private async Task CreateSallad()//Metod för att lägga till sallad i DB
        {
            Console.Write("Namn: ");
            string FoodName = Console.ReadLine();
            Console.Write("Pris: ");
            int FoodPrice = Convert.ToInt32(Console.ReadLine());
            await repo.AddSalladAsync(FoodName, FoodPrice);

            Console.WriteLine("Sallad tillagd!");
            Console.ReadKey();
            await SalladAsync();
        }

        private async Task DeleteSallad()//Metod för att ta bort sallad i DB
        {
            var sallads = await repo.ShowSalladsAsync();
            List<Sallad> listOfSallads = sallads.ToList();
            foreach (var sallad in listOfSallads)
            {
                Console.WriteLine($"ID:{sallad.ID}  Sallad:{sallad.Name}");
            }

            Console.Write("Ange sallads ID för att ta bort: ");
            if (int.TryParse(Console.ReadLine(), out int userChoice))
            {
                if (listOfSallads.Exists(x => x.ID == userChoice))//Kollar om id finns
                {
                    await repo.DeletePastaAsync(userChoice);
                    Console.WriteLine("Salladen är borttagen");
                }
                else
                {
                    Console.WriteLine("Finns ingen sallad med det IDet!");
                }
            }
            else
            {
                Console.WriteLine("Fel inmatning!");
            }

            Console.ReadKey();
            await SalladAsync();
        }
    }
}
