using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Diagnostics;

namespace intro
{
    
    public class wwiCtx : DbContext
    {        
        public wwiCtx(DbContextOptions<wwiCtx> options) : base(options)
        {
        }
        public DbSet<Customer> Customers {get;set;}
        public DbSet<Order> Orders {get; set;}
        public DbSet<OrderLine> OrderLines {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .ToTable("Customers","Sales");

            modelBuilder.Entity<Order>()
                .ToTable("Orders","Sales");

            modelBuilder.Entity<OrderLine>()
                .ToTable("OrderLines","Sales");
        }
    }
}