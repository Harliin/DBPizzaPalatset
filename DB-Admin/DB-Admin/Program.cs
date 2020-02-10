using System;
using System.Threading.Tasks;
using Food;
using System.Linq;


namespace DB_Admin
{
    public class Program
    {
        public static AdminRepository repo;
        static public async Task Main()
        {
            await ChooseBackend();
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
        private static async Task ChooseBackend()//Väljer backend mellan MSSQL och PostgreSQL
        {
            Console.Clear();
            Console.WriteLine("[1]MSSQL\n[2]PostgreSQL");
            Console.Write("Välj Backend: ");
            if (int.TryParse(Console.ReadLine(), out int backend))
            {
                if (backend == 1)//MSSQL
                {
                    AdminRepository.Backend = backend;
                    repo = new AdminRepository();
                    return;
                }
                else if (backend == 2)//PostgreSQL
                {
                    AdminRepository.Backend = backend;
                    repo = new AdminRepository();
                    return;
                }
                else
                {
                    Console.WriteLine("Ange en korrekt siffra!");
                    Console.ReadKey(true);
                    await ChooseBackend();
                }
            }
            else
            {
                Console.WriteLine("Fel inmatat!");
                Console.ReadKey(true);
                await ChooseBackend();
            }
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
