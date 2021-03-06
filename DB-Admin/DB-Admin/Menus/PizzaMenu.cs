﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Food;
using System.Linq;

namespace DB_Admin
{
    public class PizzaMenu//Pizza menyn hanterar menyn och dess funktioner
    {
        public static AdminRepository repo;
        
        public async Task PizzaAsync()//Hanterar menyval för Pizzamenyn
        {
            repo = Program.repo;
            Console.Clear();
            Console.WriteLine("\t*Pizza Meny*\n\n[1]Lägg till Pizza\n[2]Ta bort Pizza\n[3]Visa pizzor med ingrediens\n[4]Lägg till ingredienser på pizza\n\n[5]Tillbaka");
            char adminChoice = Console.ReadKey(true).KeyChar;
            Console.Clear();
            switch (adminChoice)
            {
                case '1':
                    await CreatePizza();
                    await PizzaAsync();
                    break;


                case '2':
                    await DeletePizza();
                    break;


                case '3':
                    var pizzaList = await repo.GetPizzas();

                    foreach (Pizza pizza in pizzaList)
                    {
                        Console.WriteLine($"Pizza: {pizza.Name}");

                        foreach (Ingredient ingredient in pizza.Ingredients)
                        {
                            Console.WriteLine($"\tIngrediens: {ingredient.Name}");
                        }
                        Console.WriteLine();
                    }

                    Console.ReadKey();
                    await PizzaAsync();
                    break;


                case '4':
                    await UpdateIngredientsOnPizza();
                    break;


                case '5':
                    {
                        FoodMenu foodMenu= new FoodMenu();
                        await foodMenu.ManageMenuAsync();
                        break;
                    }
                default:
                    Console.WriteLine("Fel inmatning!");
                    Console.ReadKey(true);
                    await PizzaAsync();
                    break;
            }
        }

        private async Task CreatePizza()//Metod för att lägga till pizza i DB
        {
            Console.Write("Namn: ");
            string pizzaName = Console.ReadLine();
            Console.Write("Pris: ");
            int pizzaPrice = Convert.ToInt32(Console.ReadLine());

            await repo.AddPizzaAsync(pizzaName, pizzaPrice);

            Console.WriteLine("Pizza Tillagd!\n\n");

            Console.WriteLine("Vill du lägga till ingridienser på pizzan nu?\n[1] JA\n[2] NEJ");
            char userChoice = Console.ReadKey(true).KeyChar;
            switch (userChoice)
            {
                case'1':
                {
                    await UpdateIngredientsOnPizza();
                    break;
                }
                case'2':
                {
                    await PizzaAsync();
                    break;
                }
                default:
                    Console.WriteLine("Du valde inte en korrekt siffra, går tillbaka till pizza menyn...");
                    System.Threading.Thread.Sleep(500);
                    await PizzaAsync();
                    break;
            }

        }

        private async Task DeletePizza()//Tar bort Pizza från DB
        {
            var pizzas = await repo.ShowPizzasAsync();
            List<Pizza> listOfPizzas = pizzas.ToList();
            foreach (var pizza in pizzas)
            {
                Console.WriteLine($"ID:{pizza.ID}  Pizza:{pizza.Name}");
            }
            Console.Write("Ange Pizza ID för att ta bort: ");
            if (int.TryParse(Console.ReadLine(), out int userChoice))
            {
                if (listOfPizzas.Exists(x => x.ID == userChoice))//Kollar om id finns
                {
                    await repo.DeletePizzaAsync(userChoice);
                    Console.WriteLine("Pizzan är borttagen");
                }
                else
                {
                    Console.WriteLine("Finns ingen pizza med det IDet!");
                }
            }
            else
            {
                Console.WriteLine("Fel inmatning!");
            }

            Console.ReadKey();
            await PizzaAsync();
        }
        private async Task UpdateIngredientsOnPizza()//Updaterar ingredienser på en pizza
        {
            Console.Clear();
            var temp = await repo.ShowPizzasAsync();
            var ing = await repo.ShowIngredientsAsync();
           
            List<Pizza> pizzas = temp.ToList();
            List<Ingredient> ingredients = ing.ToList();

            foreach (var pizza in temp)
            {
                Console.WriteLine($"ID: {pizza.ID} {pizza.Name}");
            }
            Console.Write("Vilken pizza vill du lägga till ingredienser på?: ");

            if (int.TryParse(Console.ReadLine(), out int pizzaUserChoice) == false)
            {
                Console.WriteLine("Fel inmatat");
                System.Threading.Thread.Sleep(500);
                await UpdateIngredientsOnPizza();
            }
            
            if (pizzas.Exists(x => x.ID == pizzaUserChoice))
            {
                Console.Clear();
                Console.Write("Hur många Ingredienser vill du ha på pizzan?(max 4): ");
                int ingredientCounter = Convert.ToInt32(Console.ReadLine());

                foreach (var ingrident in ingredients)
                {
                    Console.WriteLine($"Ingrediens ID:{ingrident.ID}  {ingrident.Name} ");
                }

                int[] ingredintsArray = new int[ingredientCounter];
                Console.WriteLine("Välj vilken ingrediens ID du vill ha på pizzan:\n");
                for (int i = 0; i < ingredientCounter; i++)
                {
                    Console.Write($"Ingredient{i + 1}: ");
                    if (int.TryParse(Console.ReadLine(), out int ingredientUserChoice) == false)
                    {
                        Console.WriteLine("Fel inmatat");
                        i--;
                        continue;
                    }
                    else if (ingredients.Exists(x => x.ID == ingredientUserChoice))
                    {
                        ingredintsArray[i] = ingredientUserChoice;
                    }
                    else
                    {
                        Console.WriteLine("Hittar ej en ingrediens med det IDt.");
                        i--;
                    }
                    
                }
                try
                {
                    await repo.AddIngredientToPizzaAsync(pizzaUserChoice, ingredintsArray);
                    Console.WriteLine("Tillagd");
                    Console.ReadKey();
                    await PizzaAsync();
                }
                catch (Exception)
                {
                    Console.WriteLine("Funkade inte");
                    throw;
                }
            }
        }
    }
}
