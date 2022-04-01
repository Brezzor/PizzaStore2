using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore
{
    class Menu
    {
        private static List<Pizza> menu = new List<Pizza>()
        {
            new Pizza("Pepperoni pizza", new List<string>{"Sauce", "Cheese", "Pepperoni"}),
            new Pizza("Hawaian pizza", new List<string>{ "Sauce", "Cheese", "Ham", "Pineapple"}),
            new Pizza("Italian pizza", new List<string>{ "Sauce", "Cheese", "Meatballs", "Chili"}),
            new Pizza("Vegetarian pizza", new List<string>{ "Sauce", "Cheese", "Mushrooms", "Pepers", "White Asparagus"})
        };

        public static void CreatePizza(string name, List<string> toppings)
        {
            menu.Add(new Pizza(name, toppings));
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
                foreach (string topping in menu[i].GetToppings())
                {
                    Console.WriteLine($"| {topping}");
                }
                Console.WriteLine("|----------------------------------");
            }            
        }           
        public static Pizza GetPizza(int num)
        {
            return menu[num];
        }        
        public static int LastIndexNum()
        {
            return menu.Count - 1;
        }
    }
}
