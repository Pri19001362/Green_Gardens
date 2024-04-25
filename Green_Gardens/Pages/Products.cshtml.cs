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

        public List<Product> Products { get; set; } = new List<Product>();
        public List<Customer> Customer { get; set; }
        public List<Order> Order { get; set; }

        public ProductsModel(AppDbContext db)
        {
            _db = db;
        }


        

        public void OnGet()
        {
            Products = _db.Product.ToList();
            Customer = _db.Customer.ToList();
            Order = _db.Order.ToList();
        }

        public async Task<IActionResult> OnPostAddToBasketAsync(Guid productId)
        {
            var productToAdd = await _db.Product.FindAsync(productId);
            if (productToAdd == null)
            {
                return NotFound();
            }

            var basketItem = new Order { ProductId = productToAdd.ProductId };
            _db.Order.Add(basketItem);
            await _db.SaveChangesAsync();
            return RedirectToPage(); // Refresh the page or redirect to a confirmation page
        }



    }
}
