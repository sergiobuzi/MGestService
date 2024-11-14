using System.ComponentModel.DataAnnotations;

namespace MGestService.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string? SerialNumber { get; set; }

        // Collezione di procedure associati al prodotto
        public List<Procedure> Procedures { get; set; }
    }
}
