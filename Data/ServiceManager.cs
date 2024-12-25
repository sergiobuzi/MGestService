using MGestService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MGestService.Models.Options;
using Microsoft.EntityFrameworkCore;

namespace MGestService.Data
{
    public class ServiceManager 
    {
        private readonly ServiceContext _context;

        public ServiceManager(ServiceContext context, IOptions<DatabaseOptions> options)
        {
            _context = context;
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
        }

        public void AddProcedure(Procedure procedure)
        {
            _context.Procedures.Add(procedure);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<Procedure> GetAllProcedures()
        {
            return _context.Procedures
                .Include(p => p.Customer)
                .ThenInclude(c => c.CustomerStatus)
                .Include(p => p.Product)
                .Include(p => p.ProductStatus)
                .ToList();
        }

        public List<CustomerStatus> GetAllCustomerStatuses()
        {
            return _context.CustomerStatuses.ToList();
        }

        public List<ProductStatus> GetAllProductStatuses()
        {
            return _context.ProductStatuses.ToList();
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers
                .Include(c => c.CustomerStatus)
                .ToList();
        }
    }
}
