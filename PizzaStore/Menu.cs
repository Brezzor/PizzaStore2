using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore
{
    class Menu
    {
        private static List<Pizza> menu = new List<Pizza>()
        {
            new Pizza("Pepperoni pizza", new List<string>{"Pepperoni"}),
            new Pizza("Hawaian pizza", new List<string>{"Ham", "Pineapple"}),
            new Pizza("Italian pizza", new List<string>{"Meatballs", "Chili"}),
            new Pizza("Vegetarian pizza", new List<string>{"Mushrooms", "Pepers", "White Asparagus"})
        };       
        
        public static void Create(string name, List<string> toppings)
        {
            menu.Add(new Pizza(name, toppings));
        }
        public static List<Pizza> GetMenu()
        {            
            return menu;
        }
        public static void PrintMenu()
        {
            List<Pizza> pizzas = GetMenu();

            Console.WriteLine("\n|---------- Pizza menu ------------");
            Console.WriteLine("|----------------------------------");
            for (int i = 0; i < pizzas.Count; i++)
            {
                Console.WriteLine($"| Pizza nr.{i}: {pizzas[i].Name} | price: {pizzas[i].Price}kr.");
                foreach (string topping in pizzas[i].GetToppings())
                {
                    Console.WriteLine($"| {topping}");
                }
                Console.WriteLine("|----------------------------------");
            }            
        }           
        public static Pizza GetPizza(int num)
        {
            return GetMenu()[num];
        }        
        public static int LastIndexNum()
        {
            return Menu.GetMenu().Count - 1;
        }
    }
}
