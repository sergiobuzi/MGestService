using System.ComponentModel.DataAnnotations;

namespace MGestService.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string ProductModel { get; set; } = string.Empty;
        public string? SerialNumber { get; set; } = string.Empty;

        // Collezione di procedure associati al prodotto
        public List<Procedure> Procedures { get; set; }
    }
}
