using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Green_Gardens.Data;
using Green_Gardens.Model;

namespace Green_Gardens.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _dbConnection;

        public Product Product { get; set; }

        public DeleteModel(AppDbContext context)
        {
            _dbConnection = context;
        }

        public void OnGet(Guid id)
        {
            // Retrieve the item to be deleted
            Product = _dbConnection.Product.FirstOrDefault(t => t.ProductId == id);
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            var itemToDelete = _dbConnection.Product.FirstOrDefault(t => t.ProductId == id);
            if (itemToDelete != null)
            {
                _dbConnection.Product.Remove(itemToDelete);
                await _dbConnection.SaveChangesAsync();
                return RedirectToPage("Admin");
            }
            else
            {
                // Handle the case where the item does not exist
                return NotFound();
            }
        }
    }
}
