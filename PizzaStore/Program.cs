﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace PizzaStore2
{
    class Program
    {        
        static void Main(string[] args)
        {            
            Store.Start();

            Console.WriteLine("\nPress any key to terminate program!");
            Console.ReadKey();
        }
    }
}
