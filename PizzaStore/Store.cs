using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore2
{
    class Store
    {       
        static bool _exit = false;

        private static List<string> menuChoices = new List<string>()
        {            
            "[1]: Show Menu",
            "[2]: Create Order",
            "[3]: Show Orders",
            "[0]: Exit"
        };   
        
        public static List<string> GetMenuChoices()
        {
            return menuChoices;
        }

        private static void PrintMenuChoices()
        {
            foreach (string s in menuChoices)
            {
                Console.WriteLine(s);
            }
        }

        private static void PrintIntro()
        {
            Console.Clear();
            Console.WriteLine("---- Pizza Store ----");
            PrintMenuChoices();
            Console.WriteLine("Type the number of what you would like to do");
            Console.Write("Command: ");
        }

        private static int MenuChoice()
        {
            PrintIntro();
            int result = StoreMethods.ParseInt();
            return result;
        }

        public static void Start()
        {            
            while (!_exit)
            {
                int menuChoice = MenuChoice();
                switch (menuChoice)
                {
                    case 1:
                        Menu.PrintMenu();
                        Console.Write("\nPress any key to continue");
                        Console.ReadKey();
                        break;
                    case 2:
                        StoreMethods.CreateOrder();
                        break;
                    case 3:
                        Order.PrintOrders();
                        Console.Write("\nPress any key to continue");
                        Console.ReadKey();
                        break;
                    case 0:
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