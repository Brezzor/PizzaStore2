using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PizzaStore2
{
    class Store
    {
        static bool _exit = false;
        public static void Start()
        {
            Console.Clear();

            Console.CursorVisible = false;
            
            while (!_exit)
            {                
                string menuChoice = StoreMethods.MenuChoice();
                switch (menuChoice)
                {
                    case "Show Menu":
                        Console.Clear();
                        Menu.PrintMenu();
                        Console.Write("\nPress any key to continue");
                        Console.ReadKey();
                        break;
                    case "Create Order":
                        Console.Clear();
                        StoreMethods.CreateOrder();
                        break;
                    case "Show Orders":
                        Console.Clear();
                        Order.PrintOrders();
                        Console.Write("\nPress any key to continue");
                        Console.ReadKey();
                        break;
                    case "Exit":
                        _exit = true;
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