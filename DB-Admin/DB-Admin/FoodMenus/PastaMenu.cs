using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food;

namespace DB_Admin
{
    public class PastaMenu
    {
        public static AdminRepository repo = new AdminRepository();
        public static async Task PastaAsync()
        {
            Console.Clear();
            Console.WriteLine("\t*Pasta Meny*\n\n[1]Lägg till Pasta\n[2]Ta bort Pasta\n[3]Visa Pastor\n\n[5]Tillbaka");
            char adminChoice = Console.ReadKey(true).KeyChar;
            Console.Clear();
            switch (adminChoice)
            {
                case '1':
                    Console.Write("Namn: ");
                    string pizzaName = Console.ReadLine();
                    Console.Write("Pris: ");
                    int pizzaPrice = Convert.ToInt32(Console.ReadLine());
                    await repo.AddPastaAsync(pizzaName, pizzaPrice);

                    Console.WriteLine("Pasta tillagd!");
                    Console.ReadKey();
                    await PastaAsync();
                    break;


                case '2':
                    var pastas = await repo.ShowPastasAsync();
                    List<Pasta> listOfPastas = pastas.ToList();
                    foreach (var pasta in listOfPastas)
                    {
                        Console.WriteLine($"ID:{pasta.ID}  Pasta:{pasta.Name}");
                    }

                    Console.Write("Ange Pasta ID för att ta bort: ");
                    if (int.TryParse(Console.ReadLine(), out int userChoice))
                    {
                        if (listOfPastas.Exists(x => x.ID == userChoice))//Kollar om id finns
                        {
                            await repo.DeletePastaAsync(userChoice);
                            Console.WriteLine("Pastan är borttagen");
                        }
                        else
                        {
                            Console.WriteLine("Finns ingen pasta med det IDet!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Fel inmatning!");
                    }

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
