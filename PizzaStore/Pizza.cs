using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore
{
    class Pizza
    {        
        private string _name;        
        private List<string> _toppings = new List<string>();
        private const int _toppingPrice = 5;
        private const double _basePrice = 45;
        private double _price;

        public Pizza()
        {            
            _name = "";
            _price = _basePrice;                      
        }
        
        public string Name { get { return _name; } set { _name = value; } }

        public List<string> Toppings { get { return _toppings; } set { _toppings = value; } }       

        public double Price 
        {
            get
            {
                double toppingPrice = 0;
                foreach (string s in Toppings)
                {
                    toppingPrice = toppingPrice + _toppingPrice;
                }
                return _price + toppingPrice;
            } 
        }
    }
}