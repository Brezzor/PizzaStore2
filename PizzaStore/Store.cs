using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore
{
    class Store
    {
        static string Input;
        static int Choice;
        static int menuNum;
        static bool correctCommand = false;
        static bool _exit = false;

        private static List<string> menuChoices = new List<string>()
        {
            "[1]: Menu",
            "[2]: Make order",
            "[3]: Show orders",
            "[0]: Exit"
        };

        private static void PrintMenuChoices()
        {
            foreach (string s in menuChoices)
            {
                Console.WriteLine(s);
            }
        }

        public static void Start()
        {
            while (!_exit)
            {
                #region Display Pizza Store
                Console.Clear();
                Console.WriteLine("---- Pizza Store ----");
                PrintMenuChoices();
                Console.WriteLine("Type the number of what you would like to do");
                #endregion

                Console.Write("\nCommand: ");
                Input = Console.ReadLine();
                if (int.TryParse(Input, out Choice))
                {
                    if (Choice >= menuChoices.Count)
                    {
                        return;
                    }
                    else
                    {
                        switch (Choice)
                        {
                            case 1:
                                Menu.PrintMenu();
                                Console.Write("\nPress any key to continue");
                                Console.ReadKey();
                                break;
                            case 2:
                                Menu.PrintMenu();
                                Console.WriteLine("\nWhat's number of pizza, would you like?");

                                while (!correctCommand)
                                {
                                    Console.Write("\nPizza number: ");
                                    while (!int.TryParse(Console.ReadLine(), out menuNum))
                                    {
                                        Console.WriteLine("Invalid number!");
                                        Console.WriteLine("Has to be a number");
                                        Console.Write("Press any key to continue");
                                        Console.ReadKey();
                                        Console.Write("\nPizza number: ");
                                    }
                                    if (menuNum <= Menu.LastIndexNum())
                                    {
                                        correctCommand = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid number!");
                                        Console.WriteLine("Has to be on the menu");
                                        Console.Write("Press any key to continue");
                                        Console.ReadKey();
                                    }
                                }
                                correctCommand = false;

                                Pizza pizza = Menu.GetPizza(menuNum);
                                List<Pizza> pizzas = new List<Pizza>();
                                pizzas.Add(pizza);

                                Console.WriteLine("\n-- Customer info --");
                                Console.Write("First name: ");
                                string firstName = Console.ReadLine();
                                Console.Write("Last name: ");
                                string lastName = Console.ReadLine();

                                Customer customer = new Customer { FirstName = firstName, LastName = lastName };

                                Order order = new Order(customer, pizzas);

                                order.PrintOrder();

                                Console.Write("\nPress any key to continue");
                                Console.ReadKey();
                                break;
                            case 3:
                                Order.PrintOrders();

                                Console.Write("\nPress any key to continue");
                                Console.ReadKey();
                                break;
                            case 0:
                                _exit = true;
                                break;
                            default:
                                Console.WriteLine("Inavlid command!");
                                Console.WriteLine("Command is not possible");
                                Console.Write("Press any key to continue");
                                Console.ReadKey();
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid command!");
                    Console.WriteLine("Command has to be a number");
                    Console.Write("Press any key to continue");
                    Console.ReadKey();
                }
            }
        }
    }
}
