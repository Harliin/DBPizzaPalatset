using System;
using System.Collections.Generic;
using System.Text;

namespace DB_Admin
{
    public class Employees
    {
        public static void ManageEmployees()
        {
            Console.Clear();
            Console.WriteLine("\t*Meny för anställda*\n\n[1]Visa anställda\n[2]Lägg till en ny anställd\n[3]Ta bort en anställd\n\n[4]Tillbaka till huvudmeny");
            char adminChoice = Console.ReadKey(true).KeyChar;

            switch (adminChoice)
            {
                case '1':
                    Console.WriteLine("\n*Visar anställda från DB*");
                    Console.ReadKey();
                    ManageEmployees();
                    break;
                case '2':
                    Console.WriteLine("\n*Lägger till Anställd från DB*");
                    Console.ReadKey();
                    ManageEmployees();
                    break;
                case '3':
                    Console.WriteLine("\n*Tar bort en anställd från DB*");
                    Console.ReadKey();
                    ManageEmployees();
                    break;
                case '4':
                    Program.AdminStartMenu();
                    break;
                default:
                    Console.WriteLine("Fel inmatning!");
                    Console.ReadKey(true);
                    ManageEmployees();
                    break;
            }
        }
    }
}
