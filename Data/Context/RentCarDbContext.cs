using Microsoft.EntityFrameworkCore;
using RentCar.Data.Models;

namespace RentCar.Data.Context
{
    public class RentCarDbContext : DbContext, IRentCarDbContext
    {
        private readonly IConfiguration config;

        public RentCarDbContext(IConfiguration config)
        {
            this.config = config;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<RentalInvoice> Invoices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString("MSSQL"));
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}