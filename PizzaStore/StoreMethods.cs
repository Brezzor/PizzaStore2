﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore2
{
    class StoreMethods
    {        
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

        public static void PrintMenuChoices()
        {
            foreach (string s in menuChoices)
            {
                Console.WriteLine(s);
            }
        }

        public static void PrintIntro()
        {
            Console.Clear();
            Console.WriteLine("---- Pizza Store ----");
            Console.WriteLine("\nOptions:");
            PrintMenuChoices();
            Console.WriteLine("Type the number of what you would like to do");
            Console.Write("Command: ");
        }

        public static int MenuChoice()
        {
            PrintIntro();
            int result = StoreMethods.ParseInt();
            return result;
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
