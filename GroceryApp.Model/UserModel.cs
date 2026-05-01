using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GroceryApp.Model
{
    public class UserModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [Phone]
        [StringLength(15)]
        public string Phone { get; set; }

        [Range(1, 120)]
        public int Age { get; set; }

        [Required]
        public string PasswordHash { get; set; }  // hashed password only

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
