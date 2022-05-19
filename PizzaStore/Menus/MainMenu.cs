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
            string text = " ¤-----------------------¤\n" +
                          " | Pizza Store Main Menu |\n" +
                          " ¤-----------------------¤\n";
            return text;
        }

        private static List<string> mainMenuChoices = new List<string>()
        {
            "Show Catalog",
            "Edit Catalog",
            "Order Pizza",
            "Show Orders",
            "Exit"
        };

        public static void PrintMainMenu()
        {
            bool done = false;

            while (!done)
            {                
                int menuChoice = StoreMethods.PrintMenuChoices(mainMenuChoices, topText());

                switch (menuChoice)
                {
                    case 1:
                        Console.Clear();
                        PizzaCatalog.PrintMenu();
                        Console.Write("\n Press any key to continue");
                        Console.ReadKey();
                        break;
                    case 2:
                        CatalogMenu.PrintEditPizzaCatalogMenu();
                        break;
                    case 3:
                        OrderMenu.PrintOrderMenu();
                        break;
                    case 4:
                        Console.Clear();
                        Order.PrintOrders();
                        Console.Write("\n Press any key to continue");
                        Console.ReadKey();
                        break;
                    case 5:
                        done = true;
                        Console.Clear();                        
                        Console.WriteLine(" Closing program...");
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
