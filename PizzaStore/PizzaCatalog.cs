using PizzaStore2.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaStore2
{
    class PizzaCatalog
    {
        private const string JsonPath = "../../../Data/Pizzas.json";
        private static Dictionary<int, Pizza> AllPizzas()
        {
            return JsonFileReader.ReadJson(JsonPath);
        }

        public static void EditPizza(Pizza pizza)
        {
            Dictionary<int, Pizza> pizzas = AllPizzas();

            if (pizza != null)
            {
                pizzas[pizza.Id] = pizza;
                JsonFileWriter.WriteToJson(pizzas, JsonPath);
            }
        }

        public static void AddPizza(Pizza pizza)
        {
            Dictionary<int, Pizza> pizzas = AllPizzas();

            if (pizzas.ContainsKey(pizza.Id))
            {
                Console.WriteLine($"\n Menu already contains pizza with Id '{pizza.Id}'");
            }
            else
            {
                pizzas.Add(pizza.Id, pizza);
                JsonFileWriter.WriteToJson(pizzas, JsonPath);
                Console.WriteLine($"\n Pizza has been created");                
            }
        }        

        public static void DeletePizza(int num)
        {
            Dictionary<int, Pizza> pizzas = AllPizzas();

            if (pizzas.ContainsKey(num))
            {
                pizzas.Remove(num);
                JsonFileWriter.WriteToJson(pizzas, JsonPath);
            }
            else if (pizzas == null || pizzas.Count <= 0)
            {
                Console.WriteLine("\n Pizza Catalog is empty");
            }
            else
            {
                Console.WriteLine($"\n '{num}' does'nt exist");
            }
        }                
        
        public static void PrintMenu()
        {
            Dictionary<int, Pizza> pizzas = AllPizzas();

            Console.WriteLine(" ¤--------------------¤");
            Console.WriteLine(" | Pizza Menu Catalog |");
            Console.WriteLine(" ¤--------------------¤");
            Console.WriteLine();

            foreach (var p in pizzas)
            {
                p.Value.PrintPizza();
            }            
        }           
        public static Pizza GetPizza(int num)
        {
            Dictionary<int, Pizza> pizzas = AllPizzas();

            if (pizzas.ContainsKey(num))
            {
                return pizzas[num];
            }
            else
            {
                Console.WriteLine($" '{num}' does'nt exist");
                return null;
            }
        }
    }
}
