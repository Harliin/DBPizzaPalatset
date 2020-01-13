using System;

namespace DB_Admin
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Write("\nSkriv in lösenord:");
                string password = Console.ReadLine();
                if (password == "Admin123")
                {
                    AdminStartMenu();
                }
                else
                {
                    Console.WriteLine("Fel lösenord");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (true);
            
            
            
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
