using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore2
{
    class Order
    {
        public static List<Order> _orders = new List<Order>();
        private Customer _customer = new Customer();
        private static List<Pizza> _pizzas = new List<Pizza>();        
        private const double _tax = 1.25;
        private const double _deliveryCost = 40;

        public Order()
        {
            if (this != null)
            {
                _orders.Add(this);
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
            Console.WriteLine("\n ---------------------------------");
            Console.WriteLine($" First name: {Customer.FirstName}");
            Console.WriteLine($" Last name: {Customer.LastName}");
            Console.WriteLine(" ---------------------------------");
            Console.WriteLine(" Pizzas ordered:");
            foreach (Pizza pizza in _pizzas)
            {
                pizza.PrintPizza();                
            }
            Console.WriteLine($" Total price: {CalculateTotalPrice()}");
        }
        public static void PrintOrders()
        {
            Console.WriteLine(" ¤--------------¤");
            Console.WriteLine(" | Pizza Orders |");
            Console.WriteLine(" ¤--------------¤");            

            if (_orders == null || _orders.Count == 0)
            {
                Console.WriteLine("\n No Orders made!");
            }
            else
            {
                foreach (Order order in _orders)
                {
                    order.PrintOrder();
                }                
            }
        }
    }
}
