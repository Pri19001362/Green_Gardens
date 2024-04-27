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
            // Retrieve the customer to be deleted based on their id
            Customer = _dbConnection.Customer.FirstOrDefault(t => t.CustomerId == id);
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            //gets the customer
            var customerToDelete = _dbConnection.Customer.FirstOrDefault(t => t.CustomerId == id);
            if (customerToDelete != null)
            {
                //removes the customer from the database and saves the changes
                _dbConnection.Customer.Remove(customerToDelete);
                await _dbConnection.SaveChangesAsync();
                //returns them back to admin page 
                return RedirectToPage("Admin");
            }
            else
            {
                // Handle the case where the customer does not exist
                return NotFound();
            }
        }
    }
}
