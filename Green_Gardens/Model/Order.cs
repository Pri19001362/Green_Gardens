using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Green_Gardens.Model
{
    public class Order  //will create the columns for the order table
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        //foreign key links it to products model
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int Quantity { get; set; } = 1;

    }
}
