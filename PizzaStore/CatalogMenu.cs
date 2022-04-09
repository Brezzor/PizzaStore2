using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore2
{
    class CatalogMenu
    {
        private static string topText()
        {
            string text = " ¤----------------------¤\n" +
                          " | Pizza Catalog Editor |\n" +
                          " ¤----------------------¤\n";
            return text;
        }

        private static List<string> updateCatalogChoices = new List<string>()
        {
            "Edit Pizza",
            "Add Pizza",
            "Remove Pizza",            
            "Go Back"
        };

        public static void PrintEditPizzaCatalogMenu()
        {
            bool done = false;

            while (!done)
            {
                Console.Clear();
                int subMenuChoice = StoreMethods.PrintMenuChoices(updateCatalogChoices, topText());

                switch (subMenuChoice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("\n Press any key to continue");
                        Console.ReadKey();
                        break;
                    case 2:                        
                        NewPizzaMenu.PrintNewPizzaMenu();                        
                        break;
                    case 3:
                        Console.Clear();
                        DeletePizza();
                        Console.WriteLine("\n Press any key to continue");
                        Console.ReadKey();
                        break;
                    case 4:
                        done = true;
                        break;                    
                }
            }
        }

        private static void DeletePizza()
        {
            Console.WriteLine(topText());
            PizzaCatalog.PrintMenu();
            Console.Write("\n Choose a number: ");
            PizzaCatalog.DeletePizza(StoreMethods.ParseInt());
        }
    }
}

