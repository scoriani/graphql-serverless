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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .ToTable("Customers","Sales");

            modelBuilder.Entity<Customer>()        
                .Property(c => c.CustomerID).HasColumnName("CustomerID").IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(c => c.CustomerName).HasColumnName("CustomerName").IsRequired();

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne();

            modelBuilder.Entity<Order>()
                .ToTable("Orders","Sales");

            modelBuilder.Entity<Order>()        
                .Property(o => o.OrderID).HasColumnName("OrderID").IsRequired();





        }
    }
}