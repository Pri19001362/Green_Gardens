using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Green_Gardens.Model;
using Green_Gardens.Data;

namespace Green_Gardens.Pages
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _dbConnection;

        public Product Item { get; set; }

        public CreateModel(AppDbContext context)
        {
            _dbConnection = context;
        }

        public void OnGet()
        {
            Item = new Product(); // Initialize Item
        }

        public IActionResult OnPost(Product Item)
        {
            if (!ModelState.IsValid)
            {
                // Log validation errors or set a breakpoint here to inspect ModelState
                return Page();
            }

            // Set a breakpoint here to inspect the 'Item' object
            _dbConnection.Product.Add(Item);
            _dbConnection.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
