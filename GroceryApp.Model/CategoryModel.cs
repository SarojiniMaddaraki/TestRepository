using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GroceryApp.Model
{
    public class CategoryModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }   // fixed naming

        [StringLength(250)]
        public string Description { get; set; } 

        public Guid? UserId { get; set; }  // optional (for user-specific categories)

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
