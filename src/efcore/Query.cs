using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace intro
{
    public class Query 
    {
        [UseDbContext(typeof(wwiCtx))]
        public IQueryable<Customer> GetCustomer([ScopedService]wwiCtx db, int id) => 
                db.Customers.Include("Orders").AsNoTracking().Where<Customer>(c => c.CustomerID == id);

        [UseDbContext(typeof(wwiCtx))]
        [UsePaging(IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Customer> GetCustomers([ScopedService]wwiCtx db) => 
                db.Customers;
    }
}