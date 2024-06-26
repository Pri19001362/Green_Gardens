﻿using Green_Gardens.Data;
using Green_Gardens.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Green_Gardens.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        // Public property for a list of product items. This stores the list of products.
        public List<Product> Products { get; set; }

        private readonly AppDbContext _dbConnection;

        //Add instance of AppDbContext

        public IndexModel(ILogger<IndexModel> logger, AppDbContext _db)
        {
            _logger = logger;
            _dbConnection = _db;
        }

        //stores the list of tables from the databsase
        public List<Customer> Customer { get; set; }
        public List<Product> Product { get; set; }
        public List<Order> Order { get; set; }

        public void OnGet()
        {
            //gets the table information on startup
            Customer = _dbConnection.Customer.ToList();
            Product = _dbConnection.Product.ToList();
            Order = _dbConnection.Order.ToList();
        }
    }
}