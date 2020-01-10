using System;

namespace DB_Admin
{
    class Program
    {
        static void Main(string[] args)
        {
            AdminStartMenu();
        }

        public static void AdminStartMenu()
        {
            Console.Clear();
            Console.WriteLine("Välkommen Admin!");
            Console.WriteLine("[1]Hantera Anställda\n[2]Hantera Matmeny");
            char adminChoice = Console.ReadKey(true).KeyChar;
            
            switch (adminChoice)
            {
                case '1':
                    Employees.ManageEmployees();
                    break;
                case '2':
                    FoodMenu.ManageMenu();
                    break;
                default:
                    Console.WriteLine("Fel inmatning!");
                    Console.ReadKey(true);
                    AdminStartMenu();
                    break;
            }
        }
    }

    
}
