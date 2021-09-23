using Microsoft.Data.SqlClient;
using Dapper;
using DapperExtensions;
using System.Linq;

namespace dataaccess
{
    public static class db 
    {
        public static string? cnnStr = System.Environment.GetEnvironmentVariable("CONNSTR");

        public static Order? GetOrder(int orderID)
        {
            using(SqlConnection cnn = new SqlConnection(cnnStr))
            {
                cnn.Open();
                string cmd = @"SELECT SO.OrderID, SO.CustomerID, SO.OrderDate, C.CustomerID,C.CustomerName FROM 
                                    Sales.Orders SO 
                                LEFT JOIN 
                                    Sales.Customers C ON SO.CustomerID = C.CustomerID
                                WHERE SO.OrderID = @OrderID;
                                SELECT OrderLineID, OrderID, StockItemID, Quantity FROM Sales.OrderLines WHERE OrderID = @OrderID";

                var parameters = new DynamicParameters(new {OrderID=orderID});

                var grid = cnn.QueryMultiple(cmd, parameters);                

                var ord = grid.Read<Order, Customer, Order>((order, customer) => { order.Customer = customer; return order; }, splitOn: "CustomerID").SingleOrDefault();
                
                var ordlns = grid.Read<OrderLine>().ToList();                

                ord.OrderLines = ordlns;   

                return ord;
            }            
        }

        public static OrderLine AddOrderLine(AddOrderLineInput input )
        {
            
            using(SqlConnection cnn = new SqlConnection(cnnStr))
            {
                cnn.Open();
            
                var parameters = new DynamicParameters(new {OrderLineID=input.OrderLineID, OrderID=input.OrderID, StockItemID=input.StockItemID, Quantity= input.Quantity });

                string cmd = @"INSERT INTO Sales.OrderLines (OrderLineID, OrderID, StockItemID, Quantity,[Description],[PackageTypeID],[UnitPrice],[TaxRate],[PickedQuantity],[LastEditedBy]) VALUES (@OrderLineID, @OrderID, @StockItemID, @Quantity,'',7,11.2,15.00,12,4);
                               SELECT OrderLineID, OrderID, StockItemID, Quantity FROM Sales.OrderLines WHERE OrderLineID = @OrderLineID";
                
                var ordln = cnn.Query<OrderLine>(cmd, parameters).SingleOrDefault();

                return ordln;
            }
        }

    }
}