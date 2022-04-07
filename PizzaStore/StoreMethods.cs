using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PizzaStore2
{
    class StoreMethods
    {
        private static List<Pizza> orderPizzas = new List<Pizza>();                          

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

        public static string PrintMenuChoices(List<string> choices, string topText)
        {
            int menuIndex = 0;            
            ConsoleKey ckey;
            Console.CursorVisible = false;

            do
            {
                Console.Clear();
                Console.WriteLine(topText);

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
                ckey = Console.ReadKey(true).Key;
                switch (ckey)
                {
                    case ConsoleKey.DownArrow:
                        if (menuIndex == choices.Count - 1) { }
                        else { menuIndex++; }
                        break;
                    case ConsoleKey.UpArrow:
                        if (menuIndex <= 0) { }
                        else { menuIndex--; }
                        break;
                    default:
                        Console.Clear();
                        break;
                }                
            } while (ckey != ConsoleKey.Enter);

            Console.CursorVisible = true;
            return choices[menuIndex];
        }
        
        public static void AddPizza()
        {
            Console.Clear();
            Console.CursorVisible = true;
            MenuCatalog.PrintMenu();
            Console.WriteLine("Choose a pizza");
            Console.Write("\nPizza number: ");
            int choice = ParseInt();
            Pizza pizza = new Pizza();
            pizza = MenuCatalog.GetPizza(choice);
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
        }

        public static Customer CreateCustomer()
        {
            Console.CursorVisible = true;
            Console.Write("Write your firstname: ");
            string firstName = Console.ReadLine();            
            Console.Write("Write your lastname: ");
            string lastName = Console.ReadLine();
            return new Customer { FirstName = firstName, LastName = lastName };            
        }
    }
}
