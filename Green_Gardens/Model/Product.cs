using System.ComponentModel.DataAnnotations;

namespace Green_Gardens.Model
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [MaxLength(100)]
        [Required]
        public string Description { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public string ImagePath { get; set; }

        [MaxLength(100)]
        [Required]
        public int Stock { get; set; }

        [MaxLength(100)]
        [Required]
        public int ExpectedStock { get; set; }
    }
}
