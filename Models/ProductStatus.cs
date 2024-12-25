using System.ComponentModel.DataAnnotations;

namespace MGestService.Models
{
    public class ProductStatus
    {
        [Key]
        public int ProductStatusId { get; set; }
        public string Description { get; set; } = string.Empty;

        // Collezione di stati associati alla procedura
        public List<Procedure> Procedures { get; set; }
    }
}
