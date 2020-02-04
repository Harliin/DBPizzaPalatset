using System;
using System.Threading.Tasks;
using Food;
using System.Linq;


namespace DB_Admin
{
    public class Program
    {
        public static AdminRepository repo = new AdminRepository();
        
        static public async Task Main()
        {
            do
            {
                if (await Login())
                {
                    MainMenu menu = new MainMenu();
                    await menu.AdminStartMenuAsync();
                }
                else
                {
                    Console.WriteLine("Fel lösenord");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (true);
        }

        private static async Task<bool> Login()//Inloggnings metod  Användarnamn: VD  Lösen: 123    eller använd: Tony    lösen:admin123
        {
            Console.Clear();
            Console.WriteLine("*Inloggnings Meny*");
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
            }
            else
            {
                return true;
            }
            return true;
        }
    }

    
}
