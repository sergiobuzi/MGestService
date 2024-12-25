using MGestService.Data;
using MGestService.Models;
using Microsoft.AspNetCore.Mvc;

namespace MGestService.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ServiceManager _serviceManager;

        public ServiceController(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            // Recupera le entità dal database tramite il ServiceManager
            var customers = _serviceManager.GetAllCustomers();
            var procedures = _serviceManager.GetAllProcedures();
            var customerStatuses = _serviceManager.GetAllCustomerStatuses();
            var productStatuses = _serviceManager.GetAllProductStatuses();
            var products = _serviceManager.GetAllProducts();

            // Mappa i dati al ViewModel
            var viewModel = procedures.Select(p => new ProcedureFormViewModel
            {
                ProcedureId = p.ProcedureId,
                CustomerStatusId = p.Customer.CustomerStatusId,
                CustomerStatuses = customerStatuses,
                ProductStatusId = p.ProductStatusId,
                ProductStatuses = productStatuses,
                EntryDate = p.EntryDate,
                ProblemDescription = p.ProblemDescription,
                PurchaseDate = p.PurchaseDate,
                WorkSummary = p.WorkSummary,
                TotalCost = p.TotalCost,
                TechnicalExamCost = p.TechnicalExamCost,
                Accessories = p.Accessories,
                Warranty = p.Warranty,
                WarrantyNumber = p.WarrantyNumber,
                WarrantyPath = p.WarrantyPath,
                Name = p.Customer.Name,
                Surname = p.Customer.Surname,
                PhoneNumber = p.Customer.PhoneNumber,
                Email = p.Customer.Email,
                Brand = p.Product.Brand,
                ProductModel = p.Product.ProductModel,
                SerialNumber = p.Product.SerialNumber
            }).ToList();

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult GetCreateProcedure()
        {
            return View("CreateProcedure");
        }

        [HttpPost]
        public IActionResult CreateProcedure(ProcedureFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Creazione del Customer
                    Customer customer = new Customer
                    {
                        Name = model.Name,
                        Surname = model.Surname,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        CustomerStatusId = model.CustomerStatusId ?? 2
                    };

                    _serviceManager.AddCustomer(customer);
                    _serviceManager.SaveChanges();

                    // Creazione del Product
                    Product product = new Product
                    {
                        Brand = model.Brand,
                        ProductModel = model.ProductModel,
                        SerialNumber = model.SerialNumber
                    };

                    _serviceManager.AddProduct(product);
                    _serviceManager.SaveChanges();

                    // Creazione della Procedure
                    Procedure procedure = new Procedure
                    {
                        EntryDate = DateTime.Now,
                        ProblemDescription = model.ProblemDescription,
                        PurchaseDate = model.PurchaseDate,
                        WorkSummary = model.WorkSummary,
                        TotalCost = model.TotalCost,
                        TechnicalExamCost = model.TechnicalExamCost,
                        Accessories = model.Accessories,
                        Warranty = model.Warranty,
                        WarrantyNumber = model.WarrantyNumber,
                        WarrantyPath = model.WarrantyPath,
                        CustomerId = customer.CustomerId,
                        ProductStatusId = model.ProductStatusId ?? 1,
                        ProductId = product.ProductId
                    };

                    _serviceManager.AddProcedure(procedure);
                    _serviceManager.SaveChanges();

                    model.CustomerStatuses = _serviceManager.GetAllCustomerStatuses();
                    model.ProductStatuses = _serviceManager.GetAllProductStatuses();

                    // Recupera tutte le procedure per la vista
                    var procedures = _serviceManager.GetAllProcedures();

                    // Prepara il ViewModel come lista
                    var viewModel = procedures.Select(p => new ProcedureFormViewModel
                    {
                        ProcedureId = p.ProcedureId,
                        CustomerStatusId = p.Customer.CustomerStatusId,
                        ProductStatusId = p.ProductStatusId,
                        EntryDate = p.EntryDate,
                        ProblemDescription = p.ProblemDescription,
                        Name = p.Customer.Name,
                        Surname = p.Customer.Surname,
                        Brand = p.Product.Brand,
                        ProductModel = p.Product.ProductModel,
                        SerialNumber = p.Product.SerialNumber
                    }).ToList();

                    return View("Index", viewModel);

                }
                catch (Exception ee)
                {
                    throw new Exception(ee.Message);
                }
            }

            return View("CreateProcedure", model);
         }

    }
}
