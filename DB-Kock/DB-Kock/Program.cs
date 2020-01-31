using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Food;

namespace DB_Kock
{
    class Program
    {
        public static ChefRepository repo = new ChefRepository();
        static async Task Main(string[] args)
        {
            if (await Login())
            {
                await Display.DrawMultipleChoiceMenu();
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
