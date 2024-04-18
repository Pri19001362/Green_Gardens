using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Green_Gardens.Model;
using Green_Gardens.Data;

namespace Green_Gardens.Pages
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _dbConnection;

        public Product Products { get; set; }

        public CreateModel(AppDbContext context)
        {
            _dbConnection = context;
        }

        public void OnGet()
        {
            Products = new Product(); // Initialize Item
        }

        public IActionResult OnPost(Product Products)
        {
            

            // Set a breakpoint here to inspect the 'Product' object
            _dbConnection.Product.Add(Products);
            _dbConnection.SaveChanges();

            return RedirectToPage("Admin");
        }
    }
}
