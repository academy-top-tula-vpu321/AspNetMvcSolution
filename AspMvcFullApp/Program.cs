using Microsoft.EntityFrameworkCore;
using AspMvcFullApp.Models;


var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationContext>(
    options => options.UseSqlServer(connectionString)
    );
builder.Services.AddControllersWithViews();

var app = builder.Build();


app.UseStaticFiles();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
