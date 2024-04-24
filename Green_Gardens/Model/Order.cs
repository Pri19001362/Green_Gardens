using System.ComponentModel.DataAnnotations;

namespace Green_Gardens.Model
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        
    }
}
