using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Green_Gardens.Data;
using Green_Gardens.Model;


namespace Green_Gardens.Pages.Graphs
{
    public class GraphModel : PageModel
    {

        private readonly AppDbContext _dbConnection;

        public List<Product> Product { get; set; }
        public List<Customer> Customer { get; set; }
        public List<Order> Order { get; set; }

        public string ProductJson { get; set; }
        public string CustomerJson { get; set; }
        public string OrderJson { get; set; }

        public GraphModel(AppDbContext db)
        {
            _dbConnection = db;
        }


        public void OnGet()
        {
            var items = _dbConnection.Product.ToList();
            ProductJson = JsonSerializer.Serialize(items.Select(t => new { t.Name, t.Stock, t.ExpectedStock, t.Price }));

            var customer = _dbConnection.Customer.ToList();
            CustomerJson = JsonSerializer.Serialize(customer.Select(c => new { c.FirstName, c.LastName, c.LoyaltyPoints }));

            var order = _dbConnection.Order.ToList();
            OrderJson = JsonSerializer.Serialize(order.Select(o => new { o.Id, o.CustomerId, o.ProductId }));

            Customer = _dbConnection.Customer.ToList();
            Product = _dbConnection.Product.ToList();
            Order = _dbConnection.Order.ToList();
        }
    }
}
