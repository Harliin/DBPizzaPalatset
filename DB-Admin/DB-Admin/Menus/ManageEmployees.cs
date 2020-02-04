using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food;

namespace DB_Admin
{
    public class Employees
    {
        public static AdminRepository repo = new AdminRepository();
        
        public async Task ManageEmployeesAsync()//Hanterar menyvalen för de menyn för anställda
        {
            Console.Clear();
            Console.WriteLine("\t*Meny för anställda*\n\n[1]Visa anställda\n[2]Lägg till en ny anställd\n[3]Ta bort en anställd\n\n[4]Tillbaka till huvudmeny");
            char adminChoice = Console.ReadKey(true).KeyChar;
            Console.Clear();
            switch (adminChoice)
            {
                case '1':
                    foreach (var employee in await repo.ShowEmployees())
                    {
                        Console.WriteLine($"Namn:{employee.Name}  Lösenord:{employee.Password} Typ:{employee.EmployeeType}");
                    }
                    Console.ReadKey();
                    await ManageEmployeesAsync();
                    break;
                case '2':
                    await AddEmployee();
                    await ManageEmployeesAsync();
                    break;
                case '3':
                    await DeleteEmployee();
                    await ManageEmployeesAsync();
                    break;
                case '4':
                    MainMenu mainMenu = new MainMenu();
                    await mainMenu.AdminStartMenuAsync();
                    break;
                default:
                    Console.WriteLine("Fel inmatning!");
                    Console.ReadKey(true);
                    await ManageEmployeesAsync();
                    break;
            }
        }

        private async Task AddEmployee()//Metod för att lägga till en anställd i DB
        {
            Console.Write("Namn: ");
            string eName = Console.ReadLine();
            Console.Write("Password: ");
            string ePassword = Console.ReadLine();
            Console.Write("Typ av anställd?:\n[1]Chef\n[2]Bagare\n[3]Kassörska\nVal: ");

            if (int.TryParse(Console.ReadLine(), out int employeeType) == false)
            {
                Console.WriteLine("\nFel inmatning!");
            }
            else if(employeeType < 1 && employeeType > 4)
            {
                Console.WriteLine("\nDu valde inte en siffra mellan 1-3!");
            }
            else
            {
                await repo.AddEmployee(eName, ePassword, employeeType);
                Console.WriteLine("\nAnställd tillagd!");
            }

            Console.ReadKey();
            await ManageEmployeesAsync();
        }

        private async Task DeleteEmployee()//Metod för att ta bort en anställd i DB
        {
            var tempEmployee = await repo.ShowEmployees();
            List<Employee> listOfEmployees = tempEmployee.ToList();
            foreach (var employee in listOfEmployees)
            {
                Console.WriteLine($"ID:{employee.ID}  Namn:{employee.Name}");
            }

            Console.Write("Ange den anställdas ID för att ta bort: ");
            if (int.TryParse(Console.ReadLine(), out int userChoice))
            {
                if (listOfEmployees.Exists(x => x.ID == userChoice))//Kollar om id finns
                {
                    await repo.DeleteEmployee(userChoice);
                    Console.WriteLine("\nAnställd borttagen...");
                }
                else
                {
                    Console.WriteLine("\nFinns ingen anställd med ett sånt ID!");
                }
            }
            else
            {
                Console.WriteLine("\nFel inmatning!");
            }
            Console.ReadKey();
            await ManageEmployeesAsync();
        }
    }
}
