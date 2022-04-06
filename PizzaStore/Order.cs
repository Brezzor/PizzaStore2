﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore2
{
    class Order
    {
        private static List<Order> orders;
        private Customer _customer;
        private static List<Pizza> _pizzas;        
        private const double _tax = 1.25;
        private const double _deliveryCost = 40;
        public Order()
        {
            if (this != null)
            {
                orders.Add(this);
            }            
        }

        public Customer Customer { get { return _customer; } set { _customer = value; } }
        public List<Pizza> Pizzas { get { return _pizzas; } set { _pizzas = value; } }                      
        private double CalculateTotalPrice()
        {
            double result = 0;
            for (int i = 0; i < _pizzas.Count; i++)
            {
                result = result + _pizzas[i].Price;
            }
            return result * _tax + _deliveryCost;
        }
        public void PrintOrder()
        {
            Console.WriteLine($"\n---- Pizza order ----");
            Console.WriteLine($"First name: {Customer.FirstName}");
            Console.WriteLine($"Last name: {Customer.LastName}");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Pizzas ordered:");
            foreach (Pizza pizza in _pizzas)
            {
                pizza.PrintPizza();                
            }
            Console.WriteLine($"Total price: {CalculateTotalPrice()}");
        }
        public static void PrintOrders()
        {
            Console.WriteLine("¤--------------¤");
            Console.WriteLine("| Pizza Orders |");
            Console.WriteLine("¤--------------¤");
            Console.WriteLine();

            if (_pizzas != null)
            {
                for (int i = 0; i < orders.Count; i++)
                {
                    Console.WriteLine($"---- Pizza order {i} ----");
                    Console.WriteLine($"First name: {orders[i]._customer.FirstName}");
                    Console.WriteLine($"Last name: {orders[i]._customer.LastName}");
                    Console.WriteLine("-------------------------------------------");
                    foreach (Pizza pizza in _pizzas)
                    {
                        Console.WriteLine($"{pizza.Name}");
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine($"{string.Join(", ", pizza.Toppings)}");
                    }
                    Console.WriteLine($"Total price: {orders[i].CalculateTotalPrice()}");
                    Console.WriteLine("-------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("No Orders made!");
            }
        }
    }
}
