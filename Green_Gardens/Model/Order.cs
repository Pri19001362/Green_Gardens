using System.ComponentModel.DataAnnotations;

namespace Green_Gardens.Model
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        
    }
}
