using System;
using System.Collections.Generic;
using System.Text;

namespace DB_Admin
{
    public class FoodMenu
    {
        public static void ManageMenu()
        {
            Console.Clear();
            Console.WriteLine("\t*Matmeny*\n\n[1]Hantera Pizzor\n[2]Hantera Pastarätter\n[3]Hantera Sallader\n[4]Hantera Drycker\n\n[5]Tillbaka till Huvudmeny");
            char adminChoice = Console.ReadKey(true).KeyChar;
            switch (adminChoice)
            {
                case '1':
                    Pizza();
                    break;
                case '2':
                    Pasta();
                    break;
                case '3':
                    Sallad();
                    break;
                case '4':
                    Drinks();
                    break;
                case '5':
                    Program.AdminStartMenu();
                    break;
                default:
                    Console.WriteLine("Fel inmatning!");
                    Console.ReadKey(true);
                    ManageMenu();
                    break;
            }
        }
        private static void Pizza()
        {
            Console.Clear();
            Console.WriteLine("\t*Pizza Meny*\n\n[1]Lägg till Pizza\n[2]Ta bort Pizza\n\n[3]Tillbaka");
            char adminChoice = Console.ReadKey(true).KeyChar;
            switch (adminChoice)
            {
                case '1':
                    Console.WriteLine("*Lägger till pizza i DB*");
                    Console.ReadKey();
                    Pizza();
                    break;
                case '2':
                    Console.WriteLine("*Tar bort pizza i DB*");
                    Console.ReadKey();
                    Pizza();
                    break;
                case '3':
                    ManageMenu();
                    break;
                default:
                    Console.WriteLine("Fel inmatning!");
                    Console.ReadKey(true);
                    Pizza();
                    break;
            }
        }

        private static void Pasta()
        {
            Console.Clear();
            Console.WriteLine("\t*Pasta Meny*\n\n[1]Lägg till Pasta\n[2]Ta bort Pasta\n\n[3]Tillbaka");
            char adminChoice = Console.ReadKey(true).KeyChar;
            switch (adminChoice)
            {
                case '1':
                    Console.WriteLine("*Lägger till pasta i DB*");
                    Console.ReadKey();
                    Pasta();
                    break;
                case '2':
                    Console.WriteLine("*Tar bort pasta i DB*");
                    Console.ReadKey();
                    Pasta();
                    break;
                case '3':
                    ManageMenu();
                    break;
                default:
                    Console.WriteLine("Fel inmatning!");
                    Console.ReadKey(true);
                    Pasta();
                    break;
            }
        }

        private static void Sallad()
        {
            Console.Clear();
            Console.WriteLine("\t*Sallad Meny*\n\n[1]Lägg till Sallad\n[2]Ta bort Sallad\n\n[3]Tillbaka");
            char adminChoice = Console.ReadKey(true).KeyChar;
            switch (adminChoice)
            {
                case '1':
                    Console.WriteLine("*Lägger till sallad i DB*");
                    Console.ReadKey();
                    Sallad();
                    break;
                case '2':
                    Console.WriteLine("*Tar bort sallad i DB*");
                    Console.ReadKey();
                    Sallad();
                    break;
                case '3':
                    ManageMenu();
                    break;
                default:
                    Console.WriteLine("Fel inmatning!");
                    Console.ReadKey(true);
                    Sallad();
                    break;
            }
        }

        private static void Drinks()
        {
            Console.Clear();
            Console.WriteLine("\t*Dryckes Meny*\n\n[1]Lägg till Dryck\n[2]Ta bort Dryck\n\n[3]Tillbaka");
            char adminChoice = Console.ReadKey(true).KeyChar;
            switch (adminChoice)
            {
                case '1':
                    Console.WriteLine("*Lägger till dryck i DB*");
                    Console.ReadKey();
                    Drinks();
                    break;
                case '2':
                    Console.WriteLine("*Tar bort dryck i DB*");
                    Console.ReadKey();
                    Drinks();
                    break;
                case '3':
                    ManageMenu();
                    break;
                default:
                    Console.WriteLine("Fel inmatning!");
                    Console.ReadKey(true);
                    Drinks();
                    break;
            }
        }
    }
}
