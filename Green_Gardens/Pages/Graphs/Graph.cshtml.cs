using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Green_Gardens.Data;
using Green_Gardens.Model;


namespace Green_Gardens.Pages.Graphs
{
    public class GraphModel : PageModel
    {

        private readonly AppDbContext _dbConnection;

        public string ProductJson { get; set; }

        public GraphModel(AppDbContext db)
        {
            _dbConnection = db;
        }


        public void OnGet()
        {
            var items = _dbConnection.Product.ToList();
            ProductJson = JsonSerializer.Serialize(items.Select(t => new { t.Stock, t.Price }));

        }
    }
}
