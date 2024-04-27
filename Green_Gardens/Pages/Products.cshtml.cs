using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Green_Gardens.Data;
using Green_Gardens.Model;

namespace Green_Gardens.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly AppDbContext _db;

        [BindProperty]
        public Product Product { get; set; }

        //creates a new product list for adding to the order table
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Customer> Customer { get; set; }
        public List<Order> Order { get; set; }

        public ProductsModel(AppDbContext db)
        {
            _db = db;
        }


        

        public void OnGet()
        {
            //gets all database info
            Products = _db.Product.ToList();
            Customer = _db.Customer.ToList();
            Order = _db.Order.ToList();
        }

        //function for adding product to order table
        public async Task<IActionResult> OnPostAddToBasketAsync(Guid productId)
        {
            //finds the product based on its id
            var productToAdd = await _db.Product.FindAsync(productId);
            if (productToAdd == null)
            {
                //displays if product does not exist
                return NotFound();
            }

            //adds the product id to the order table, linking them via the foreign key
            var basketItem = new Order { ProductId = productToAdd.ProductId };
            _db.Order.Add(basketItem);
            //saves the changes to the database
            await _db.SaveChangesAsync();
            return RedirectToPage(); // Refresh the page or redirect to a confirmation page
        }



    }
}
