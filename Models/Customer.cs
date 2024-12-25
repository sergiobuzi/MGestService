using System.ComponentModel.DataAnnotations;

namespace MGestService.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;

        // Collezione di procedure associate al cliente
        public List<Procedure> Procedures { get; set; }


        //ProductStatusId
        // Foreign key (chiave esterna) che collega il prodotto allo stato
        public int CustomerStatusId { get; set; }
        // Proprietà di navigazione per l'associazione allo stato
        public CustomerStatus CustomerStatus { get; set; }
    }
}
