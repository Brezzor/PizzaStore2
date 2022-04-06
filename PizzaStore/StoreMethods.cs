using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore2
{
    class StoreMethods
    {
        private static bool done = false;
        public static int menuIndex = 0;
        private static Customer newCustomer;
        private static List<Pizza> orderPizzas;
        private static Order newOrder;

        public static List<string> mainMenuChoices = new List<string>()
        {
            "Show Menu",            
            "Order Pizza",
            "Show Orders",
            "Exit"
        };

        public static List<string> orderMenuChoices = new List<string>()
        {
            "Add Pizza",
            "Remove Pizza",
            "Edit Pizza",
            "Show Order",
            "Create",
            "Cancel"
        };

        public static void PrintIntro()
        {
            Console.WriteLine("¤-------------¤");
            Console.WriteLine("| Pizza Store |");
            Console.WriteLine("¤-------------¤");
            Console.WriteLine();                      
        }

        public static void PrintOrderIntro()
        {
            Console.WriteLine("¤-------------¤");
            Console.WriteLine("| Order Pizza |");
            Console.WriteLine("¤-------------¤");
            Console.WriteLine();
        }

        public static string ParseMenuChoice()
        {
            PrintIntro();
            Console.WriteLine("Commands:");
            return MenuChoice(mainMenuChoices);
        }

        public static int PizzaChoice()
        {
            MenuCatalog.PrintMenu();
            return ParseInt();
        }

        private static int ParseInt()
        {
            string input = Console.ReadKey().KeyChar.ToString();
            Console.WriteLine();
            try
            {
                int result = int.Parse(input);
                return result;
            }
            catch (Exception)
            {
                Console.WriteLine($"Input was in wrong format. Input has to be a number");                
            }            
            return -1;
        }

        public static string MenuChoice(List<string> choices)
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
                    if (menuIndex == choices.Count - 1) { }
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

        public static void OrderPizza()
        {
            done = false;
            newCustomer = new Customer();
            orderPizzas = new List<Pizza>();
            Console.Clear();
            PrintOrderIntro();
            CreateCustomer();            
            menuIndex = 0;            

            while (!done)
            {                
                Console.Clear();
                PrintOrderIntro();
                Console.WriteLine("Commands:");
                Console.CursorVisible = false;                
                string subMenuChoice = MenuChoice(orderMenuChoices);

                switch (subMenuChoice)
                {
                    case "Add Pizza":
                        AddPizza();
                        break;
                    case "Remove Pizza":
                        Console.Clear();
                        menuIndex = 0;
                        break;
                    case "Edit Pizza":
                        Console.Clear();                        
                        menuIndex = 0;
                        break;
                    case "Show Order":
                        if (orderPizzas != null && orderPizzas.Count != 0)
                        {
                            newOrder.PrintOrder();
                        }
                        else
                        {
                            Console.WriteLine("\nNo order made yet");
                        }
                        Console.WriteLine("\nPress any key to continue");
                        Console.ReadKey();
                        menuIndex = 0;
                        break;
                    case "Create":
                        Console.Clear();
                        Console.CursorVisible = true;
                        if (orderPizzas != null && orderPizzas.Count != 0)
                        {                            
                            newOrder = new Order{ Customer = newCustomer, Pizzas = orderPizzas };
                            newOrder.PrintOrder();
                            Console.WriteLine("\nOrder has been created");
                        }
                        else
                        {
                            Console.WriteLine("No pizzas was added to the order");
                            Console.WriteLine("No order was created");
                        }
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
        
        private static void AddPizza()
        {
            Console.Clear();
            Console.CursorVisible = true;
            MenuCatalog.PrintMenu();
            Console.WriteLine("Choose a pizza");
            Console.Write("\nPizza number: ");
            int choice = ParseInt();
            Pizza pizza = MenuCatalog.GetPizza(choice);
            if (pizza != null)
            {
                orderPizzas.Add(pizza);                
                pizza.PrintPizza();
            }
            else
            {
                Console.WriteLine("No pizza chosen");
            }
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
            menuIndex = 0;                                  
        }

        private static void CreateCustomer()
        {
            Console.CursorVisible = true;
            Console.Write("Write your firstname: ");
            string firstName = Console.ReadLine();            
            Console.Write("Write your lastname: ");
            string lastName = Console.ReadLine();
            newCustomer = new Customer { FirstName = firstName, LastName = lastName };
            Console.CursorVisible = false;
        }
    }
}
