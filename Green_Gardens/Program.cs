using Microsoft.EntityFrameworkCore;
using Green_Gardens.Model;
using Green_Gardens.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Retrieve the database connection string labeled "DefaultConnection" from the application's configuration settings.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register the DbContext for the application, specifying to use SQL Server with the connection string obtained earlier.
// AppDbContext is the class managing the database context.
builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(connectionString));
//Register a singleton instance of product
builder.Services.AddSingleton<Customer>();
builder.Services.AddSingleton<Product>();
builder.Services.AddSingleton<Order>();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();  // Necessary for session state
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


// Register services for MVC Controllers and Views. This is essential for applications using the MVC architecture.
builder.Services.AddControllersWithViews();

///////////////// Add authentication services with cookie authentication configured
builder.Services.AddAuthentication("Cookies")
    .AddCookie("Cookies", options =>
    {
        options.LoginPath = "/Login";
        options.LogoutPath = "/Logout";
        // Configure other options as needed
    });
/// <summary>
/// //////////////////////////////////////
/// </summary>

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Ensure this call is before UseAuthorization
app.UseAuthorization();

app.MapRazorPages();
app.UseSession();
app.Run();