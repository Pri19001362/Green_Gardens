using Green_Gardens.Data;
using Green_Gardens.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Green_Gardens.Pages
{
    public class RedeemModel : PageModel
    {
        private readonly ILogger<RedeemModel> _logger;

        private readonly AppDbContext _dbConnection;

        //Add instance of AppDbContext

        public RedeemModel(ILogger<RedeemModel> logger, AppDbContext _db)
        {
            _logger = logger;
            _dbConnection = _db;
        }

        // Public property for a list of items. This stores the list of table data. Not neccessary for the redeem page currently
        public List<Customer> Customer { get; set; }
        public List<Product> Product { get; set; }
        public List<Order> Order { get; set; }

        public void OnGet()
        {
            //gets the data from startup
            Customer = _dbConnection.Customer.ToList();
            Product = _dbConnection.Product.ToList();
            Order = _dbConnection.Order.ToList();
        }




    }
}
