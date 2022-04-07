using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PizzaStore2
{
    class MainMenu
    {
        private static string topText()
        {
            string text = "¤-----------------------¤\n" +
                          "| Pizza Store Main Menu |\n" +
                          "¤-----------------------¤\n";
            return text;
        }

        private static List<string> mainMenuChoices = new List<string>()
        {
            "Show Menu",
            "Order Pizza",
            "Show Orders",
            "Exit"
        };

        public static void PrintMainMenu()
        {
            bool done = false;

            while (!done)
            {                
                string menuChoice = StoreMethods.PrintMenuChoices(mainMenuChoices, topText());

                switch (menuChoice)
                {
                    case "Show Menu":
                        Console.Clear();
                        MenuCatalog.PrintMenu();
                        Console.Write("\nPress any key to continue");
                        Console.ReadKey();
                        break;
                    case "Order Pizza":
                        OrderMenu.PrintOrderMenu();
                        break;
                    case "Show Orders":
                        Console.Clear();
                        Order.PrintOrders();
                        Console.Write("\nPress any key to continue");
                        Console.ReadKey();
                        break;
                    case "Exit":
                        done = true;
                        Console.Clear();                        
                        Console.WriteLine("Closing program...");
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
