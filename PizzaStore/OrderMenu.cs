﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore2
{
    class OrderMenu
    {
        private static Customer newCustomer = new Customer();
        private static Order newOrder;
        private static List<Pizza> orderPizzas;

        private static string topText()
        {
            string text = " ¤------------------------¤\n" +
                          " | Pizza Store Order Menu |\n" +
                          " ¤------------------------¤\n";
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
            orderPizzas = new List<Pizza>();
            bool done = false;                                   

            while (!done)
            {
                Console.Clear();                                                
                int subMenuChoice = StoreMethods.PrintMenuChoices(orderMenuChoices, topText());

                switch (subMenuChoice)
                {
                    case 1:
                        AddPizza();
                        break;
                    case 2:
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        break;
                    case 4:
                        PrintOrderPizzas();
                        Console.WriteLine("\n Press any key to continue");
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        CreateOrder();
                        Console.WriteLine("\n Press any key to continue");
                        Console.ReadKey();
                        done = true;
                        break;
                    case 6:
                        done = true;
                        break;
                }
            }
        }

        private static void CreateOrder()
        {
            Console.WriteLine(topText());

            if (orderPizzas != null && orderPizzas.Count != 0)
            {
                newCustomer = CreateCustomer();
                newOrder = new Order { Customer = newCustomer, Pizzas = orderPizzas };
                Console.WriteLine();
                newOrder.PrintOrder();
                Console.WriteLine("\n Order has been created");
            }
            else
            {
                Console.WriteLine(" No pizzas was added to the order");
                Console.WriteLine(" No order was created");
            }
        }

        private static void AddPizza()
        {
            Console.Clear();
            Console.CursorVisible = true;
            PizzaCatalog.PrintMenu();
            Console.WriteLine(" Choose a pizza");
            Console.Write("\n Pizza number: ");
            int choice = StoreMethods.ParseInt();
            Pizza pizza = new Pizza();
            pizza = PizzaCatalog.GetPizza(choice);
            if (pizza != null)
            {
                Console.Clear();
                Console.WriteLine(topText());
                Console.WriteLine("\n Pizza has been added");
                orderPizzas.Add(pizza);
                pizza.PrintPizza();
            }
            else
            {
                Console.WriteLine(" No pizza chosen");
            }
            Console.WriteLine("\n Press any key to continue");
            Console.ReadKey();
        }

        private static void PrintOrderPizzas()
        {
            Console.WriteLine(topText());

            if (orderPizzas != null && orderPizzas.Count != 0)
            {
                foreach (Pizza pizza in orderPizzas)
                {
                    pizza.PrintPizza();
                }
            }
            else
            {
                Console.WriteLine(" No order made yet");
            }
        }

        private static Customer CreateCustomer()
        {
            Console.CursorVisible = true;
            Console.Write(" Write your firstname: ");
            string firstName = Console.ReadLine();
            Console.Write(" Write your lastname: ");
            string lastName = Console.ReadLine();
            return new Customer { FirstName = firstName, LastName = lastName };
        }
    }
}
