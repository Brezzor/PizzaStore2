using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore2
{
    class Order
    {
        private static List<Order> orders = new List<Order>();
        private Customer _customer;
        private static List<Pizza> _pizzas;
        private int _orderNum = orders.Count;
        private const double _tax = 1.25;
        private const double _deliveryCost = 40;
        public Order()
        {            
            orders.Add(this);            
        }

        public Customer Customer { get { return _customer; } set { _customer = value; } }
        public List<Pizza> Pizzas { get { return _pizzas; } set { _pizzas = value; } }
        private int OrderNum { get { return _orderNum + 1; } }              
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
            Console.WriteLine($"\n---- Pizza order {OrderNum}----");
            Console.WriteLine($"First name: {_customer.FirstName}");
            Console.WriteLine($"Last name: {_customer.LastName}");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Pizzas ordered:");
            foreach (Pizza pizza in _pizzas)
            {
                Console.WriteLine($"{pizza.Name}");
                Console.WriteLine($"{string.Join(", ", pizza.Toppings)}");
            }
            Console.WriteLine($"| Total price: {CalculateTotalPrice()}");
        }
        public static void PrintOrders()
        {
            if (_pizzas != null)
            {
                for (int i = 0; i < orders.Count; i++)
                {
                    Console.WriteLine($"---- Pizza order {orders[i].OrderNum}----");
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
                Console.WriteLine("\nNo Orders made!");
            }
        }
    }
}
