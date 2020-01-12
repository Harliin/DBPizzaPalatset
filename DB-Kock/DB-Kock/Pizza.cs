using System;
using System.Collections.Generic;
using System.Text;

namespace DB_Kock
{
    public class Pizza
    {
        public string Name { get; set; }
        public static List<string> Pizzas = new List<string>
        {
            "1", "2", "3", "4",
            "5", "6",
            "7", "8"
        };
        public List<string> Ingredients { get; set; }
        public PizzaBase PizzaBase { get; set; }

        //public Pizza(string name, List<string> ingred, PizzaBase pizzaBase = PizzaBase.Italiensk)
        //{
        //    this.Name = name;
        //    this.Ingredients = ingred;
        //    this.PizzaBase = pizzaBase;
        //}


        //måste först hämta pizzor från databasa innan man kan använda metoden
        public string GeneratePizza()
        {
            Random random = new Random();
            int randomPizzaIndex = random.Next(1, 4);
            Name = Pizzas[randomPizzaIndex - 1];
            return Name;
        }

        public void ShowOrder(string name, List<Pizza> orders, int listIndex)
        {
            bool correctKey = false;


            //kolla om switch fungerar bättre
            while (correctKey == false)
            {
             
                Console.Clear();
                Console.WriteLine("Du har valt: " + name);
                Console.WriteLine();
                Console.WriteLine("Denna rätt innehåller följande ingredienser:");
                Console.WriteLine("-------------\n");

                if (name == "1")
                {
                    //ingredienser från database
                    Console.WriteLine("\n-------------");
                    Console.WriteLine("1. Stoppa in i ugn");
                }

                else if (name== "2")
                {
                    //ingredienser från database
                    Console.WriteLine("\n-------------");
                    Console.WriteLine("1. Stoppa in i ugn");
                }

                else if (name == "3")
                {
                    //ingredienser från database
                    Console.WriteLine("\n-------------");
                    Console.WriteLine("1. Stoppa in i ugn");
                }

                else if (name == "4")
                {
                    //ingredienser från database
                    Console.WriteLine("\n-------------");
                    Console.WriteLine("1. Stoppa in i ugn");
                }

                Console.WriteLine("2. Återgå");

                int userInput = Console.ReadKey(true).KeyChar - '0';

         
                if (userInput == 1 && name == "1" || userInput == 1 && name == "2" ||
                    userInput == 1 && name == "3" || userInput == 1 && name == "4")
                {
                 
                    orders.RemoveAt(listIndex);
                    //CookPizza(orders);
                    correctKey = true;
                }

                else if (userInput == 2)
                {
                    Program.GetOrders(orders);
                    correctKey = true;
                }

            }


        }

        public void CookPizza(List<Pizza> orders)
        {
            // pizzan ligger i ugnen
            Console.Clear();
            Console.WriteLine("Pizzan tillagas");
            Console.WriteLine("-------------\n");

            // simulering av att pizzan tillagas
            System.Threading.Thread.Sleep(1500);

            // pizzan klar
            Console.Clear();
            Console.WriteLine("Pizzan färdig");
            Console.WriteLine("-------------\n");
            //Console.Beep(500, 2000);

            Console.WriteLine("Klicka Enter för att skicka pizzan till servering");

            // väntar tills kocken bekräftat att maten är klar för servering
            while (true)
            {
                char key = Console.ReadKey(true).KeyChar;
                // om kocken klickar på enter så skickas hen tillbaka till startsidan för att kunna ta nya ordrar
                if (key == 13)
                {
                    DrawConfirmationScreen(orders);
                    break;
                }
            }
        }

        public void DrawConfirmationScreen(List<Pizza> orders)
        {
            Console.Clear();
            Console.WriteLine("Maten serverad!");
            System.Threading.Thread.Sleep(1500);
            Program.GetOrders(orders);
        }
    }
}
