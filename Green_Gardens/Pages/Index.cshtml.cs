using Green_Gardens.Data;
using Green_Gardens.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Green_Gardens.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly AppDbContext _dbConnection;

        //Add instance of AppDbContext

        public IndexModel(ILogger<IndexModel> logger, AppDbContext _db)
        {
            _logger = logger;
            _dbConnection = _db;
        }

        //stores the list of tasks
        public List<Customer> Customer { get; set; }

        public void OnGet()
        {
            Customer = _dbConnection.Customer.ToList();
        }
    }
}