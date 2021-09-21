using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace intro
{
    public class OrderLine
    {
        public int OrderLineID {get; set;}
        public int OrderID {get;set;}
        public int StockItemID {get;set;}
        public int Quantity {get;set;}

        public Order Order {get;set;}
    }

}