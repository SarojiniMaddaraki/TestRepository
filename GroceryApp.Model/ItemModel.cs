using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GroceryApp.Model
{
    public class ItemModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string ItemName { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Range(0.01, 100000)]
        public double Price { get; set; }

        [Required]
        [Range(0.01, 10000)]
        public double Quantity { get; set; }   // numeric

        [Required]
        [StringLength(20)]
        public string Unit { get; set; }       // kg, litre, pcs

        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public bool IsUsed { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
