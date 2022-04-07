using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore2
{
    class OrderMenu
    {
        private static Customer newCustomer;
        private static Order newOrder;
        private static List<Pizza> orderPizzas = new List<Pizza>();

        private static string topText()
        {
            string text = "¤------------------------¤\n" +
                          "| Pizza Store Order Menu |\n" +
                          "¤------------------------¤\n";
            return text;
        }

        private static List<string> orderMenuChoices = new List<string>()
        {
            "Add Pizza",
            "Remove Pizza",
            "Edit Pizza",
            "Show Order",
            "Create",
            "Cancel"
        };

        public static void PrintOrderMenu()
        {
            bool done = false;                                   

            while (!done)
            {
                Console.Clear();                                                
                string subMenuChoice = StoreMethods.PrintMenuChoices(orderMenuChoices, topText());

                switch (subMenuChoice)
                {
                    case "Add Pizza":
                        StoreMethods.AddPizza();
                        break;
                    case "Remove Pizza":
                        Console.Clear();
                        break;
                    case "Edit Pizza":
                        Console.Clear();
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
                        break;
                    case "Create":
                        Console.Clear();
                        Console.CursorVisible = true;
                        if (orderPizzas != null && orderPizzas.Count != 0)
                        {
                            newOrder = new Order { Customer = newCustomer, Pizzas = orderPizzas };
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
                        break;
                    case "Cancel":
                        done = true;
                        break;
                }
            }
        }
    }
}
