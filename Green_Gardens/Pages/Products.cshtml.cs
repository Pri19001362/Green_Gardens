using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Green_Gardens.Data;
using Green_Gardens.Model;

namespace Green_Gardens.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly AppDbContext _db, _context;

        [BindProperty]
        public string Name { get; set; }

        public List<Product> Products { get; set; }
        public List<Customer> Customer { get; set; }

        public ProductsModel(AppDbContext db, AppDbContext context)
        {
            _db = db;
            _context = context;
        }


        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid) // Check if the model state is valid
            {
                return Page(); // Return to the page if validation fails
            }

            var product = _context.Product.FirstOrDefault(p => p.Name == Name);

            if (product != null)
            {
                HttpContext.Session.SetString("Product", product.Name);

                return RedirectToPage(); // Refresh the page to reflect the added item

            }
            return Page(); // Or provide a user-friendly error message


            //var defaultTask = new Order
            //{
            //    ProductId = "Existing product Id",
            //    CustomerId = Customer.CustomerId

            //};

            //_db.Order.Add(defaultTask);
            //await _db.SaveChangesAsync();


        }

        public void OnGet()
        {
            Products = _db.Product.ToList();
            Customer = _db.Customer.ToList();
            var email = HttpContext.Session.GetString("UserEmail");
            if (!string.IsNullOrEmpty(email))
            {
                Customer = _db.Customer.Where(c => c.Email == email).ToList();
            }
        }

       

    }
}
