using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore2
{
    class Store
    {
        static bool _exit = false;
        public static void Start()
        {            
            while (!_exit)
            {
                int menuChoice = StoreMethods.MenuChoice();
                switch (menuChoice)
                {
                    case 1:
                        Console.Clear();
                        Menu.PrintMenu();
                        Console.Write("\nPress any key to continue");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        StoreMethods.CreateOrder();
                        break;
                    case 3:
                        Console.Clear();
                        Order.PrintOrders();
                        Console.Write("\nPress any key to continue");
                        Console.ReadKey();
                        break;
                    case 0:
                        Console.Clear();
                        _exit = true;
                        break;
                    default:
                        Console.WriteLine("\nInvalid command!");                        
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }        
}