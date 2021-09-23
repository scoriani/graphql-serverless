using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace grapql_serverless
{
    public class Query 
    {
        [UseDbContext(typeof(wwiCtx))]
        [UsePaging(IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Customer> GetCustomers([ScopedService]wwiCtx db) => 
                db.Customers.AsNoTracking().OrderBy(c => c.CustomerID);

        [UseDbContext(typeof(wwiCtx))]
        public IQueryable<Order> GetOrder([ScopedService]wwiCtx db, int orderID)
        {
            return db.Orders.AsNoTracking().Include("OrderLines").Include("Customer").Where(o => o.OrderID == orderID);
        }
    }
}