using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PizzaStore2
{
    class Store
    {
        private static bool done = false;
        public static void Start()
        {            
            while (!done)
            {                
                Console.Clear();
                Console.CursorVisible = false;
                string menuChoice = StoreMethods.MenuChoice();

                switch (menuChoice)
                {
                    case "Show Menu":
                        StoreMethods.menuIndex = 0;
                        Console.Clear();
                        MenuCatalog.PrintMenu();
                        Console.Write("\nPress any key to continue");
                        Console.ReadKey();
                        break;
                    case "Create Order":
                        StoreMethods.menuIndex = 0;
                        Console.Clear();
                        StoreMethods.CreateOrder();
                        break;
                    case "Show Orders":
                        StoreMethods.menuIndex = 0;
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