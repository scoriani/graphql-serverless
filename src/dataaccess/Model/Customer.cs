using System.Collections.Generic;

namespace dataaccess
{

    public class Customer
    {
        public int CustomerID {get; set;}
        public string? CustomerName {get;set;}

        public List<Order>? Orders {get;set;}
    }

}