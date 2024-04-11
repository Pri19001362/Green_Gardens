using Green_Gardens.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Green_Gardens.Pages.Graphs
{
    public class GraphModel : PageModel
    {

        private readonly AppDbContext _dbConnection;

        public string TasksJson { get; set; }

        public GraphModel(AppDbContext db)
        {
            _dbConnection = db;
        }


        public void OnGet()
        {
            var items = _dbConnection.Product.ToList();
            TasksJson = JsonSerializer.Serialize(items.Select(t => new { Stock = t.Stock, t.Price }));

        }
    }
}
