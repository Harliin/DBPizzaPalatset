﻿using Food;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DB_OrderInfo
{
    public interface IRepository
    {
        Task AddIngredientToPizzaAsync(int pizzaID, int[] ingridients);
        Task<IEnumerable<Drink>> ShowDrinksAsync();
        Task<IEnumerable<Extra>> ShowExtraAsync();
        Task<IEnumerable<Ingredient>> ShowIngredientsAsync();
        //Task<IEnumerable<OrderFood>> ShowOrderFood();
        Task<IEnumerable<Pasta>> ShowPastasAsync();
        //Task<IEnumerable<PizzaIngredient>> ShowPizzaAndIngredients();
        Task<IEnumerable<Pizza>> ShowPizzasAsync();
        Task<IEnumerable<Sallad>> ShowSalladsAsync();
    }
}