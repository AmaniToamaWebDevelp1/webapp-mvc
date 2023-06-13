using webapp_mvc.Models;
using  Microsoft.EntityFrameworkCore;
namespace  webapp_mvc.Repository;

public class ApplicationDbContext : DbContext 
{
    //constrcture
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options){
                 
    }
 
    public DbSet<OrderInfo> OrderInfos{get; set;}
    public DbSet<Meida> Meidas{get; set;}
    public DbSet<SuperAdmin> SuperAdmin{get; set;}
    public DbSet<Admin> Admins{get; set;}
    public DbSet<Permission> Permissions{get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Enable sensitive data logging
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);

         
        }
    /**
    *! Add more tables below!
    */
}
