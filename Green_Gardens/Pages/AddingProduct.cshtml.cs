using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Green_Gardens.Data;
using Green_Gardens.Model;

namespace Green_Gardens.Pages
{
    public class AddingProductModel : PageModel
    {
        private readonly AppDbContext _db, _context;

        [BindProperty]
        public Product Product { get; set; }
        [BindProperty]
        public string Name { get; set; }

        public AddingProductModel(AppDbContext db, AppDbContext context)
        {
            _db = db;
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            Product = await _db.Product.FindAsync(id);

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }

    }
}
