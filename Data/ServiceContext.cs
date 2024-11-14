using Microsoft.AspNetCore.Mvc;
using MGestService.Models;
using Microsoft.EntityFrameworkCore;

namespace MGestService.Data
{
    public class ServiceContext : DbContext
    {
        public ServiceContext(DbContextOptions<ServiceContext> options) : base(options) { }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProductStatus> ProductStatuses { get; set; }
        public DbSet<CustomerStatus> CustomerStatuses { get; set; }
    }
}
