using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Green_Gardens.Model
{
    public class Customer //will create the columns for the customer table
    {
        [Key]
        public Guid Id { get; set; }

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

        [AllowNull]
        public int? LoyaltyPoints { get; set; }

        [Required]
        public bool IsAdmin { get; set; }

    }
}
