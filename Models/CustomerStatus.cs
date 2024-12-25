using System.ComponentModel.DataAnnotations;

namespace MGestService.Models
{
    public class CustomerStatus
    {
        [Key]
        public int CustomerStatusId { get; set; }
        public string Description { get; set; } = string.Empty;

        // Collezione di clienti associati allo stato
        public List<Customer> Customers { get; set; }
    }
}
