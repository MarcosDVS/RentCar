using Microsoft.EntityFrameworkCore;
using RentCar.Data.Models;

namespace RentCar.Data.Context
{
    public interface IRentCarDbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<RentalInvoice> Invoices { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}