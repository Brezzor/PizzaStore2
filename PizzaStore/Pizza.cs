using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore
{
    class Pizza
    {
        private string _name;        
        private List<string> _toppings = new List<string>();
        private double _price;
        public Pizza(string name, List<string> toppings, double price)
        {
            _name = name;
            foreach (string topping in toppings)
            {
                _toppings.Add(topping);
            }
            _price = price;
        }
        public string Name { get { return _name; } }
        public List<string> GetToppings()
        {
            return _toppings;
        }
        public double Price { get { return _price; } }
    }
}