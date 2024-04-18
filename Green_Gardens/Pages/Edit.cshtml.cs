using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Green_Gardens.Data;
using Green_Gardens.Model;

namespace Green_Gardens.Pages
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _dbConnection;

        [BindProperty]
        public Product Product { get; set; }

        public EditModel(AppDbContext context)
        {
            _dbConnection = context;
        }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            Product = await _dbConnection.Product.FindAsync(id);

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
          

            var itemToUpdate = await _dbConnection.Product.FindAsync(Product.Id);

            if (itemToUpdate == null)
            {
                return NotFound();
            }

            // Update the properties of the item
            itemToUpdate.Name = Product.Name;
            itemToUpdate.Description = Product.Description;
            itemToUpdate.Price = Product.Price;
            itemToUpdate.ImagePath = Product.ImagePath;
            itemToUpdate.Stock = Product.Stock;
            itemToUpdate.ExpectedStock = Product.ExpectedStock;

            // Save the changes
            await _dbConnection.SaveChangesAsync();

            return RedirectToPage("Admin");
        }
    }
}
