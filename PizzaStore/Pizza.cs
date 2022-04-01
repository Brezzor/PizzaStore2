using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore
{
    class Pizza
    {
        private const int _toppingPrice = 5;        
        private string _name;        
        private List<string> _toppings = new List<string>();
        private const double _basePrice = 45;
        private double _price;

        public Pizza(string name, List<string> toppings)
        {            
            _name = name;
            _price = _basePrice;
            foreach (string topping in toppings)
            {
                _toppings.Add(topping);                
                _price = _price + _toppingPrice; 
            }            
        }
        
        public string Name { get { return _name; } set { _name = value; } }

        public List<string> GetToppings()
        {
            return _toppings;
        }

        public double Price { get { return _price; } }
    }
}