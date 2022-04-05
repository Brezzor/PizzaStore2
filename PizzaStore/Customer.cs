using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore2
{
    class Customer
    {
        private string _firstName;
        private string _lastName;
        public Customer()
        {
        }
        public string FirstName { get { return _firstName; } set { _firstName = value; } }
        public string LastName { get { return _lastName; } set { _lastName = value; } }
    }
}
