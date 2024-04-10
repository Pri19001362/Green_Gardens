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
        public Product Item { get; set; }

        public EditModel(AppDbContext context)
        {
            _dbConnection = context;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Item = await _dbConnection.Product.FindAsync(id);

            if (Item == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var itemToUpdate = await _dbConnection.Product.FindAsync(Item.Id);

            if (itemToUpdate == null)
            {
                return NotFound();
            }

            // Update the properties of the item
            itemToUpdate.Name = Item.Name;
            itemToUpdate.Description = Item.Description;
            itemToUpdate.Price = Item.Price;
            itemToUpdate.ImagePath = Item.ImagePath;
            itemToUpdate.Stock = Item.Stock;
            itemToUpdate.ExpectedStock = Item.ExpectedStock;

            // Save the changes
            await _dbConnection.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
