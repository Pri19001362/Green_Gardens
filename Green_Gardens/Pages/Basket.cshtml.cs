using Green_Gardens.Data;
using Green_Gardens.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Green_Gardens.Pages
{
    public class BasketModel : PageModel
    {
        private readonly AppDbContext _db;

        // Public property for a list of items. Stores the list of all customers, orders and products
        public List<Customer> Customer { get; set; }
        public List<Product> Product { get; set; }
        public List<Order> Order { get; set; }

        public BasketModel(AppDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            //gets all the information from database apart from customer where it gets the customer that is logged in
            Customer = _db.Customer.ToList();
            var email = HttpContext.Session.GetString("UserEmail");
            if (!string.IsNullOrEmpty(email))
            {
                Customer = _db.Customer.Where(c => c.Email == email).ToList();
            }
            Product = _db.Product.ToList();
            Order = _db.Order.ToList();
        }


    }
}
