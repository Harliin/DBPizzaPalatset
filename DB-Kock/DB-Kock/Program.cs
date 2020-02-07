using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Food;
using System.Data;

namespace DB_Kock
{
    public class Program
    {

        public static ChefRepository repo;


        private static async Task ChooseBackend()//Väljer backend mellan MSSQL och PostgreSQL
        {
            Console.Clear();
            Console.WriteLine("[1]MSSQL\n[2]PostgreSQL");
            Console.Write("Välj Backend: ");
            if (int.TryParse(Console.ReadLine(), out int backend))
            {
                if (backend == 1)//MSSQL
                {
                    ChefRepository.Backend = backend;
                    repo = new ChefRepository();
                    return;
                }
                else if (backend == 2)//PostgreSQL
                {
                    ChefRepository.Backend = backend;
                    repo = new ChefRepository();
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

        static public async Task Main()
        {
            await ChooseBackend();

            Display startMenu = new Display();

            if (await Login())
            {
                await startMenu.DrawMultipleChoiceMenu();
            }
            else
            {
                Console.WriteLine();
            }
        }

        public static async Task<bool> Login()//Login. Användarnamn: ba1  Lösen: ba1          
        {                                    //Alternativ inlogg användarnamn: Giovanni  Lösen: bagare2
            Console.Clear();
            Console.WriteLine("*Inloggnings Meny*");
            Console.Write("\nSkriv in Användarnamn: ");
            string AdminName = Console.ReadLine();

            Console.Write("\nLösenord: ");
            string password = Console.ReadLine();
            var admins = await repo.GetChefs(AdminName, password);

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
