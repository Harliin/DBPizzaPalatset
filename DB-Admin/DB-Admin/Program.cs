using System;
using System.Threading.Tasks;

namespace DB_Admin
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            do
            {
                Console.Write("\nSkriv in lösenord:");
                string password = Console.ReadLine();
                if (password == "Admin123")
                {
                    await AdminStartMenu();
                }
                else
                {
                    Console.WriteLine("Fel lösenord");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (true);
            
            
            
        }

        public static async Task AdminStartMenu()
        {
            Console.Clear();
            Console.WriteLine("Välkommen Admin!");
            Console.WriteLine("[1]Hantera Anställda\n[2]Hantera Matmeny");
            char adminChoice = Console.ReadKey(true).KeyChar;
            
            switch (adminChoice)
            {
                case '1':
                    await Employees.ManageEmployees();
                    break;
                case '2':
                    await FoodMenu.ManageMenu();
                    break;
                default:
                    Console.WriteLine("Fel inmatning!");
                    Console.ReadKey(true);
                    await AdminStartMenu();
                    break;
            }
        }
    }

    
}
