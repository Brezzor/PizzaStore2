using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore2
{
    class OrderMenu
    {
        private static Customer newCustomer = new Customer();
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
                        AddPizza();
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
                            foreach (Pizza pizza in orderPizzas)
                            {
                                pizza.PrintPizza();
                            }
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
                            newCustomer = CreateCustomer();
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

        private static void AddPizza()
        {
            Console.Clear();
            Console.CursorVisible = true;
            MenuCatalog.PrintMenu();
            Console.WriteLine("Choose a pizza");
            Console.Write("\nPizza number: ");
            int choice = StoreMethods.ParseInt();
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

        private static Customer CreateCustomer()
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
