using System;
using System.Collections.Generic;
using System.Threading;

namespace PizzaStore
{
    class Program
    {        
        static void Main(string[] args)
        {            
            Store.Start();

            Console.WriteLine("Press any key to terminate program!");
            Console.ReadKey();
        }
    }
}
