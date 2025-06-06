﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Security.Claims;

namespace MGestService.Models
{
    public class Procedure
    {
        [Key]
        public int ProcedureId { get; set; }
        public DateTime? EntryDate { get; set; }
        public string ProblemDescription { get; set; } = string.Empty;
        public DateOnly? PurchaseDate { get; set; }
        public string? WorkSummary { get; set; } = string.Empty;
        public float? TotalCost { get; set; }
        public float TechnicalExamCost { get; set; }
        public string? Accessories { get; set; } = string.Empty;
        public string Warranty {  get; set; } = string.Empty;
        public string? WarrantyNumber { get; set; } = string.Empty;
        public string? WarrantyPath { get; set; } = string.Empty;
        [NotMapped]
        public IFormFile WarrantyFile { get; set; }

        //CustomerId
        // Foreign key (chiave esterna) che collega il prodotto al cliente
        public int CustomerId { get; set; }
        // Proprietà di navigazione per l'associazione al cliente
        public Customer Customer { get; set; }

        //ProductStatusId
        // Foreign key (chiave esterna) che collega il prodotto allo stato
        public int ProductStatusId { get; set; }
        // Proprietà di navigazione per l'associazione allo stato
        public ProductStatus ProductStatus { get; set; }

        //ProductId
        // Foreign key (chiave esterna) che collega la procedura al prodotto
        public int ProductId { get; set; }
        // Proprietà di navigazione per l'associazione al prodotto
        public Product Product { get; set; }

    }
}
