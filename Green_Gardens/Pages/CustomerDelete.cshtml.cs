using Green_Gardens.Data;
using Green_Gardens.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Green_Gardens.Pages
{
    public class CustomerDeleteModel : PageModel
    {
        private readonly AppDbContext _dbConnection;

        public Customer Customer { get; set; }

        public CustomerDeleteModel(AppDbContext context)
        {
            _dbConnection = context;
        }

        public void OnGet(Guid id)
        {
            // Retrieve the item to be deleted
            Customer = _dbConnection.Customer.FirstOrDefault(t => t.CustomerId == id);
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            var customerToDelete = _dbConnection.Customer.FirstOrDefault(t => t.CustomerId == id);
            if (customerToDelete != null)
            {
                _dbConnection.Customer.Remove(customerToDelete);
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
