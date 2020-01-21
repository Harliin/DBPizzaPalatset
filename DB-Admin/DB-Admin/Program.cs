using System;
using System.Threading.Tasks;
using Food;


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
                    await AdminStartMenuAsync();
                }
                else
                {
                    Console.WriteLine("Fel lösenord");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (true);
            
            
            
        }

        public static async Task AdminStartMenuAsync()
        {
            Console.Clear();
            Console.WriteLine("Välkommen Admin!");
            Console.WriteLine("[1]Hantera Anställda\n[2]Hantera Matmeny");
            char adminChoice = Console.ReadKey(true).KeyChar;
            
            switch (adminChoice)
            {
                case '1':
                    await Employees.ManageEmployeesAsync();
                    break;
                case '2':
                    await FoodMenu.ManageMenuAsync();
                    break;
                default:
                    Console.WriteLine("Fel inmatning!");
                    Console.ReadKey(true);
                    await AdminStartMenuAsync();
                    break;
            }
        }
    }

    
}
