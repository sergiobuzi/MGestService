using System.ComponentModel.DataAnnotations.Schema;

namespace MGestService.Models
{
    public class ProcedureFormViewModel
    {
        public int? CustomerStatusId { get; set; }
        public List<CustomerStatus> CustomerStatuses { get; set; } = new List<CustomerStatus>();
        public int? ProductStatusId { get; set; }
        public List<ProductStatus> ProductStatuses { get; set; } = new List<ProductStatus>();
        //Dati relativi alla procedura
        public int ProcedureId { get; set; }
        public DateTime? EntryDate { get; set; }
        public string? ProblemDescription { get; set; } = string.Empty;
        public DateOnly? PurchaseDate { get; set; }
        public string? WorkSummary { get; set; } = string.Empty;
        public float? TotalCost { get; set; }
        public float TechnicalExamCost { get; set; }
        public string? Accessories { get; set; } = string.Empty;
        public string? Warranty { get; set; } = string.Empty;
        public string? WarrantyNumber { get; set; } = string.Empty;
        public string? WarrantyPath { get; set; } = string.Empty;
        public IFormFile? WarrantyFile { get; set; }
        //Dati del cliente
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        //Dati relativi al dispositivo
        public string Brand { get; set; } = string.Empty;
        public string ProductModel { get; set; } = string.Empty;
        public string? SerialNumber { get; set; } = string.Empty;
    }
}
