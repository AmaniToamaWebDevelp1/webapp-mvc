using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using webapp_mvc.Repository;



var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json")
    .Build();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(
            new Version("8.0.33")),
        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
    )
);
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

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

app.MapControllerRoute( name: "default",
  pattern: "{controller=Home}/{action=Index}/{id?}");
// app.MapControllers();

app.Run();
