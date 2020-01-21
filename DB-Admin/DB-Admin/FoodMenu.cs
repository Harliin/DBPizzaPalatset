using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DB_Admin
{
    public class FoodMenu
    {
        public static async Task ManageMenuAsync()
        {
            Console.Clear();
            Console.WriteLine("\t*Matmeny*\n\n[1]Hantera Pizzor\n[2]Hantera Pastarätter\n[3]Hantera Sallader\n[4]Hantera Drycker\n\n[5]Tillbaka till Huvudmeny");
            char adminChoice = Console.ReadKey(true).KeyChar;
            switch (adminChoice)
            {
                case '1':
                    await PizzaAsync();
                    break;
                case '2':
                    await PastaAsync();
                    break;
                case '3':
                    await SalladAsync();
                    break;
                case '4':
                    await DrinksAsync();
                    break;
                case '5':
                    await Program.AdminStartMenuAsync();
                    break;
                default:
                    Console.WriteLine("Fel inmatning!");
                    Console.ReadKey(true);
                    await ManageMenuAsync();
                    break;
            }
        }
        private static async Task PizzaAsync()
        {
            var repo = new AdminRepository();
            Console.Clear();
            Console.WriteLine("\t*Pizza Meny*\n\n[1]Lägg till Pizza\n[2]Ta bort Pizza\n[3]Visa Standard pizzor\n\n[5]Tillbaka");
            char adminChoice = Console.ReadKey(true).KeyChar;
            Console.Clear();
            switch (adminChoice)
            {
                case '1':
                    Console.WriteLine("*Lägger till pizza i DB*");
                    Console.ReadKey();
                    await PizzaAsync();
                    break;
                case '2':
                    Console.WriteLine("*Tar bort pizza i DB*");
                    Console.ReadKey();
                    await PizzaAsync();
                    break;
                case '3':
                    foreach (var pizza in await repo.ShowPizzasAsync())
                    {
                        Console.WriteLine($"Namn:{pizza.Name}  Pris:{pizza.Price}");
                    }
                    Console.ReadKey();
                    await PizzaAsync();
                    break;
                case '5':
                    {
                        await ManageMenuAsync();
                        break;
                    }
                default:
                    Console.WriteLine("Fel inmatning!");
                    Console.ReadKey(true);
                    await PizzaAsync();
                    break;
            }
        }

        private static async Task PastaAsync()
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
                        await ManageMenuAsync();
                        break;
                    }
                default:
                    Console.WriteLine("Fel inmatning!");
                    Console.ReadKey(true);
                    await PastaAsync();
                    break;
            }
        }

        private static async Task SalladAsync()
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
                        await ManageMenuAsync();
                        break;
                    }
                default:
                    Console.WriteLine("Fel inmatning!");
                    Console.ReadKey(true);
                    await SalladAsync();
                    break;
            }
        }

        private static async Task DrinksAsync()
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
                        await ManageMenuAsync();
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
