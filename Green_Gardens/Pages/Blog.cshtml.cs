using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Green_Gardens.Pages
{
    public class BlogModel : PageModel
    {
        //used to create logs
        private readonly ILogger<BlogModel> _logger;

        public BlogModel(ILogger<BlogModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
        }
    }
}
