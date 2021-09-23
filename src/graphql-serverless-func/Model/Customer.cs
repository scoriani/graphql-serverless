using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace grapql_serverless
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID {get;set;}
        public string CustomerName {get;set;}

        public List<Order> Orders {get;set;}
    }
}