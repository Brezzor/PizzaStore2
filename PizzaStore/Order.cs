using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore
{
    class Order
    {
        private Customer _customer;
        private static List<Pizza> _pizzas;
        private static List<Order> orders = new List<Order>();
        private int _orderNum = orders.Count;
        private double _tax = 1.25;
        private double _deliveryCost = 40;
        public Order(Customer customer, List<Pizza> pizzas)
        {
            _customer = customer;
            _pizzas = pizzas;
            orders.Add(this);            
        }       
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
            Console.WriteLine($"\n|---- Pizza order {OrderNum}----");
            Console.WriteLine($"| First name: {_customer.FirstName}");
            Console.WriteLine($"| Last name: {_customer.LastName}");
            Console.WriteLine("| Pizzas ordered:");
            foreach (Pizza pizza in _pizzas)
            {
                Console.WriteLine($"| {pizza.Name}");
                foreach (string topping in pizza.GetToppings())
                {
                    Console.WriteLine($"| {string.Join(", ", topping)}");
                }
            }
            Console.WriteLine($"| Total price: {CalculateTotalPrice()}");
        }
        public static void PrintOrders()
        {
            if (_pizzas != null)
            {
                for (int i = 0; i < orders.Count; i++)
                {
                    Console.WriteLine($"\n|---- Pizza order {orders[i].OrderNum}----");
                    Console.WriteLine($"| First name: {orders[i]._customer.FirstName}");
                    Console.WriteLine($"| Last name: {orders[i]._customer.LastName}");
                    foreach (Pizza pizza in _pizzas)
                    {
                        Console.WriteLine($"| {pizza.Name}");
                        foreach (string topping in pizza.GetToppings())
                        {
                            Console.WriteLine($"| {string.Join(", ", topping)}");
                        }
                    }
                    Console.WriteLine($"| Total price: {orders[i].CalculateTotalPrice()}");
                }
            }
            else
            {
                Console.WriteLine("\nNo Orders made!");
            }
        }
    }
}
