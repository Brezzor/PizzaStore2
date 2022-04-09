using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PizzaStore2
{
    class NewPizzaMenu
    {
        private static Pizza _newPizza = new Pizza();
        private static int _id;
        private static string _name;        

        private static string topText()
        {
            string text = " ¤------------------¤\n" +
                          " | Create New Pizza |\n" +
                          " ¤------------------¤\n";
            return text;
        }

        private static List<string> newPizzaMenuChoices = new List<string>()
        {
            "Pizza Id",
            "Pizza Name",
            "Toppings",
            "Show Pizza",
            "Create",
            "Cancel"
        };

        public static void PrintNewPizzaMenu()
        {
            bool done = false;

            while (!done)
            {                
                int menuChoice = StoreMethods.PrintMenuChoices(newPizzaMenuChoices, topText());                

                switch (menuChoice)
                {
                    case 1:
                        ChooseId();
                        break;
                    case 2:
                        ChooseName();
                        break;
                    case 3:
                        ToppingsMenu.PrintToppingsMenu();
                        break;
                    case 4:
                        ShowPizza();
                        break;
                    case 5:
                        CreatePizza();
                        done = true;
                        break;
                    case 6:
                        done = true;                        
                        break;
                }
            }
        }

        private static void ChooseId()
        {
            Console.WriteLine(topText());
            Console.Write("\n Choose an Id: ");
            int input = StoreMethods.ParseInt();

            if (input < 0 )
            {
                Console.WriteLine($"\n '{input}' has to be a positiv number");                
            }
            else
            {
                _id = input;
                _newPizza.Id = _id;
                Console.WriteLine($"\n Pizza Id.{_id} has been chosen");                
            }
            Console.Write("\n Press any key to continue");
            Console.ReadKey();
        }

        private static void ChooseName()
        {
            Console.WriteLine(topText());
            Console.Write("\n Choose a Name: ");
            _name = Console.ReadLine();
            _newPizza.Name = _name;
            Console.WriteLine($"\n Pizza Name '{_name}' has been chosen");
            Console.Write("\n Press any key to continue");
            Console.ReadKey();
        }

        public static void UpdateToppings(List<string> toppings)
        {
            _newPizza.Toppings = toppings;            
        }

        private static void ShowPizza()
        {
            Console.WriteLine(topText());
            _newPizza.PrintPizza();
            Console.Write("\n Press any key to continue");
            Console.ReadKey();
        }

        private static void CreatePizza()
        {
            Console.Clear();
            Console.WriteLine(topText());
            PizzaCatalog.AddPizza(_newPizza);
            Console.ReadKey();
        }
    }
}
