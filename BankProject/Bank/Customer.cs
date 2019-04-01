using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Customer
    {
        private static int numberOfCust;
        readonly int customerId;
        readonly int customerNumber;
        public string Name { get;private set; }
        public int PhNumber { get;private set; }        
        public int CustomerId
        {
            get
            {
                return customerId;
            }
                
        }
        public int CustomerNumber
        {
            get
            {
                return customerNumber;
            }
        }

        public Customer(int id, string name, int phone)
        {
            customerId = id;
            Name = name;
            PhNumber = phone;            
            customerNumber = numberOfCust++;            
        }

        public override string ToString()
        {
            return $"name: {Name} id: {customerId} number: {customerNumber}";
        }
    }
}
