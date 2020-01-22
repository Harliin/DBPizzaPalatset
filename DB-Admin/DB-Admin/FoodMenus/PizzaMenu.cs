using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Food;
using System.Linq;

namespace DB_Admin
{
    public class PizzaMenu
    {
        public static async Task PizzaAsync()
        {
            var repo = new AdminRepository();
            Console.Clear();
            Console.WriteLine("\t*Pizza Meny*\n\n[1]Lägg till Pizza\n[2]Ta bort Pizza\n[3]Visa Standard pizzor\n\n[5]Tillbaka");
            char adminChoice = Console.ReadKey(true).KeyChar;
            Console.Clear();
            switch (adminChoice)
            {
                case '1':
                    await CreatePizza();
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
                    await FoodMenu.ManageMenuAsync();
                    break;
                }
                default:
                    Console.WriteLine("Fel inmatning!");
                    Console.ReadKey(true);
                    await PizzaAsync();
                    break;
            }
        }

        private static async Task CreatePizza()
        {
            var repo = new AdminRepository();
            string[] ingredintsArray = new string[4];
            IEnumerable<Ingredient> ing = await repo.ShowIngredientsAsync();
            List<Ingredient> ingredients = ing.ToList();

            Console.Write("Namn: ");
            string pizzaName = Console.ReadLine();
            Console.Write("Pris: ");
            int pizzaPrice = Convert.ToInt32(Console.ReadLine());

            //await repo.AddPizzaAsync(pizzaName, pizzaPrice);

            Console.WriteLine("Pizza Tillagd!\n\n");
            IEnumerable<Pizza> temp = await repo.ShowPizzasAsync();
            List<Pizza> pizzas = temp.ToList();

            foreach (var pizza in temp)
            {
                Console.WriteLine($"ID: {pizza.ID} {pizza.Name}");
            }
            Console.Write("Vilken pizza vill du lägga till ingredienser på?: ");
            if (int.TryParse(Console.ReadLine(), out int pizzaUserChoice) == false)
            {
                Console.WriteLine("Fel inmatat");
            }
            if (pizzas.Exists(x => x.ID == pizzaUserChoice))
            {

            }
            
            foreach (var ingrident in ingredients)
            {
                Console.WriteLine($"Ingrediens ID:{ingrident.ID}  {ingrident.Name} ");
            }
            Console.WriteLine("Välj vilka ingrediens ID du vill ha på pizzan (max 4): ");

            for (int i = 0; i < 4; i++)
            {
                Console.Write($"Ingredient{i + 1}: ");
                if (int.TryParse(Console.ReadLine(), out int userChoice) == false)
                {
                    Console.WriteLine("Fel inmatat");
                }
                //if (ingre)
                //{

                //}
                //    foreach (var ingredient in ingredients)
                //    {
                //        if (ingredient.ID != userChoice)
                //        {
                //            Console.WriteLine("Ingridiensen finns ej!");
                //            Console.ReadKey(true);
                //        }
                //        else if (ingredient.ID == userChoice)
                //        {
                //            ingredintsArray[i] = ingredient.Name;
                //        }
                //        else
                //        {
                //            ingredintsArray[i] = null;
                //        }
                //    }

                //}
                //await repo.AddPizzaAsync(pizzaName, pizzaPrice, ingredintsArray[0], ingredintsArray[1], ingredintsArray[2], ingredintsArray[3]);
                ////To Doo
            }
        }
    }
}
