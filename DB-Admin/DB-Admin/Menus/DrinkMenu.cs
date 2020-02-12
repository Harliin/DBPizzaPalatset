using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Food;
using System.Linq;

namespace DB_Admin
{
    public class DrinkMenu//Drink menyn hanterar menyn och dess funktioner
    {
        public static AdminRepository repo;
        public async Task DrinksAsync()//Hanterar menyn för Drinks
        {
            repo = Program.repo;
            Console.Clear();
            Console.WriteLine("\t*Dryckes Meny*\n\n[1]Lägg till Dryck\n[2]Ta bort Dryck\n[3]Visa Drycker\n\n[5]Tillbaka");
            char adminChoice = Console.ReadKey(true).KeyChar;
            Console.Clear();
            switch (adminChoice)
            {
                case '1':
                    await CreateDrink();
                    break;
                case '2':
                    await DeleteDrink();
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
                    FoodMenu foodMenu = new FoodMenu();
                    await foodMenu.ManageMenuAsync();
                    break;
                }
                default:
                    Console.WriteLine("Fel inmatning!");
                    Console.ReadKey(true);
                    await DrinksAsync();
                    break;
            }
        }
        private async Task CreateDrink()//Lägger till en dricka i DB
        {
            Console.Write("Namn: ");
            string FoodName = Console.ReadLine();
            Console.Write("Pris: ");
            int FoodPrice = Convert.ToInt32(Console.ReadLine());
            
            await repo.AddDrinkAsync(FoodName, FoodPrice);
            
            Console.WriteLine("Dricka tillagd!");
            Console.ReadKey();
            await DrinksAsync();
        }

        private async Task DeleteDrink()//Metod för att ta bort Drickor från databasen
        {
            var drinks = await repo.ShowDrinksAsync();
            
            List<Drink> listOfDrinks = drinks.ToList();
            foreach (var drink in listOfDrinks)
            {
                Console.WriteLine($"ID:{drink.ID}  Dricka:{drink.Name}");
            }

            Console.Write("Ange drickans ID för att ta bort: ");
            if (int.TryParse(Console.ReadLine(), out int userChoice))
            {
                if (listOfDrinks.Exists(x => x.ID == userChoice))//Kollar om id finns
                {
                    await repo.DeleteDrinkAsync(userChoice);
                    Console.WriteLine("Drycken är borttagen");
                }
                else
                {
                    Console.WriteLine("Finns ingen dryck med det IDet!");
                }
            }
            else
            {
                Console.WriteLine("Fel inmatning!");
            }
            Console.ReadKey();
            await DrinksAsync();
        }
    }
}
