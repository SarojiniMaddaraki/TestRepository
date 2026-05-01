using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GroceryApp.Model
{
    public class GroceryTransactionModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ItemId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public TransactionType ActionType { get; set; }  // enum instead of string

        [Required]
        [Range(0.01, 10000)]
        public double Quantity { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;
    }

    public enum TransactionType
    {
        Added = 1,
        Used = 2
    }
}
