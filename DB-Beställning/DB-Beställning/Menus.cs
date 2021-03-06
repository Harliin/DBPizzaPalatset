﻿using System;
using System.Threading.Tasks;
using System.Threading;
using Food;
using System.Collections.Generic;
using System.Linq;

namespace DB_Beställning
{
    public class Menus
    {
        bool correctKey { get; set; }
        char key;
        public static int orderID { get; set; }

        public async Task ChooseBackend()//Väljer backend mellan MSSQL och PostgreSQL
        {
            Console.Clear();
            Console.WriteLine("************DATABSMENYVAL***************");
            Console.WriteLine("[1] MSSQL\n[2] PostgreSQL");
            Console.Write("Välj Backend: ");
            if (int.TryParse(Console.ReadLine(), out int backend))
            {
                if (backend == 1)//MSSQL
                {
                    OrderRepository.Backend = backend;
                    FoodOrder.repo = new OrderRepository();
                    await PrintMenu();
                    return;
                }
                else if (backend == 2)//PostgreSQL
                {
                    OrderRepository.Backend = backend;
                    FoodOrder.repo = new OrderRepository();
                    await PrintMenu();
                    return;
                }
                else
                {
                    Console.WriteLine("Ange en korrekt siffra!");
                    Console.ReadKey(true);
                    await ChooseBackend();
                }
            }
            else
            {
                Console.WriteLine("Fel inmatat!");
                Console.ReadKey(true);
                await ChooseBackend();
            }
        }
        // Metod som skriver ut Välkomsmeny, skapar nytt ordernummer som används tills programemt stängs
        public async Task PrintMenu()
        {
            
            while (correctKey == false)
            {
                FoodOrder foodOrder = new FoodOrder();
                foodOrder.totalPrice = 0;
                Console.Clear();
                Console.WriteLine("Hej och välkomna till Pizza Palatset \nKlicka på Enter för att påbörja beställningen");
                key = Console.ReadKey(true).KeyChar;
                if (key == 13)
                {
                    IEnumerable<Order> order = await FoodOrder.repo.CreateNewOrder();
                    orderID = order.First().ID;
                    //orderID = 44; // Test ordernummer
                    await PrintOrderMenu();
                    correctKey = true;
                }
            }
        }
        // Metod som skriver ut Matmenyn
        public async Task PrintOrderMenu()
        {
            FoodOrder foodOrder = new FoodOrder();
            Console.Clear();
            foreach (string item in MenuList.FoodMenu)
            {
                Console.WriteLine(item);
            }
            key = Console.ReadKey(true).KeyChar;
            switch (key)
            {
                case '1':
                    {
                        await foodOrder.ShowPizzas();
                        break;
                    }
                case '2':
                    {
                        await foodOrder.ShowPastas();
                        break;
                    }
                case '3':
                    {
                        await foodOrder.ShowSallads();
                        break;
                    }
                case '4':
                    {
                        await foodOrder.ShowDrinks();
                        break;
                    }
                case '5':
                    {
                        await foodOrder.ShowExtras();
                        break;
                    }
                case '6':
                    {
                        await foodOrder.ChangeOrder();
                        break;
                    }
                case '7':
                    {
                        await foodOrder.FinishOrder();
                        break;
                    }
                case '9':
                    {
                        await ChooseBackend();
                        break;
                    }
                default:
                    {
                        await PrintOrderMenu();
                        break;
                    }
                    
            }
        }
    }
}
