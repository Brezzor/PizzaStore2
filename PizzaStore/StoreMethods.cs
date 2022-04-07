using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PizzaStore2
{
    class StoreMethods
    {                                  
        public static int ParseInt()
        {
            string input = Console.ReadKey().KeyChar.ToString();
            Console.WriteLine();
            try
            {
                int result = int.Parse(input);
                return result;
            }
            catch (Exception)
            {
                Console.WriteLine($"Input was in wrong format. Input has to be a number");                
            }            
            return -1;
        }

        public static string PrintMenuChoices(List<string> choices, string topText)
        {
            int menuIndex = 0;            
            ConsoleKey ckey;
            Console.CursorVisible = false;

            do
            {
                Console.Clear();
                Console.WriteLine(topText);

                for (int i = 0; i < choices.Count; i++)
                {
                    if (i == menuIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(choices[i]);
                    }
                    else
                    {
                        Console.WriteLine(choices[i]);
                    }
                    Console.ResetColor();
                }                
                ckey = Console.ReadKey(true).Key;
                switch (ckey)
                {
                    case ConsoleKey.DownArrow:
                        if (menuIndex == choices.Count - 1) { }
                        else { menuIndex++; }
                        break;
                    case ConsoleKey.UpArrow:
                        if (menuIndex <= 0) { }
                        else { menuIndex--; }
                        break;
                    default:
                        Console.Clear();
                        break;
                }                
            } while (ckey != ConsoleKey.Enter);

            Console.CursorVisible = true;
            return choices[menuIndex];
        }               
    }
}
