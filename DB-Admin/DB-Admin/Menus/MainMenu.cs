using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DB_Admin
{
    public class MainMenu
    {
        
        public async Task AdminStartMenuAsync()//Huvud meny
        {
            Console.Clear();
            Console.WriteLine("Välkommen Admin!");
            Console.WriteLine("[1]Hantera Anställda\n[2]Hantera Matmeny\n\n[3]Logga ut");
            char adminChoice = Console.ReadKey(true).KeyChar;

            switch (adminChoice)
            {
                case '1':
                    Employees employees = new Employees();
                    await employees.ManageEmployeesAsync();//Hanterar Employees
                    break;
                case '2':
                    FoodMenu foodMenu = new FoodMenu();
                    await foodMenu.ManageMenuAsync();//Hanterar Mat meny
                    break;
                case '3':
                {
                    await Program.Main();
                    break;
                }
                default:
                    Console.WriteLine("Fel inmatning!");
                    Console.ReadKey(true);
                    await AdminStartMenuAsync();
                    break;
            }
        }
    }
}
