using System;
using System.Threading.Tasks;
using Food;
using System.Linq;


namespace DB_Admin
{
    public class Program
    {
        public static AdminRepository repo = new AdminRepository();
        static async Task Main(string[] args)
        {
            do
            {
                if (await Login())
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

        private static async Task<bool> Login()
        {
            
            Console.Write("\nSkriv in Användarnamn: ");
            string AdminName = Console.ReadLine();

            Console.Write("\nLösenord: ");
            string password = Console.ReadLine();
            var admins = await repo.GetAdmins(AdminName, password);

            if (admins.Count() == 0)
            {
                Console.WriteLine("Felaktigt inloggning!");
                Console.ReadKey();
                await Login();
                return false;
            }
            else
            {
                return true;
            }

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
