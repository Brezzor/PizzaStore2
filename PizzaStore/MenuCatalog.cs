using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaStore2
{
    class MenuCatalog
    {
        private static Dictionary<int,Pizza> menu = new Dictionary<int, Pizza>()
        {
            { 1 , new Pizza { Id = 1, Name = "Pepperoni pizza", Toppings = {"Sauce", "Cheese", "Pepperoni"} } },
            { 2 , new Pizza { Id = 2, Name = "Hawaian pizza", Toppings = {"Sauce", "Cheese", "Ham", "Pineapple" } } },
            { 3 , new Pizza { Id = 3, Name = "Italien pizza", Toppings = { "Sauce", "Cheese", "Meatballs", "Chili"} } },
            { 4 , new Pizza { Id = 4, Name = "Vegetarien pizza", Toppings = { "Sauce", "Cheese", "Mushrooms", "Pepers", "White Asparagus"} } }
        };

        public static void EditPizza(Pizza pizza)
        {
            menu[pizza.Id] = pizza;
        }

        public static void AddPizza(Pizza pizza)
        {
            menu.Add(pizza.Id, pizza);
        }        

        public static void DeletePizza(int num)
        {            
            menu.Remove(num);
        }                
        
        public static void PrintMenu()
        {
            Console.WriteLine("¤--------------------¤");
            Console.WriteLine("| Pizza Menu Catalog |");
            Console.WriteLine("¤--------------------¤");
            Console.WriteLine();
            foreach (var p in menu)
            {
                p.Value.PrintPizza();
            }
            Console.WriteLine("----------------------------------");
        }           
        public static Pizza GetPizza(int num)
        {            
            try
            {                                
                return menu[num];
            }
            catch (KeyNotFoundException)
            {                
                Console.WriteLine($"'{num}' does'nt exist");                
                return null;
            }                                             
        }        
        public static int LastIndexNum()
        {
            return menu.Count - 1;
        }
    }
}
