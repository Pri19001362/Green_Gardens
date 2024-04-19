using Green_Gardens.Data;
using Green_Gardens.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Green_Gardens.Pages
{
    public class AccountModel : PageModel
    {
        private readonly AppDbContext _db;

        public List<Customer> Customer { get; set; }

        public AccountModel(AppDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Customer = _db.Customer.ToList();
        }
    }
}
