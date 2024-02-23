using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RentCar.Data.Models;

namespace RentCar.Data.Context;

    public class RentCarDbContext : DbContext, IRentCarDbContext
    {
        public RentCarDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<RentalInvoice> Invoices { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
