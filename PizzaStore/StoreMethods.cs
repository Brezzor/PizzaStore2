using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore2
{
    class StoreMethods
    {
        private static bool done = false;
        public static int menuIndex = 0;
        private static Customer newCustomer = new Customer();
        private static List<Pizza> pizzas = new List<Pizza>();        

        public static List<string> menuChoices = new List<string>()
        {
            "Show Menu",
            "Create Order",
            "Show Orders",
            "Exit"
        };

        public static List<string> subMenuChoices = new List<string>()
        {
            "Add Pizza",
            "Remove Pizza",
            "Edit Pizza",
            "Create",
            "Cancel"
        };

        public static void PrintIntro()
        {
            Console.WriteLine("¤-------------¤");
            Console.WriteLine("| Pizza Store |");
            Console.WriteLine("¤-------------¤");
            Console.WriteLine("\nCommands: ");                      
        }

        public static void PrintOrderIntro()
        {
            Console.WriteLine("¤-------------¤");
            Console.WriteLine("| Order Pizza |");
            Console.WriteLine("¤-------------¤");
            Console.WriteLine();
        }

        public static string MenuChoice()
        {
            PrintIntro();
            return ParseString(menuChoices);
        }

        public static int PizzaChoice()
        {
            MenuCatalog.PrintMenu();
            return ParseInt();
        }

        private static int ParseInt()
        {
            string input = Console.ReadKey().KeyChar.ToString();

            try
            {
                int result = int.Parse(input);
                return result;
            }
            catch (FormatException)
            {
                Console.WriteLine($"\nInput was in wrong format");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine($"\nInput was out of range");
            }
            return -1;
        }

        public static string ParseString(List<string> choices)
        {            
            for (int i = 0; i < choices.Count; i++)
            {
                if (i == menuIndex)
                {
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(choices[i]);
                }
                else
                {
                    Console.WriteLine(choices[i]);
                }
                Console.ResetColor();
            }

            ConsoleKeyInfo ckey = Console.ReadKey();
            switch (ckey.Key)
            {
                case ConsoleKey.DownArrow:
                    if (menuIndex == choices.Count -1) { }
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
                    return choices[menuIndex];                    
                default:                    
                    return "";                    
            }
            
            Console.Clear();
            return "";
        }

        public static void CreateOrder()
        {
            done = false;
            menuIndex = 0;            

            while (!done)
            {
                Console.Clear();
                PrintOrderIntro();
                Console.CursorVisible = false;                
                string subMenuChoice = ParseString(subMenuChoices);

                switch (subMenuChoice)
                {
                    case "Add Pizza":                        
                        Console.Clear();
                        MenuCatalog.PrintMenu();
                        Console.Write("\nPizza number: ");
                        int choice = ParseInt();
                        Pizza newPizza = MenuCatalog.GetPizza(choice);
                        pizzas.Add(newPizza);
                        Console.WriteLine($"{newPizza.Name} has been added to the order");
                        Console.WriteLine("\nPress any key to continue");
                        Console.ReadKey();
                        menuIndex = 0;
                        break;
                    case "Remove Pizza":
                        Console.Clear();
                        menuIndex = 0;
                        break;
                    case "Edit Pizza":
                        Console.Clear();
                        menuIndex = 0;
                        break;
                    case "Create":
                        Console.Clear();
                        Console.CursorVisible = true;
                        Console.Write("Write your firstname: ");
                        newCustomer.FirstName = Console.ReadLine();
                        Console.Write("\nWrite your lastname: ");
                        newCustomer.LastName = Console.ReadLine();
                        Order newOrder = new Order{ Customer = newCustomer, Pizzas = pizzas};
                        newOrder.PrintOrder();
                        Console.WriteLine("Order has been created");
                        Console.WriteLine("\nPress any key to continue");
                        Console.ReadKey();
                        done = true;
                        menuIndex = 0;
                        break;
                    case "Cancel":                                                 
                        done = true;
                        menuIndex = 0;
                        break;
                }
            }            
        }                
    }
}
