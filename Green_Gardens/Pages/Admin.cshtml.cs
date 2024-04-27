using Green_Gardens.Data;
using Green_Gardens.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Green_Gardens.Pages
{
    public class AdminModel : PageModel
    {
        private readonly ILogger<AdminModel> _logger;


        private readonly AppDbContext _dbConnection;

        //Add instance of AppDbContext

        public AdminModel(ILogger<AdminModel> logger, AppDbContext _db)
        {
            _logger = logger;
            _dbConnection = _db;
        }

        // Public property for a list of items. Stores the list of all customers, orders and products
        public List<Customer> Customer { get; set; }
        public List<Product> Product { get; set; }
        public List<Order> Order { get; set; }

        public void OnGet()
        {
            //gets the database information
            Customer = _dbConnection.Customer.ToList();
            Product = _dbConnection.Product.ToList();
            Order = _dbConnection.Order.ToList();
        }
    }
}
