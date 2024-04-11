using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Green_Gardens.Data;
using Green_Gardens.Model;

namespace Green_Gardens.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly AppDbContext _db;

        public List<Product> Products { get; set; }

        public ProductsModel(AppDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Products = _db.Product.ToList();
        }
    }
}
