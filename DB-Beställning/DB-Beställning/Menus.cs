using System;
using System.Collections.Generic;
using System.Text;

namespace DB_Beställning
{
    class Menus
    {
        bool correctKey { get; set; }
        char key;

        public void PrintMenu()
        {
            while (correctKey == false)
            {
                Console.Clear();
                Console.WriteLine("Hej och välkomna till Pizza Palatset \nKlicka på Enter för att påbörja beställningen");
                key = Console.ReadKey(true).KeyChar;
                if (key == 13)
                {
                    PrintOrderMenu();
                    correctKey = true;
                }
            }
        }
        public void PrintOrderMenu()
        {
            Console.Clear();
            foreach(string item in MenuList.FoodMenu)
            {
                Console.WriteLine(item);
            }

            key = Console.ReadKey(true).KeyChar;
            switch (key)
            {
                case '1':
                    PrintPizzas();
                    break;
                case '2':
                    PrintPastas();
                    break;
                case '3':

                default:
                    break;
            }
        }
        public void PrintPizzas()
        {
            Console.Clear();
            foreach (string item in MenuList.Pizzas)
            {
                Console.WriteLine(item);
            }
            while (correctKey == false)
            {
                key = Console.ReadKey(true).KeyChar;
                switch (key)
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine("vesuvio");
                        //LÄNK TILL VESUVIO
                        correctKey = true;
                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine("Margarita");
                        correctKey = true;
                        break;

                    case '3':
                        Console.Clear();
                        Console.WriteLine("Hawaii");
                        correctKey = true;
                        break;

                    case '4':
                        Console.Clear();
                        Console.WriteLine("Calzone");
                        correctKey = true;
                        break;

                    case '5': //Återgå till maträttsmenyn
                        PrintOrderMenu();
                        correctKey = true;
                        break;

                    case '6': //Avsluta
                        PrintMenu();
                        correctKey = true;
                        break;

                    default:

                        Console.Clear();
                        foreach (string choices in MenuList.Pizzas)
                        {
                            Console.WriteLine(choices);
                        }
                        continue;

                }
            }
        }
        public void PrintPastas()
        {
            Console.Clear();

            foreach(string item in MenuList.Pastas)
            {
                Console.WriteLine(item);
            }
            while (correctKey == false)
            {
                key = Console.ReadKey(true).KeyChar;
                switch (key)
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine("Canneloni med kött");
                        // Lägg till i DATABASEN
                        correctKey = true;
                        break;

                    case '2':
                        Console.Clear();
                        Console.WriteLine("Cannelloni vegetarisk");
                        // SAME SAME
                        correctKey = true;
                        break;

                    case '3':
                        PrintOrderMenu(); //Fortsätt handla
                        correctKey = true;
                        break;

                    case '4': //Återgå till maträttsmenyn
                        PrintMenu();
                        correctKey = true;
                        break;

                    default:
                        Console.Clear();
                        foreach (string choices in MenuList.Pastas)
                        {
                            Console.WriteLine(choices);
                        }
                        continue;
                }
            }
        }
        public void PrintSalads()
        {
            foreach(string item in MenuList.Salads)
            {
                Console.WriteLine(item);
            }

           while(correctKey == false)
            {
                key = Console.ReadKey(true).KeyChar;
                switch (key)
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine("Mozzarella sallad");
                        correctKey = true;
                        break;

                    case '2':
                        Console.Clear();
                        Console.WriteLine("Chevresallad");
                        break;

                    case '3':
                        PrintOrderMenu(); //Fortsätt handla
                        correctKey = true;
                        break;

                    case '4': //Återgå till maträttsmenyn
                        PrintMenu();
                        correctKey = true;
                        break;

                    default:
                        Console.Clear();
                        foreach (string choices in MenuList.Salads)
                        {
                            Console.WriteLine(choices);
                        }
                        continue;
                }
            }
        }
    }
}
