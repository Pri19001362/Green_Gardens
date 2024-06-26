﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Green_Gardens.Model
{
    public class Customer //will create the columns for the customer table
    {
        [Key]
        public Guid CustomerId { get; set; }

        [MaxLength(100)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(100)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(100)]
        [Required]
        public string Email { get; set; }

        [MaxLength(100)]
        [Required]
        public string Password { get; set; }

        public int LoyaltyPoints { get; set; }

        //used for admin verification
        [Required]
        public bool IsAdmin { get; set; }

        
    }
}
