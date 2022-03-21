using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore
{
    class Menu
    {
        private static List<Pizza> menu = new List<Pizza>()
        {
            new Pizza("Pepperoni pizza", new List<string>(){"Pepperoni"}, 60),
            new Pizza("Hawaian pizza", new List<string>(){"Ham", "Pineapple"}, 65),
            new Pizza("Italian pizza", new List<string>(){"Meatballs", "Chili"}, 65),
            new Pizza("Vegetarian pizza", new List<string>(){"Mushrooms", "Pepers", "Asparagus"}, 70)
        };        
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
                Console.WriteLine($"|Pizza nr.{i}: {pizzas[i].Name} | price: {pizzas[i].Price}kr.");                
                pizzas[i].GetToppings();                
            }
            Console.WriteLine("|----------------------------------");
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
