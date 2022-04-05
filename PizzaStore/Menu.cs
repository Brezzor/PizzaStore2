using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore2
{
    class Menu
    {
        private static List<Pizza> menu = new List<Pizza>()
        {
            new Pizza { Name = "Pepperoni pizza", Toppings = {"Sauce", "Cheese", "Pepperoni"} },
            new Pizza { Name = "Hawaian pizza", Toppings = {"Sauce", "Cheese", "Ham", "Pineapple" } },
            new Pizza { Name = "Italien pizza", Toppings = { "Sauce", "Cheese", "Meatballs", "Chili"} },
            new Pizza { Name = "Vegetarien pizza", Toppings = { "Sauce", "Cheese", "Mushrooms", "Pepers", "White Asparagus"} }
        };

        public static void CreatePizza(string name, List<string> toppings)
        {
            menu.Add(new Pizza { Name = name, Toppings = toppings });
        }        

        public static void DeletePizza(int num)
        {
            Pizza pizza = GetPizza(num);
            menu.Remove(pizza);
        }                
        
        public static void PrintMenu()
        {            
            Console.WriteLine("\n|---------- Pizza menu ------------");            
            for (int i = 0; i < menu.Count; i++)
            {
                Console.WriteLine("|----------------------------------");
                Console.WriteLine($"| Nr.{i} | {menu[i].Name} | price: {menu[i].Price}kr.");
                Console.WriteLine("|----------------------------------");
                foreach (string topping in menu[i].Toppings)
                {
                    Console.WriteLine($"| {topping}");
                }
                Console.WriteLine("|----------------------------------");
            }            
        }           
        public static Pizza GetPizza(int num)
        {
            if (num < 0 || num > LastIndexNum())
            {
                return null;
            }
            else
            {
                return menu[num];
            }            
        }        
        public static int LastIndexNum()
        {
            return menu.Count - 1;
        }
    }
}
