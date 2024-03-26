using System.ComponentModel.DataAnnotations;

namespace Green_Gardens.Model
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

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


        [Required]
        public int LoyaltyPoints { get; set; }

    }
}
