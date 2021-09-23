using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace grapql_serverless
{
    public class Order
    {
        public int OrderID {get;set;}
        public int CustomerID {get;set;}
        public DateTime OrderDate {get;set;}

        public List<OrderLine> OrderLines {get;set;}
        public Customer Customer {get;set;}
    }
}