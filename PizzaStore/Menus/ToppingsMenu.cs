using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PizzaStore2
{
    class ToppingsMenu
    {
        private static List<string> toppings = new List<string>();

        private static string topText()
        {
            string text = " ¤-----------------¤\n" +
                          " | Choose Toppings |\n" +
                          " ¤-----------------¤\n";
            return text;
        }

        private static List<string> toppingsMenuChoices = new List<string>()
        {
            "Add Topping",
            "Remove Topping",
            "Done",
            "Cancel"
        };

        public static void PrintToppingsMenu()
        {
            bool done = false;

            while (!done)
            {
                int menuChoice = StoreMethods.PrintMenuChoices(toppingsMenuChoices, topText());

                switch (menuChoice)
                {
                    case 1:
                        AddTopping();
                        break;
                    case 2:
                        RemoveTopping();
                        break;
                    case 3:
                        NewPizzaMenu.UpdateToppings(toppings);
                        done = true;
                        break;
                    case 4:
                        toppings = new List<string>();
                        done = true;
                        break;
                }
            }
        }

        private static void AddTopping()
        {
            Console.Clear();
            Console.WriteLine(topText());
            Console.WriteLine("\n What topping would you like?");
            Console.Write(" Topping: ");
            string topping = Console.ReadLine();
            toppings.Add(topping);
            Console.Write("\n Press any key to continue");
            Console.ReadKey();
        }

        private static void RemoveTopping()
        {
            Console.Clear();
            Console.WriteLine(topText());
            PrintToppings();
            if (toppings == null || toppings.Count <= 0) { }            
            else
            {
                Console.WriteLine("\n Remove topping by choosing a number");
                Console.WriteLine("\n What topping would you like to remove?");
                Console.Write(" Topping: ");
                int num = StoreMethods.ParseInt();
                try
                {
                    string topping = toppings[num];
                    toppings.Remove(topping);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine(" Invalid number");
                }
            }
            Console.Write("\n Press any key to continue");
            Console.ReadKey();
        }

        private static void PrintToppings()
        {
            if (toppings == null || toppings.Count <= 0)
            {
                Console.WriteLine($" Pizza Has No Toppings");
            }
            else
            {
                Console.WriteLine(" List of toppings");
                Console.WriteLine();

                for (int i = 0; i < toppings.Count; i++)
                {
                    Console.WriteLine($" [{i}] {toppings[i]}");
                }
            }
        }
    }
}
