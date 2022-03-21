using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore
{
    class Customer
    {
        private string _firstName;
        private string _lastName;
        public Customer(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }
        public string FirstName { get { return _firstName; } }
        public string LastName { get { return _lastName; } }
    }
}
