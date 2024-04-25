using Green_Gardens.Data;
using Green_Gardens.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Green_Gardens.Pages
{
    public class BasketModel : PageModel
    {
        private readonly AppDbContext _db;

        public List<Customer> Customer { get; set; }
        public List<Order> Order { get; set; }
        public List<Product> Product { get; set; }

        public BasketModel(AppDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Customer = _db.Customer.ToList();
            var email = HttpContext.Session.GetString("UserEmail");
            if (!string.IsNullOrEmpty(email))
            {
                Customer = _db.Customer.Where(c => c.Email == email).ToList();
            }


            Product = _db.Product.ToList();
            var name = HttpContext.Session.GetString("Product");
            if (!string.IsNullOrEmpty(name))
            {
                Product = _db.Product.Where(p => p.Name == name).ToList();
            }
            
        }

        
    }
}
