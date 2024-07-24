using Microsoft.EntityFrameworkCore;
using PizzaOrdering_Mvc.PizzaApp_DbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var conn_str = builder.Configuration.GetConnectionString("PizzaDbContextConnection");
builder.Services.AddDbContext<PizzaAppDbContext>(options =>
options.UseSqlServer(conn_str));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Index");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Pizza}/{action=CreatePizza}/{id?}");

app.Run();
