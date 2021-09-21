using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace intro
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID {get;set;}
        public int CustomerID {get;set;}
        public DateTime OrderDate {get;set;}
    }
}