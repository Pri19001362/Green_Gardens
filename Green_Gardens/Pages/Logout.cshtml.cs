using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Green_Gardens.Pages
{
    public class LogoutModel : PageModel
    {
        //will occur when the user clicks the logout button
        public async Task<IActionResult> OnGetAsync()
        {
            //signs the user out and returns them to the homepage
            await HttpContext.SignOutAsync();
            return RedirectToPage("/Index");
        }
    }
}
