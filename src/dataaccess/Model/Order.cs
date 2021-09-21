using System;
using System.Collections.Generic;

namespace dataaccess
{
    public class Order
    {
        public int OrderID {get;set;}
        public int CustomerID {get; set;}
        public DateTime OrderDate {get;set;}

        public List<OrderLine>? OrderLines {get;set;}
        public Customer? Customer {get;set;}
    }
}