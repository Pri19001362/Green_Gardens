using Green_Gardens.Data;
using Green_Gardens.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Green_Gardens.Pages;



namespace Green_Gardens.Pages
{
    public class AccountModel : PageModel
    {
        private readonly AppDbContext _db;

        //gets customer table
        public List<Customer> Customer { get; set; }

        public AccountModel(AppDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Customer = _db.Customer.ToList();
            //will check to see what user is logged in thanks to the session in the register page
            var email = HttpContext.Session.GetString("UserEmail");
            if (!string.IsNullOrEmpty(email))
            {
                Customer = _db.Customer.Where(c => c.Email == email).ToList();
            }
        }
    }
}
