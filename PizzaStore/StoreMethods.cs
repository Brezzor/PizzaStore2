using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore2
{
    class StoreMethods
    {
        private static int menuIndex = 0;

        public static List<string> menuChoices = new List<string>()
        {
            "Show Menu",
            "Create Order",
            "Show Orders",
            "Exit"
        };       

        public static void PrintIntro()
        {
            Console.Clear();
            Console.WriteLine("---- Pizza Store ----");
            Console.WriteLine("\nCommands: ");                      
        }

        public static string MenuChoice()
        {
            PrintIntro();
            return ParseString();
        }

        public static int PizzaChoice()
        {
            Menu.PrintMenu();
            return ParseInt();
        }

        public static string ParseString()
        {
            for (int i = 0; i < menuChoices.Count; i++)
            {
                if (i == menuIndex)
                {
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine(menuChoices[i]);
                }
                else
                {
                    Console.WriteLine(menuChoices[i]);
                }
                Console.ResetColor();
            }

            ConsoleKeyInfo ckey = Console.ReadKey();
            switch (ckey.Key)
            {
                case ConsoleKey.DownArrow:
                    if (menuIndex == menuChoices.Count -1) { }
                    else { menuIndex++; }
                    break;
                case ConsoleKey.UpArrow:
                    if (menuIndex <= 0) { }
                    else { menuIndex--; }
                    break;
                case ConsoleKey.LeftArrow:
                    Console.Clear();
                    break;
                case ConsoleKey.RightArrow:
                    Console.Clear();
                    break;
                case ConsoleKey.Enter:
                    return menuChoices[menuIndex];                    
                default:
                    return "";                    
            }
            
            Console.Clear();
            return "";
        }

        public static void CreateOrder()
        {
            Menu.PrintMenu();
            Console.Write("Choose a pizza: ");            
            int menuNum = ParseInt();
            Console.WriteLine();
            Pizza pizza = Menu.GetPizza(menuNum);

            if (pizza != null)
            {
                List<Pizza> pizzas = new List<Pizza>();                
                pizzas.Add(pizza);

                Console.WriteLine("\n-- Customer info --");
                Console.Write("First name: ");
                string firstName = Console.ReadLine();
                Console.Write("Last name: ");
                string lastName = Console.ReadLine();

                Customer customer = new Customer { FirstName = firstName, LastName = lastName };

                Order order = new Order { Customer = customer, Pizzas = pizzas };

                order.PrintOrder();
            }
            else
            {                
                Console.WriteLine("Terminated creation of order");
            }

            Console.Write("\nPress any key to continue");
            Console.ReadKey();
        }

        public static int ParseInt()
        {
            string input = Console.ReadKey().KeyChar.ToString();

            try
            {
                int result = int.Parse(input);
                return result;
            }            
            catch (FormatException )
            {                
                Console.WriteLine($"\nInput was in wrong format");                
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine($"\nInput was out of range");                
            }
            return -1;
        }        
    }
}
