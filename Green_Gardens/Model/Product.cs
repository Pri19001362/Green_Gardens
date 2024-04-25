using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Green_Gardens.Model
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [MaxLength(100)]
        [Required]
        public string Description { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [AllowNull]
        public string? ImagePath { get; set; }

        
        [Required]
        public int Stock { get; set; }

        
        [Required]
        public int ExpectedStock { get; set; }

        
    }
}
