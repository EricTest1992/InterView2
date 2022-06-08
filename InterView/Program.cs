using InterView.Models.DAO;
using InterView.Services;
using InterView.Services.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<InterViewContext>(opt =>
{
    opt.UseSqlServer("Server=localhost;Database=InterView;User ID=sa;Password=1234qwer;Trusted_Connection=True;");
});

builder.Services.AddTransient<IEmployeeService, EmployeeService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Index}/");

app.Run();
