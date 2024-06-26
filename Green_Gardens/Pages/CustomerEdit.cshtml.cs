using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Green_Gardens.Data;
using Green_Gardens.Model;

namespace Green_Gardens.Pages
{
    public class CustomerEditModel : PageModel
    {
        private readonly AppDbContext _dbConnection;

        [BindProperty]
        public Customer Customer { get; set; }

        public CustomerEditModel(AppDbContext context)
        {
            _dbConnection = context;
        }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            //gets the customer based on the id
            Customer = await _dbConnection.Customer.FindAsync(id);

            if (Customer == null)
            {
                //if customer does not exist
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            //finds the customer based on the id
            var itemToUpdate = await _dbConnection.Customer.FindAsync(Customer.CustomerId);

            if (itemToUpdate == null)
            {
                return NotFound();
            }

            // Update the properties of the Customer
            itemToUpdate.FirstName = Customer.FirstName;
            itemToUpdate.LastName = Customer.LastName;
            itemToUpdate.Email = Customer.Email;
            itemToUpdate.LoyaltyPoints = Customer.LoyaltyPoints;

            // Save the changes
            await _dbConnection.SaveChangesAsync();

            return RedirectToPage("Admin");
        }
    }
}
