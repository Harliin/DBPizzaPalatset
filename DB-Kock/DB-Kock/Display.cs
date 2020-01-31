using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food;
using static Food.Order;

namespace DB_Kock
{
    public class Display
    {
        public static ChefRepository repo = new ChefRepository();
        public static async Task<bool> DrawStartMenuAsync()//Login
        {
            bool loop = true;

            do
            {
                Console.Clear();
                Console.WriteLine("---------------------");
                Console.WriteLine("Logga in");
                Console.WriteLine("---------------------");


                Console.Write("Pinkod:");

                string input = Console.ReadLine();

                if (input == "Bagare123")
                {
                    
                    return true;
                }
                else
                {
                    Console.WriteLine("Fel pinkod");
                    Console.ReadKey();
                    break;

                }

            } while (loop == true);
            return false;

        }

        public static async Task DrawMultipleChoiceMenu()
        {
            var repo = new ChefRepository();

            Console.Clear();
            Console.WriteLine("Välj den order som du vill tillaga");
            Console.WriteLine("-------------\n");

            await ShowOrders();//skriver ut ordarna som är under tillagning

            Console.Write("Välj ordernummer: ");

            IEnumerable<Order> orderByStatusIEnumerable = await repo.ShowOrderByStatus(eStatus.Tillagning);
            List<Order> listOfOrders = orderByStatusIEnumerable.ToList();

            if (int.TryParse(Console.ReadLine(), out int opt))//Kollar om orderIDt finns
            {
                if (listOfOrders.Exists(x => x.ID == opt))
                {
                    await repo.UpdateOrderStatus(opt);
                    foreach (var orderFood in await repo.ShowOrderByID(opt))
                    {
                        Console.Clear();
                        Console.WriteLine($"Du har valt order # {orderFood.ID}");
                        Console.WriteLine();
                        Console.WriteLine($"Denna order innehåller följande artiklar:");
                        Console.WriteLine("------------------------");
                        Console.WriteLine();
                        await ShowFoodInOrder(orderFood.ID);//Skriver ut en orders innehåll
                        Console.WriteLine();
                        Console.WriteLine("------------------------");
                    }

                }
            }
            else
            {
                Console.WriteLine("Fel inmatning");
            }

            bool correctKey = true;

            do//Hanterar val för att tillaga en order eller gå tillbaka
            {

                Console.WriteLine("1. Tillaga");
                Console.WriteLine("2. Återgå");

                int userInput = Console.ReadKey(true).KeyChar - '0';

                if (userInput == 1)
                {
                    await DrawCookMenu();
                    correctKey = false;
                }

                if (userInput == 2)
                {
                    await DrawMultipleChoiceMenu();
                    correctKey = false;
                }

                else
                {
                    Console.Clear();
                    Console.WriteLine("Skriv 1 eller 2");
                }

            } while (correctKey == true);

        }
        public static async Task DrawCookMenu()//Simulerar att pizzan tillagas
        {
            var repo = new ChefRepository();

            Console.Clear();
            Console.WriteLine("Maten tillagas");
            Console.WriteLine("-------------\n");

            // simulering av att pizzan tillagas
            System.Threading.Thread.Sleep(1500);

            // pizzan klar
            Console.Clear();
            Console.WriteLine("Pizzan färdig");
            Console.WriteLine("-------------\n");
            Console.Beep(500, 2000);

            Console.WriteLine("Klicka Enter när du är färdig och redo att skicka maten till servering");

            // väntar tills kocken bekräftat att maten är klar för servering
            while (true)
            {
                char key = Console.ReadKey(true).KeyChar;
                // om kocken klickar på enter så skickas den tillbaka till startsidan för att kunna ta nya ordrar
                if (key == 13)
                {
                    await DrawConfirmationScreen();
                    break;
                }
            }

        }


        public static async Task DrawConfirmationScreen()
        {
            Console.Clear();
            await PrintOrderNumber();      
            System.Threading.Thread.Sleep(2000);
            await DrawMultipleChoiceMenu();
        }

        
        //Hämtar första orderID med status 3. TODO: nu skriver det ut en lista av alla orderrader per orderitem men ska fixas att det kommer bara en gång, ingen lista. 
        private static async Task PrintOrderNumber()
        {
            var ordersIEnumerable = await repo.ShowFinishedOrderID();
            var firstID = ordersIEnumerable.First();
            foreach (Order order in ordersIEnumerable)
            {
                Console.WriteLine($"Skriver ut ordernummer { firstID.ID}...");
            }
            Console.WriteLine();

        }

        private static async Task ShowOrders()//Printar ut ordrar med status 2 == under tillagning
        {
            IEnumerable<Order> orderByStatusIEnumerable = await repo.ShowOrderByStatus(eStatus.Tillagning);
            List<Order> ordersList = orderByStatusIEnumerable.ToList();
            foreach (Order orderByStatus in ordersList)//Printar ut alla ordrar under tillagning
            {
                int orderID = orderByStatus.ID;
                Console.Write($"Order #: {orderByStatus.ID} \n");


                foreach (Pizza pizzaItem in orderByStatus.pizza)
                {

                    Console.Write($"\t{pizzaItem.Name}\n");
                }
                foreach (Pasta pastaItem in orderByStatus.pasta)
                {
                    Console.Write($"\t{pastaItem.Name}\n");
                }
                foreach (Sallad salladItem in orderByStatus.sallad)
                {
                    Console.Write($"\t{salladItem.Name}\n");
                }
                foreach (Drink drinkItem in orderByStatus.drink)
                {
                    Console.Write($"\t{drinkItem.Name}\n");
                }
                foreach (Extra extraItem in orderByStatus.extra)
                {
                    Console.Write($"\t{extraItem.Name}\n");
                }
                Console.WriteLine();
            }
        }
        private static async Task ShowFoodInOrder(int orderID)
        {
            var ordersIEnumerable = await repo.ShowOrderByID(orderID);
            List<Order> listOrders = ordersIEnumerable.ToList();
            
            foreach (Order order in listOrders)
            {

                foreach (Pizza pizzaItem in order.pizza)
                {

                    Console.Write($"\t{pizzaItem.Name}\n");

                    //TODO
                    //foreach (Ingredient ingredient  in pizzaItem)
                    //{

                    //} 
                }
                foreach (Pasta pastaItem in order.pasta)
                {
                    Console.Write($"\t{pastaItem.Name}\n");
                }
                foreach (Sallad salladItem in order.sallad)
                {
                    Console.Write($"\t{salladItem.Name}\n");
                }
                foreach (Drink drinkItem in order.drink)
                {
                    Console.Write($"\t{drinkItem.Name}\n");
                }
                foreach (Extra extraItem in order.extra)
                {
                    Console.Write($"\t{extraItem.Name}\n");
                }
                Console.WriteLine();
            }
        

        }

    }

}
