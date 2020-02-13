﻿using Food;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DB_Kock
{
    public interface IRepository
    {
        Task<IEnumerable<Drink>> ShowDrinksAsync();
        Task<IEnumerable<Extra>> ShowExtraAsync();
        Task<IEnumerable<Ingredient>> ShowIngredientsAsync();
        Task<IEnumerable<Pasta>> ShowPastasAsync();
        Task<IEnumerable<PizzaIngredient>> ShowPizzaAndIngredients();
        Task<IEnumerable<Pizza>> ShowPizzasAsync();
        Task<IEnumerable<Sallad>> ShowSalladsAsync();
    }
}